#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>

#include <platform.h>

#include "build/build_config.h"
#include "build/debug.h"

#include "common/axis.h"
#include "common/maths.h"
#include "common/filter.h"

#include "config/config_reset.h"
#include "pg/pg.h"
#include "pg/pg_ids.h"

#include "drivers/sound_beeper.h"
#include "drivers/time.h"

#include "fc/fc_core.h"
#include "fc/fc_rc.h"

#include "fc/rc_controls.h"
#include "fc/runtime_config.h"

#include "flight/control.h"
#include "flight/imu.h"
#include "flight/mixer.h"

#include "io/gps.h"

#include "rx/rx.h"
#include "rx/msp.h"

#include "sensors/gyro.h"
#include "sensors/compass.h"

/* User Inputs */
float rightAscentionAngle, declinationAngle, kp, ki, kd;

/* Actual attitude */
float theta, phi;

/* Attitude determination */
int magReferenceSet = 0;										// Flag to determine whether reference has been set
int pitchBiasSet = 0;											// Flag to determine whether pitch angle bias has been set
float magReferenceLength, pitchBias;							// Length (magnitude) of the reference vector, pitch angle bias
float dotY, dotZ, refDotY, refDotZ;								// Dot product of the vectors, used to compute Euler angles and the sign of the angles
float magn[3];													// Current and reference magnetometer readings
float magZ[3], magRefZ[3];										// Magnetometer readings for calculating yaw
float magY[3], magRefY[3];										// Magnetometer readings for calculating pitch
float crossProdZ[3], crossProdY[3];								// Vector to store cross product of vectors		
float Rc[3][3];													// Rotation matrix

float norm(int nRows, float vect_A[nRows])
{
	float norm = 0;

	for (int i = 0; i < nRows; i++) {
		norm += vect_A[i] * vect_A[i];
	}

	return sqrt(norm);
}

/* Function which computes the dot product of two vectors */
float dotProduct(int nRows, float vect_A[nRows], float vect_B[nRows])
{
	float product = 0;

	for (int i = 0; i < nRows; i++) {
		product = product + vect_A[i] * vect_B[i];
	}

	return product;
}

/* Function which computes the cross product of two 3x1 vectors */
void crossProduct(float vect_A[3], float vect_B[3], float cross_P[3])
{
	cross_P[0] = vect_A[1] * vect_B[2] - vect_A[2] * vect_B[1];
	cross_P[1] = vect_A[0] * vect_B[2] - vect_A[2] * vect_B[0];
	cross_P[2] = vect_A[0] * vect_B[1] - vect_A[1] * vect_B[0];
}

/* Function which applies scalar multiplication to a matrix */
void scalarMultiply(int nRows, int nCols, float matrix[nRows][nCols], float scalar)
{
	int row, column;
	for (row = 0; row < nRows; ++row) {
		for (column = 0; column < nCols; ++column) {
			matrix[row][column] *= scalar;
		}
	}
}

pid_t pid_create(pid_t pid, float* in, float* out, float* set)
{
	pid->input = in;
	pid->output = out;
	pid->setpoint = set;

	setOutputLimits(pid, -200000, 200000);

	// Set default sample time to 100 ms
	pid->sampleTime = 100;

	setDirection(pid, E_PID_DIRECT);
	tunePID(pid);

	pid->lastTime = millis();

	return pid;
}

bool pid_need_compute(pid_t pid)
{
	// Check if the PID period has elapsed
	return(millis() - pid->lastTime >= pid->sampleTime) ? true : false;
}

