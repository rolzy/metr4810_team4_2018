// team4_oc.cpp : Defines the entry point for the console application.

// Sensor fusion to sense orientation only using magnetometer and gyro

#include <iostream>
#include <msp_msg.hpp>
#include <msg_print.hpp>
#include <FlightController.hpp>

class App {
public:
	std::string name;

	App(const std::string name, const float acc_1g, const float gyro_unit, const float magn_gain, const float si_unit_1g) : acc_1g(acc_1g), gyro_unit(gyro_unit), magn_gain(magn_gain), si_unit_1g(si_unit_1g) {
		this->name = name;
	}

	void onImu(const msp::msg::ImuRaw& imu_raw) {
		std::cout << msp::msg::ImuSI(imu_raw, acc_1g, gyro_unit, magn_gain, si_unit_1g);
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
	fcu.subscribe<msp::msg::ImuRaw>([](const msp::msg::ImuRaw& imu) {
		std::cout << msp::msg::ImuSI(imu, 512.0, 1.0 / 4.096, 0.92f / 10.0f, 9.80665f);
	}, 0.1);
}