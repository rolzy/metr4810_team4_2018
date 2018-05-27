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
		std::cout << "Right Ascention is " << attitude.heading << " and the declination is " << attitude.ang_y << std::endl;
	}


	void onRc(const msp::msg::Rc& rc) {
		std::cout << rc << std::endl;
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
	//fcu.subscribe(&App::onRc, &app, 0.1);
	fcu.subscribe(&App::onAttitude, &app, 0.1);

	while (true) {
		/* If user prompts, change setpoint */
		if (_kbhit()) {
			fcu.unsubscribe(msp::ID::MSP_ATTITUDE);
			char Choice;
			std::cout << "Enter a key (1-5)... " << std::endl;
			std::cout << "1 = Start control " << std::endl;
			std::cout << "2 = Calibrate position " << std::endl;
			std::cout << "3 = Use current orientation as origin " << std::endl;
			std::cout << "4 = Tuning PID " << std::endl;
			std::cout << "5 = Change your destination " << std::endl;
			std::cin >> Choice;
			switch (Choice) {
			case '1':
			{
				std::cout << "Starting control... " << std::endl;
				fcu.startControl(1);
				break;
			}
			case '2':
			{
				std::cout << "Calibrating... " << std::endl;
				fcu.calibrate(1);
				break;
			}
			case '3':
			{
				std::cout << "Using current orientation as origin... " << std::endl;
				fcu.readOrigin(1);
				break;
			}
			case '4':
			{
				std::cout << "Tuning PID... " << std::endl;
				float prompt1, prompt2, prompt3;
				std::cout << "Enter your new Kp" << std::endl;
				while (!(std::cin >> prompt1)) {
					std::cin.clear();
					std::cin.ignore(1000, '\n');
					std::cout << "Invalid input. " << std::endl;
				}
				std::cout << "Enter your new Kd" << std::endl;
				while (!(std::cin >> prompt2)) {
					std::cin.clear();
					std::cin.ignore(1000, '\n');
					std::cout << "Invalid input. " << std::endl;
				}
				std::cout << "Enter your new Ki" << std::endl;
				while (!(std::cin >> prompt3)) {
					std::cin.clear();
					std::cin.ignore(1000, '\n');
					std::cout << "Invalid input. " << std::endl;
				}
				fcu.setPID(prompt1 * 100, prompt2 * 100, prompt3 * 100);
				break;
			}
			case '5':
			{
				std::cout << "Changing destination... " << std::endl;
				float prompt1, prompt2;
				std::cout << "What is your new desired right ascention?" << std::endl;
				while (!(std::cin >> prompt1)) {
					std::cin.clear();
					std::cin.ignore(1000, '\n');
					std::cout << "Invalid input." << std::endl;
				}
				std::cout << "What is your new desired declination?" << std::endl;
				while (!(std::cin >> prompt2)) {
					std::cin.clear();
					std::cin.ignore(1000, '\n');
					std::cout << "Invalid input." << std::endl;
				}
				fcu.setOrientation(prompt1 * 10, prompt2 * 10);
				break;
			}
			}
			//fcu.subscribe(&App::onRc, &app, 0.1);
			fcu.subscribe(&App::onAttitude, &app, 0.1);
		}
	}
}

