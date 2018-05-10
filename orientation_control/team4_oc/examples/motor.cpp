// team4_oc.cpp : Defines the entry point for the console application.

// Moving motors and adjusting speed on keyboard input using a switch case
// Testing MSP 

#include <iostream>
#include <msp_id.hpp>
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
		std::cout << "Right Ascention is " << attitude.heading-180 << " and the declination is " << attitude.ang_y << std::endl;
	}

	void onHello(const msp::msg::Hello& hello) {
		std::cout << hello.message << std::endl;
	}

	void onRc(const msp::msg::Rc& rc) {
		std::cout << rc << std::endl;
	}

	void onGetPID(const msp::msg::GetPID& pid) {
		std::cout << pid.kp << " " << pid.ki << " " << pid.kd<< std::endl;
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

	fcu::FlightController fcu(device, baudrate);
	fcu.initialise();

	App app("MultiWii", 512.0, 1.0 / 4.096, 0.92f / 10.0f, 9.80665f);
	fcu.subscribe(&App::onGetPID, &app, 0.1);
	//fcu.subscribe(&App::onAttitude, &app, 0.1);

	while (true) {
		/* If user prompts, change setpoint */
		if (_kbhit()) {
			fcu.unsubscribe(msp::ID::MSP_GET_PID_METR);
			//fcu.unsubscribe(msp::ID::MSP_ATTITUDE);
			float prompt1, prompt2, prompt3;
			std::cout << "What is your new desired right ascention?" << std::endl;
			while (!(std::cin >> prompt1)) {
				std::cin.clear();
				std::cin.ignore(1000, '\n');
				std::cout << "Invalid input. Please enter a float between 0 and 7." << std::endl;
			}
			std::cout << "What is your new desired declination?" << std::endl;
			while (!(std::cin >> prompt2)) {
				std::cin.clear();
				std::cin.ignore(1000, '\n');
				std::cout << "Invalid input. Please enter a float between 0 and 23." << std::endl;
			}
			std::cout << "What is your newefopa?" << std::endl;
			while (!(std::cin >> prompt3)) {
				std::cin.clear();
				std::cin.ignore(1000, '\n');
				std::cout << "Invalid input. Please enter a float between 0 and 23." << std::endl;
			}
			fcu.setPID(prompt1*10, prompt2*10, prompt3*10);
			fcu.subscribe(&App::onGetPID, &app, 0.1);
			//fcu.subscribe(&App::onAttitude, &app, 0.1);
		}
	}
}

