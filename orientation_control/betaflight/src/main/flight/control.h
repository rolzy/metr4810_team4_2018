#include <stdbool.h>
#include "common/time.h"
#include "drivers/time.h"
#include "pg/pg.h"

#pragma once

enum pid_control_directions {
	E_PID_DIRECT,
	E_PID_REVERSE,
};

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

	enum pid_control_directions direction;
};

typedef struct pid_controller * pid_t;

pid_t pid_create(pid_t pid, float* in, float* out, float* set);

bool pid_need_compute(pid_t pid);

void computePID(pid_t pid);
void computePPM(double in, int num);
void tunePID(pid_t pid);
void setOutputLimits(pid_t pid, float Min, float Max);
void setDirection(pid_t pid, enum pid_control_directions dir);
void computeAttitude();

typedef struct controlProfile_s {
	float rA;
	float d;
	float kp;
	float ki;
	float kd;
} controlProfile_t;

PG_DECLARE_ARRAY(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles);

void controlInitPosition(const controlProfile_t *controlProfile);
void controlInitPID(const controlProfile_t *controlProfile);
void controlInit(const controlProfile_t *controlProfile);