void computePID(pid_t pid)
{
	float currAng = *(pid->input);
	float gain = 30.826;                                   /* Gain of the system */
	float error = ((*(pid->setpoint)) - currAng) * gain;   /* Find the difference between setpoint and current angle */

	pid->integral += (pid->Ki * error);                                 /* Add to accumulative integral term */
	if (pid->integral > pid->outMax) pid->integral = pid->outMax;       /* If the integral term is above the allowed output range, clamp it */
	else if (pid->integral < pid->outMin) pid->integral = pid->outMin;  /* If the integral term is below the allowed output range, clamp it */
	
	float deltaInput = currAng - pid->lastInput;   /* Rate of change of desired angle */
													 
	/* Compute PID output */
	float Output = pid->Kp * error + pid->integral - pid->Kd * deltaInput;         /* Calculate output term */
	if (Output > pid->outMax) Output = pid->outMax;                                /* If the output term is above the allowed output range, clamp it */
	else if (Output < pid->outMin) Output = pid->outMin;                           /* If the output term is below the allowed output range, clamp it */

	/* Store variables for next iteration */
	(*pid->output) = Output;
	pid->lastInput = currAng;
	pid->lastTime = millis();
}

void computePPM(double in, int num) 
{
	/* Compute the required acceleration from torque value (rad/s^2) */
	/* Divide required torque by the moment of inertia of flywheels */
	double req_acc = ((double)in / 0.000339292);

	/* Compute the required velocity from acceleration value (rad/s) */
	/* Velocity = Acceleration * delta_t + omega_0 */
	double req_vel = req_acc * 0.1 + (abs(1500 - rcData[num]) * 1.04719755);

	double req_RPM = req_vel / 0.504719755;							// 0.104719755
	int req_PPM = 1500 + (req_RPM / 10);
	if (req_PPM > 2000) req_PPM = 2000;                                /* If the output term is above the allowed output range, clamp it */
	else if (req_PPM < 1000) req_PPM = 1000;
	rcData[num] = req_PPM;
	motor_disarmed[num] = req_PPM;
}

/* Function to tune PID constants */
void tunePID(pid_t pid) 
{
	/* If the constants are negative values, return nothing */
	if (kp<0 || ki<0 || kd<0) return;

	pid->Kp = kp;
	pid->Ki = ki * ((float)pid->sampleTime / 1000);  /* Calculate the mathematical equivalent incorporating the sample time*/
	pid->Kd = kd / ((float)pid->sampleTime / 1000);  /* Calculate the mathematical equivalent incorporating the sample time*/
}

/* Function to set output limits */
void setOutputLimits(pid_t pid, float Min, float Max)
{
	if (Min >= Max) return;
	pid->outMin = Min;
	pid->outMax = Max;
}

void setDirection(pid_t pid, enum pid_control_directions dir)
{
	if (pid->direction != dir) {
		pid->Kp = (0 - pid->Kp);
		pid->Ki = (0 - pid->Ki);
		pid->Kd = (0 - pid->Kd);
	}
	pid->direction = dir;
}

