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
#include "sensors/acceleration.h"

/* User Inputs */
float rightAscentionAngle, declinationAngle;

pid_t pid_create(pid_t pid, float* in, float* out, float* set, float kp, float ki, float kd)
{
	pid->input = in;
	pid->output = out;
	pid->setpoint = set;

	setOutputLimits(pid, -200000, 200000);

	// Set default sample time to 100 ms
	pid->sampleTime = 100;

	setDirection(pid, E_PID_DIRECT);
	tunePID(pid, kp, ki, kd);

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

void computePPM(double in, int num) {
	/* Compute the required acceleration from torque value (rad/s^2) */
	double req_acc = ((double)in / 0.000339292);

	/* Compute the required velocity from acceleration value (rad/s) */
	double req_vel = req_acc * 0.1 + (abs(1500 - rcData[num]) * 1.04719755);

	double req_RPM = req_vel / 0.104719755;
	int req_PPM = rcData[num] + (req_RPM / 10);
	if (req_PPM > 2000) req_PPM = 2000;                                /* If the output term is above the allowed output range, clamp it */
	else if (req_PPM < 1000) req_PPM = 1000;
	rcData[num] = req_PPM;
}

/* Function to tune PID constants */
void tunePID(pid_t pid, float kp, float ki, float kd) {
	/* If the constants are negative values, return nothing */
	if (kp<0 || ki<0 || kd<0) return;

	pid->Kp = kp;
	pid->Ki = ki * ((float)pid->sampleTime / 1000.0);  /* Calculate the mathematical equivalent incorporating the sample time*/
	pid->Kd = kd / ((float)pid->sampleTime / 1000.0);  /* Calculate the mathematical equivalent incorporating the sample time*/
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

/* Functions to interface with Betaflight */
PG_REGISTER_ARRAY_WITH_RESET_FN(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles, PG_CONTROL_PROFILE, 2);

void resetControlProfile(controlProfile_t *controlProfile)
{
	RESET_CONFIG(controlProfile_t, controlProfile,
		.rA = 0.0,
		.d = 0.0
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

void controlInit(const controlProfile_t *controlProfile)
{
	controlInitPosition(controlProfile);
}