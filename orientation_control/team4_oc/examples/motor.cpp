// team4_oc.cpp : Defines the entry point for the console application.

// Moving motors and adjusting speed on keyboard input using a switch case
// Testing MSP 

#include <iostream>
//#include <MSP.hpp>
#include <msp_msg.hpp>
#include <msg_print.hpp>
#include <FlightController.hpp>
#include "pid.hpp"
#include <stdio.h>
#include <sys/select.h>
#include <sys/ioctl.h>
#include <termios.h>
#include <stropts.h>

/* Implementing kbhit() function on Linux */
int _kbhit() {
	static const int STDIN = 0;
	static bool initialized = false;

	if (!initialized) {
		// Use termios to turn off line buffering
		termios term;
		tcgetattr(STDIN, &term);
		term.c_lflag &= ~ICANON;
		tcsetattr(STDIN, TCSANOW, &term);
		setbuf(stdin, NULL);
		initialized = true;
	}

	int bytesWaiting;
	ioctl(STDIN, FIONREAD, &bytesWaiting);
	return bytesWaiting;
}

float Input; 
class App {
public:
	std::string name;

	App(const std::string name, const float acc_1g, const float gyro_unit, const float magn_gain, const float si_unit_1g) : acc_1g(acc_1g), gyro_unit(gyro_unit), magn_gain(magn_gain), si_unit_1g(si_unit_1g) {
		this->name = name;
	}

	void onImu(const msp::msg::ImuRaw& imu_raw) {
		std::cout << msp::msg::ImuSI(imu_raw, acc_1g, gyro_unit, magn_gain, si_unit_1g);
	}

	void onAttitude(const msp::msg::Attitude& attitude) {
		if (attitude.heading > 180) {
			Input = attitude.heading - 360; /* Convert angles over 180 to negative (-179 to 180) */
		} else {
			Input = attitude.heading;
		}
	}

	void onHello(const msp::msg::Hello& hello) {
		std::cout << hello.message << std::endl;
	}

	void onGetOrientation(const msp::msg::GetOrientation& getOrientation) {
		std::cout << "Right Ascention is " << getOrientation.rightAscention << " and the declination is " << getOrientation.declination << std::endl;
	}

private:
	const float acc_1g;
	const float gyro_unit;
	const float magn_gain;
	const float si_unit_1g;
};

int main(int argc, char *argv[]) {
	/* Operation Variables */
    const std::string device = (argc>1) ? std::string(argv[1]) : "/dev/ttyUSB0";  /* Define COM port*/
    const size_t baudrate = (argc>2) ? std::stoul(argv[2]) : 115200;              /* Baud rate of the system */
	float Output;
	float Setpoint = 0;                                                 /* PID Input, Output and Desired Angle */

	//msp::MSP msp(device, baudrate);  /* Initialize MSP class */
	//msp.setWait(1);                  /* Wait time (ms) between sending and receiving */

	fcu::FlightController fcu(device, baudrate);
	fcu.initialise();

	PID pid(&Input, &Output, &Setpoint, 50, 0.0048, 0, 0);  /* Initialize PID class */

	std::array<uint16_t, msp::msg::N_MOTOR> speed = { 1500, 1500, 1500, 1500, 0, 0, 0, 0 };  /* Speed Byte Vector, sent to the motors */

	App app("MultiWii", 512.0, 1.0 / 4.096, 0.92f / 10.0f, 9.80665f);
	fcu.subscribe(&App::onGetOrientation, &app, 0.1);

	/* Connect to the flight controller */
	/*std::cout << "Connecting FCU..." << std::endl;
	msp::msg::Ident ident;
	if (msp.request_wait(ident, 10)) {
		std::cout << "MSP version " << size_t(ident.version) << " ready" << std::endl;
	}
	std::cout << "ready" << std::endl;

	msp::msg::SetMotor motor; 
	msp::client::Client client;*/

	fcu.setOrientation(35, 35);
	while (true) {
		/* Receive attitude data*/
		//msp::msg::Attitude attitude;
		//if (msp.request_block(attitude))
		//	if (attitude.heading > 180) {
		//		Input = attitude.heading - 360; /* Convert angles over 180 to negative (-179 to 180) */
		//	} else {
		//		Input = attitude.heading;
		//	}
		//else
		//	std::cerr << "unsupported: " << size_t(attitude.id()) << std::endl;	

		/* Compute PID */
		//pid.Compute();

		///* Adjust byte vector and send it to the FCU */
		//if ((speed[0] >= 1476) && (((uint16_t)Output) < 1476)) {
		//	speed[0] = (uint16_t)1476;
		//	fcu.setMotors(speed);
		//	std::this_thread::sleep_for(std::chrono::seconds(1));
		//}
		//else if ((speed[0] <= 1476) && (((uint16_t)Output) > 1476)) {
		//	speed[0] = (uint16_t)1476;
		//	fcu.setMotors(speed);
		//	std::this_thread::sleep_for(std::chrono::seconds(1));
		//}
		//speed[0] = (uint16_t)Output;
		//fcu.setMotors(speed);

		/* If user prompts, change setpoint */
		if (_kbhit()) {
			float prompt;
			std::cout << "What is your new setpoint?" << std::endl;
			while (!(std::cin >> prompt)) {
				std::cin.clear();
				std::cin.ignore(1000, '\n');
				std::cout << "Invalid input. Please enter a float between -3.5 and 3.5." << std::endl;
			}
			fcu.setOrientation(0, 0);
		}
	}
}