void computeAttitude()
{
	float magReference[3] = { -474, 309, -20 };						// Measurement at 0,0
	float why[3] = { 0,1,0 };										// Pitch axis reference vector
	float zed[3] = { 0,0,1 };										// Yaw axis reference vector
	float skewZ[3][3] = { { 0, -1, 0 },{ 1, 0, 0 },{ 0, 0, 0 } };   // Yaw axis skew matrix
	float eye[3][3] = { { 1, 0, 0 },{ 0, 1, 0 },{ 0, 0, 1 } };      // Identity matrix
	float eyeZ[3][3] = { { 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 1 } };     // Yaw axis identity matrix 

	/* Load the current magnetometer reading */
	for (int i = 0; i < 3; i++) {
		magn[i] = mag.magADC[i];
	}

	/* Setup reference magnetometer reading */
	if (magReferenceSet == 0) {
		//for (int i = 0; i < 3; i++) {
		//	magReference[i] = magn[i];
		//}

		/* Normalize the reference vector */
		magReferenceLength = norm(3, magReference);
		for (int i = 0; i < 3; i++) {
			magReference[i] /= magReferenceLength;
		}

		/* Setup reference flag */
		magReferenceSet = 1;
	}

	/* Normalize the current magnetometer reading */
	float magnLength = norm(3, magn);
	for (int i = 0; i < 3; i++) {
		magn[i] /= magnLength;
	}

	/* Setup magnetometer vectors with Z component = 0 */
	for (int i = 0; i < 3; i++) {
		magZ[i] = magn[i];
	}
	magZ[2] = 0;
	for (int i = 0; i < 3; i++) {
		magRefZ[i] = magReference[i];
	}
	magRefZ[2] = 0;

	/* Calculate theta (yaw) between two vectors */
	dotZ = dotProduct(3, magZ, magRefZ);
	crossProduct(magZ, magRefZ, crossProdZ);
	theta = atan2(norm(3, crossProdZ), dotZ);

	/* Calculate the dot product of the normal vector and the cross product */
	/* This is used to determine the sign of the angle */
	refDotZ = dotProduct(3, crossProdZ, zed);

	/* Calculate each component of the Rodrigues equation */
	/* Rc = I*cos(theta) + crossProdZ*(crossProdZ.')*(1-cos(theta)) + skewZ*sin(theta) */
	scalarMultiply(3, 3, eye, cos(theta));
	scalarMultiply(3, 3, eyeZ, (1 - cos(theta)));
	scalarMultiply(3, 3, skewZ, sin(theta));

	/* Calculate the rotation matrix using the Rodrigues equation */
	for (int i = 0; i<3; i++)
	{
		for (int j = 0; j < 3; j++) {
			Rc[i][j] = eye[i][j] + eyeZ[i][j];
		}
	}
	for (int i = 0; i<3; i++)
	{
		for (int j = 0; j < 3; j++) {
			Rc[i][j] += skewZ[i][j];
		}
	}

	/* Apply the rotation matrix to transform the magnetometer vector */
	for (int i = 0; i<3; i++)
	{
		for (int j = 0; j < 3; j++) {
			magn[i] += magn[i] * Rc[i][j];
		}
	}

	/* Setup magnetometer vectors with Y component = 0 */
	for (int i = 0; i < 3; i++) {
		magY[i] = magn[i];
	}
	magY[1] = 0;
	for (int i = 0; i < 3; i++) {
		magRefY[i] = magReference[i];
	}
	magRefY[1] = 0;

	dotY = dotProduct(3, magY, magRefY);
	crossProduct(magY, magRefY, crossProdY);
	phi = atan2(norm(3, crossProdY), dotY);

	refDotY = dotProduct(3, crossProdY, why);

	/* Store the phi value as a bias, if it is not currently set */
	if (pitchBiasSet == 0) {
		pitchBias = phi;
		pitchBiasSet = 1;
	}

	/* Change the values of the angles as necessary */
	if (refDotZ < 0) {
		theta *= -1;
	}
	if (refDotY < 0) {
		//phi -= pitchBias;
		phi *= -1;
	}
	else {
		//phi -= pitchBias;
	}
	rcData[5] = theta * 57;
	rcData[6] = phi * 57;
}

/* Functions to interface with Betaflight */
PG_REGISTER_ARRAY_WITH_RESET_FN(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles, PG_CONTROL_PROFILE, 2);

void resetControlProfile(controlProfile_t *controlProfile)
{
	RESET_CONFIG(controlProfile_t, controlProfile,
		.rA = 0.0,
		.d = 0.0,
		.kp = 0.556,
		.ki = 0.0,
		.kd = 0.028
	);
}

void pgResetFn_controlProfiles(controlProfile_t *controlProfiles)
{
	for (int i = 0; i < MAX_PROFILE_COUNT; i++) {
		resetControlProfile(&controlProfiles[i]);
	}
}

void controlInitPosition(const controlProfile_t *controlProfile)
{
	rightAscentionAngle = controlProfile->rA;
	declinationAngle = controlProfile->d;
}

void controlInitPID(const controlProfile_t *controlProfile)
{
	kp = controlProfile->kp;
	ki = controlProfile->ki;
	kd = controlProfile->kd;
}

void controlInit(const controlProfile_t *controlProfile)
{
	controlInitPosition(controlProfile);
	controlInitPID(controlProfile);
}