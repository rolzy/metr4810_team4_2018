#include <stdbool.h>
#include "common/time.h"
#include "drivers/time.h"
#include "pg/pg.h"

#pragma once

struct pid_controller {
	// Input, output and setpoint
	float * input; //!< Current Process Value
	float * output; //!< Corrective Output from PID Controller
	float * setpoint; //!< Controller Setpoint
					  // Tuning parameters
	float Kp; //!< Stores the gain for the Proportional term
	float Ki; //!< Stores the gain for the Integral term
	float Kd; //!< Stores the gain for the Derivative term
			  // Output minimum and maximum values
	float outMin; //!< Maximum value allowed at the output
	float outMax; //!< Minimum value allowed at the output
				// Variables for PID algorithm
	float integral; //!< Accumulator for integral term
	float lastInput; //!< Last input value for differential term
				  // Time related
	timeMs_t lastTime; //!< Stores the time when the control loop ran last time
	uint32_t sampleTime; //!< Defines the PID sample time
};

typedef struct pid_controller * pid_t;

pid_t pid_create(pid_t pid, float* in, float* out, float* set, float kp, float ki, float kd);

bool pid_need_compute(pid_t pid);

void computePID(pid_t pid);
void tunePID(pid_t pid, float kp, float ki, float kd);
void setOutputLimits(pid_t pid, float Min, float Max);

typedef struct controlProfile_s {
	float rA;
	float d;
} controlProfile_t;

PG_DECLARE_ARRAY(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles);

void controlInitPosition(const controlProfile_t *controlProfile);
void controlInit(const controlProfile_t *controlProfile);
