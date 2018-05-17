#include <FlightController.hpp>
#include <msp_msg.hpp>
#include <msg_print.hpp>
#include <math.h>

#include <iostream>

int magSet = 0;
int phiBiasSet = 0;
float gyro_heading, magZeroLength, phiBias;
std::array<float, 3> mag, magZero;
std::array<float, 3> why = { 0,1,0 };
std::array<float, 3> zed = { 0,0,1 };
float skewZ[3][3] = {{ 0, -1, 0 },{ 1, 0, 0 },{ 0, 0, 0 }};
float skewY[3][3] = {{ 0, 0, 1 },{ 0, 0, 0 },{ -1, 0, 0 }};
float eye[3][3] = { { 1, 0, 0 },{ 0, 1, 0 },{ 0, 0, 1 } };
float prod1[3][3] = { { 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 1 } };
float prod2[3][3] = { { 0, 0, 0 },{ 0, 1, 0 },{ 0, 0, 0 } };
float rod[3][3];


float dotProduct(std::array<float, 3> vect_A, std::array<float, 3> vect_B)
{

	float product = 0.0;

	// Loop for calculate cot product
	for (int i = 0; i < 3; i++)
		product = product + vect_A[i] * vect_B[i];

	return product;
}

std::array<float, 3> crossProduct(std::array<float, 3> vect_A, std::array<float, 3> vect_B)
{
	std::array<float, 3> cross_P;
	cross_P[0] = vect_A[1] * vect_B[2] - vect_A[2] * vect_B[1];
	cross_P[1] = vect_A[0] * vect_B[2] - vect_A[2] * vect_B[0];
	cross_P[2] = vect_A[0] * vect_B[1] - vect_A[1] * vect_B[0];
	return cross_P;
}

void scalarMultiply(float matrix[3][3], float scalar)
{
	int row, column;
	for (row = 0; row < 3; ++row)
		for (column = 0; column < 3; ++column)
			matrix[row][column] *= scalar;
}

class App {
public:
    std::string name;

    App(const std::string name, const float acc_1g, const float gyro_unit, const float magn_gain, const float si_unit_1g) : acc_1g(acc_1g), gyro_unit(gyro_unit), magn_gain(magn_gain), si_unit_1g(si_unit_1g) {
        this->name = name;
    }

    void onImu(const msp::msg::ImuRaw& imu_raw) {
		for (int i = 0; i < 3; i++) {
			if (imu_raw.magn[i] <= 3000) {
				mag[i] = imu_raw.magn[i];
			}
			else {
				mag[i] = -1 * (5000 - imu_raw.magn[i]);
			}
		}

		if (magSet == 0) {
			magZero = mag;
			magZeroLength = sqrt(magZero[0] * magZero[0] + magZero[1] * magZero[1] + magZero[2] * magZero[2]);
			magZero[0] = magZero[0] / magZeroLength;
			magZero[1] = magZero[1] / magZeroLength;
			magZero[2] = magZero[2] / magZeroLength;
			magSet = 1;
		}

		float magLength = sqrt(mag[0] * mag[0] + mag[1] * mag[1] + mag[2] * mag[2]);
		mag[0] = mag[0] / magLength;
		mag[1] = mag[1] / magLength;
		mag[2] = mag[2] / magLength;

		std::array<float, 3> magZ = mag;
		magZ[2] = 0;
		std::array<float, 3> magZeroZ = magZero;
		magZeroZ[2] = 0;

		float dotZ = dotProduct(magZ, magZeroZ);
		std::array<float, 3> crossZ = crossProduct(magZ, magZeroZ);
		float theta = atan2(sqrt(crossZ[0] * crossZ[0] + crossZ[1] * crossZ[1] + crossZ[2] * crossZ[2]), dotZ);

		float refDotZ = dotProduct(crossZ, zed);

		scalarMultiply(eye, cos(theta));
		scalarMultiply(prod1, (1 - cos(theta)));
		scalarMultiply(skewZ, sin(theta));

		for (int i = 0; i<3; i++)
		{
			for (int j = 0; j<3; j++)
				rod[i][j] = eye[i][j] + prod1[i][j];
		}
		for (int i = 0; i<3; i++)
		{
			for (int j = 0; j<3; j++)
				rod[i][j] += skewZ[i][j];
		}

		for (int i = 0; i<3; i++)
		{
			for (int j = 0; j < 3; j++)
				mag[i] += mag[i] * rod[i][j];
		}

		std::array<float, 3> magY = mag;
		magY[1] = 0;
		std::array<float, 3> magZeroY = magZero;
		magZeroZ[1] = 0;

		float dotY = dotProduct(magY, magZeroY);
		std::array<float, 3> crossY = crossProduct(magY, magZeroY);
		float phi= atan2(sqrt(crossY[0] * crossY[0] + crossY[1] * crossY[1] + crossY[2] * crossY[2]), dotY);

		float refDotY = dotProduct(crossY, why);

		if (phiBiasSet == 0) {
			phiBias = phi;
			phiBiasSet = 1;
		}
		
		//std::cout << mag[0] << " " << mag[1] << " " << mag[2] << std::endl;

		if (refDotZ < 0) {
			theta *= -1;
		}
		if (refDotY < 0) {
			phi -= phiBias;
			phi *= -1;
		}
		else {
			phi -= phiBias;
		}
		std::cout << "Theta: " << theta* 57.2958 << std::endl;
		std::cout << "Phi: " << phi * 57.2958 << std::endl;

		//std::cout << imu_raw.magn[0] << std::endl;
		//float mag_heading = atan2(mag[1], mag[0]) * (180 / M_PI);
		//gyro_heading += imu_raw.gyro[2] * 0.1;
		//float T = 0.09;
		//float complimentary = (T / T + 0.1) * (gyro_heading) + (0.1 / T + 0.1) * (mag_heading);
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
