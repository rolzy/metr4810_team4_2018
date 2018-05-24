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
float rightAscentionAngle, declinationAngle , kp, ki, kd;	// Desired orientation and PID constants

/* Actual attitude */
float theta, phi;											// Calculated orientation

/* Attitude determination */
int magReferenceSet = 0;									// Flag that trigger when reference vector is setup
int targetReached = 0;										// Flag that trigger when target is reached
int originReached, originPitchReached = 0;					// Flags that trigger when origin is reached
int yawReached, pitchReached = 0;							// Flags that trigger when target is reached
int fluctuateYaw, fluctuatePitch = 0;						// Flags that control 
float refTheta, refPhi1;									// Variables that store reference angles
float magn[3], magReference[3];								// Array to store magnetometer measurement

float norm(int nRows, float vect_A[nRows])
{
	float norm = 0;

	for (int i = 0; i < nRows; i++) {
		norm += vect_A[i] * vect_A[i];
	}

	return sqrt(norm);
}

void readOrigin()
{
	for (int i = 0; i < 3; i++) {
		magReference[i] = mag.magADC[i];
	}
	rcData[4] = magReference[0];
	rcData[5] = magReference[1];
	rcData[6] = magReference[2];
	float magReferenceLength = norm(3, magReference);		// Normalize reference vector
	for (int i = 0; i < 3; i++) {
		magReference[i] /= magReferenceLength;
	}

	/* Store reference angle values */
	refTheta = atan2(magReference[1], magReference[0]);
	refPhi1 = atan2(magReference[2], magReference[0]);
}

void calibrate()
{

}

pid_t pid_create(pid_t pid, float* in, float* out, float* set)
{
	pid->input = in;
	pid->output = out;
	pid->setpoint = set;
	pid->automode = false;

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

	/* If the PID is in manual mode, skip computation*/
	if (!pid->automode)
		return false;


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
	if (num == 0 && fluctuateYaw) {
		rcData[num] = 1460;
		motor_disarmed[num] = 1460;
		return;
	}
	else if (num == 1 && fluctuatePitch) {
		rcData[num] = 1460;
		motor_disarmed[num] = 1460;
		return;
	}

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

void setAuto(pid_t pid)
{
	if (!pid->automode) {
		pid->integral = *(pid->output);
		pid->lastInput = *(pid->input);
		if (pid->integral > pid->outMax)
			pid->integral= pid->outMax;
		else if (pid->integral < pid->outMin)
			pid->integral= pid->outMin;
		pid->automode = true;
	}
}

void setManual(pid_t pid)
{
	pid->automode = false;
}

void computeAttitude(float *yaw, float *pitch)
{
	/* Load the current magnetometer reading */
	for (int i = 0; i < 3; i++) {
		magn[i] = mag.magADC[i];
	}

	/* Normalize the current magnetometer reading */
	float magnLength = norm(3, magn);
	for (int i = 0; i < 3; i++) {
		magn[i] /= magnLength;
	}

	/* Startup -> Finding the origin routine */
	if (!originReached) {

		/* If the pitch != 0, fix it first so craft is level */
		if (!originPitchReached) {
			theta = atan2f(magn[1], magn[0]) - refTheta;
			fluctuateYaw = 1;
			phi = atan2f(magn[2], magn[0]) - refPhi1;
			if (fabs(phi) < 0.0174533) {
				fluctuateYaw = 0;
				phi = 0;
				fluctuatePitch = 1;
				originPitchReached = 1;
			}
		}

		/* If pitch == 0, fix yaw until it is 0 */
		else {
			theta = atan2f(magn[1], magn[0]) - refTheta;
			if (fabs(theta) < 0.0174533) {
				originReached = 1;
				fluctuatePitch = 0;
				yawReached = 0;
				pitchReached = 0;
			}
		}
	}

	/* Origin -> Finding the target */
	else {

		if (!targetReached) {

			/* If pitchReached is still set from the last target, we are not flat */
			if (pitchReached) {
				theta = atan2f(magn[1], magn[0]) - refTheta;
				fluctuateYaw = 1;
				phi = atan2f(magn[2], magn[0]) - refPhi1;
				if (fabs(phi) < 0.0174533) {
					fluctuateYaw = 0;
					phi = 0;
					fluctuatePitch = 1;
					pitchReached = 0;
				}
			}
			else {

				/* If the yaw isn't at target, move it first */
				if (!yawReached) {
					theta = atan2f(magn[1], magn[0]) - refTheta;
					phi = 0;
					fluctuatePitch = 1;
					if (fabs(theta - rightAscentionAngle * (float)0.0174533) < 0.0174533) {
						fluctuatePitch = 0;
						fluctuateYaw = 1;
						phi = atan2f(magn[2], magn[0]) - refPhi1;
						theta = rightAscentionAngle * (float)0.0174533;
						yawReached = 1;
					}
				}

				/* If the pitch isn't at target, move it */
				else {
					if (!pitchReached) {
						theta = rightAscentionAngle * (float)0.0174533;
						fluctuateYaw = 1;
						phi = atan2f(magn[2], magn[0]) - refPhi1;
						if (fabs(phi - declinationAngle * (float)0.0174533) < 0.0174533) {
							pitchReached = 1;
							targetReached = 1;
						}
					}
				}
			}
		}
	}
	*yaw = theta;
	attitude.values.yaw = theta * (1800.0f / M_PIf);
	*pitch = phi;	
	attitude.values.pitch = phi * (1800.0f / M_PIf);
	//rcData[2] = theta * 57.2958;
	//rcData[3] = phi * 57.2958;
	//rcData[7] = originReached;
	//rcData[8] = targetReached;
	//rcData[9] = pitchReached;
}

/* Functions to interface with Betaflight */
PG_REGISTER_ARRAY_WITH_RESET_FN(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles, PG_CONTROL_PROFILE, 2);

void resetControlProfile(controlProfile_t *controlProfile)
{
	RESET_CONFIG(controlProfile_t, controlProfile,
		.rA = 0.0,
		.d = 0.0,
		.rO = 0,
		.cal = 0,
		.sC = 0,
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
	targetReached = 0;
	yawReached = 0;
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