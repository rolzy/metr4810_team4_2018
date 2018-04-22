// PID Loop
// Control the angle of the craft using angle feedback from the gyro & magnetometer

#include <iostream>
#include "pid.hpp"
#include <chrono>

using std::chrono::steady_clock;

/* PID variables */
steady_clock::time_point lastTime;     /* Time t of last iteration*/
float* myOutput;
float* myInput;
float* mySetpoint;                     /* Pointers saving current PID configurations*/
float integral, lastInput;             /* Sum of the error over time, Input from last iteration*/
float sampleTime;                      /* Sample time of the control loop */
float kp, ki, kd;                      /* PID constants */
float outMin, outMax;                  /* PID output limits */

#define DIRECT 0
#define REVERSE 1
int controllerDirection = DIRECT;

/* PID Constructor */
PID::PID(float* Input, float* Output, float* Setpoint,
	float Kp, float Ki, float Kd, int ControllerDirection)
{
	myOutput = Output;
	myInput = Input;
	mySetpoint = Setpoint;

	PID::setOutputLimits(1000, 2000);	/* Limits defined for the PPM range of the ESC*/

	sampleTime = 0.1;					/* Sample time of 0.1 seconds */

	PID::setControllerDirection(ControllerDirection);
	PID::tunePID(Kp, Ki, Kd);

	lastTime = steady_clock::now();
}

/* Function to compute PID output */
bool PID::Compute() {
	/* Compute time difference from last iteration */
	steady_clock::time_point now = steady_clock::now();
	std::chrono::duration<float> timeDiff = now - lastTime;

	/* Adjust output only if the time difference is greater than 1 second */
	if (timeDiff.count() >= sampleTime) {

		float Output = *myOutput;
		float currAngle = *myInput;
		float desAngle = *mySetpoint;

		/* Compute error variables */
		float error = desAngle - currAngle;
		integral += (ki * error);                      /* Add to the total of the composite integral term over time*/
		if (integral > outMax) integral = outMax;      /* If the integral term is above the allowed output range, clamp it */
		else if (integral < outMin) integral = outMin; /* If the integral term is below the allowed output range, clamp it */

		float deltaInput = (currAngle - lastInput);    /* Rate of change of desired angle */

		/* Compute PID output */
		Output = kp * error + integral - kd * deltaInput + 476;  /* Calculate output term */
		if (Output > outMax) Output = outMax;              /* If the output term is above the allowed output range, clamp it */
		else if (Output < outMin) Output = outMin;         /* If the output term is below the allowed output range, clamp it */

		std::cout << currAngle << " " << desAngle << " " << Output << std::endl;

		*myOutput = Output;

		/* Store variables for next iteration */
		lastInput = currAngle;
		lastTime = now;
		return true;
	}
	else {
		return false;
	}
}

/* Function to tune PID constants */
void PID::tunePID(float Kp, float Ki, float Kd) {
	/* If the constants are negative values, return nothing */
	if (Kp<0 || Ki<0 || Kd<0) return;

	float sampleTimeInSec = ((float)sampleTime) / 1000; /* Convert the sample time from ms to s*/
	kp = Kp;
	ki = Ki * sampleTimeInSec;  /* Calculate the mathematical equivalent incorporating the sample time*/
	kd = Kd / sampleTimeInSec;  /* Calculate the mathematical equivalent incorporating the sample time*/

	if (controllerDirection == REVERSE) {
		kp = (0 - kp);
		ki = (0 - ki);
		kd = (0 - kd);
	}
}

void PID::setOutputLimits(float Min, float Max)
{
	if (Min >= Max) return;
	outMin = Min;
	outMax = Max;
}

/* Function to set the sample time */
void PID::setSampleTime(int newSampleTime) {
	if (newSampleTime > 0)
	{
		float ratio = (float)newSampleTime / (float)sampleTime;
		ki *= ratio;  /* Tweak the constant reflecting the new sample time */
		kd /= ratio;  /* Tweak the constant reflecting the new sample time */
		sampleTime = (unsigned long)newSampleTime;
	}
}

/* Function to set the direction of control */
/* 0 = Direct (Right & Up), 1 = Reverse (Left & Down) */
void PID::setControllerDirection(int Direction) {
	controllerDirection = Direction;
}
