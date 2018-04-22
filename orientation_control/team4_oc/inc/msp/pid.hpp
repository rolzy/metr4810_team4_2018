/* Header Guard */
#ifndef PID_HPP
#define PID_HPP

class PID {
	public:

	#define DIRECT  0
	#define REVERSE  1

	/* Declerations */
	PID(float*, float*, float*, float, float, float, int); /* Constructor */
	bool Compute();
	void tunePID(float Kp, float Ki, float Kd);
	void setOutputLimits(float Min, float Max);
	void setSampleTime(int newSampleTime);
	void setControllerDirection(int Direction);
};
#endif