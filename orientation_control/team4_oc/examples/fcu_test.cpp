#include <FlightController.hpp>
#include <msp_msg.hpp>
#include <msg_print.hpp>
#include <math.h>

#include <iostream>

float mag[3], gyro_heading;


class App {
public:
    std::string name;

    App(const std::string name, const float acc_1g, const float gyro_unit, const float magn_gain, const float si_unit_1g) : acc_1g(acc_1g), gyro_unit(gyro_unit), magn_gain(magn_gain), si_unit_1g(si_unit_1g) {
        this->name = name;
    }

    void onImu(const msp::msg::ImuRaw& imu_raw) {
		//std::cout << "Mag x: " << imu_raw.magn[0] << "Mag y: " << imu_raw.magn[1] << "Mag z: " << imu_raw.magn[2] << std::endl;
		//float mag_heading = atan2(imu_raw.magn[1], imu_raw.magn[0]) * (180 / M_PI);
		float mag_tilt = atan2(imu_raw.magn[2], sqrt(imu_raw.magn[0]* imu_raw.magn[0] + imu_raw.magn[1]* imu_raw.magn[1])) * (180 / M_PI);

		for (int i = 0; i < 3; i++) {
			if (imu_raw.magn[i] <= 3000) {
				mag[i] = imu_raw.magn[i];
			}
			else {
				mag[i] = -1 * (5000 - imu_raw.magn[i]);
			}
		}

		float mag_heading = atan2(mag[1], mag[0]) * (180 / M_PI);

		gyro_heading += imu_raw.gyro[2] * 0.1;
		//std::cout << "Mag x: " << mag[0] << "Mag y: " << mag[1] << "Mag z: " << mag[2] << std::endl;
		//heading = mag_y / mag_x;
		//dest = tan(3.5 * M_PI / 180.0);

		std::cout << mag_heading << std::endl; 
		/*if (heading - dest < 0) {
			std::cout << "Turn left" << std::endl;
		}
		else {
			std::cout << "Turn right" << std::endl;
		}
		if (fabs(dest - heading) < 0.01) {
			std::cout << "You are at your destination faggot" << std::endl;
		}*/

		float T = 0.09;
		float complimentary = (T / T + 0.1) * (gyro_heading) + (0.1 / T + 0.1) * (mag_heading);
		//std::cout << complimentary << std::endl;
    }

	void onAttitude(const msp::msg::Attitude& attitude) {
		std::cout << "Right Ascention is " << attitude.heading - 180 << " and the declination is " << attitude.ang_y << std::endl;
	}

private:
    const float acc_1g;
    const float gyro_unit;
    const float magn_gain;
    const float si_unit_1g;
};

int main(int argc, char *argv[]) {
    const std::string device = (argc>1) ? std::string(argv[1]) : "/dev/ttyUSB0";
    const size_t baudrate = (argc>2) ? std::stoul(argv[2]) : 115200;

    fcu::FlightController fcu(device, baudrate);

    // wait for connection
    fcu.initialise();

    App app("MultiWii", 512.0, 0.06106870229, 0.92f/10.0f, 9.80665f);

    fcu.subscribe(&App::onImu, &app, 0.1);
	std::cin.get();

}
