/*
* This file is part of Cleanflight.
*
* Cleanflight is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* Cleanflight is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with Cleanflight.  If not, see <http://www.gnu.org/licenses/>.
*/

// Inertial Measurement Unit (IMU)

#include <stdbool.h>
#include <stdint.h>
#include <math.h>

#include "platform.h"

#include "build/build_config.h"
#include "build/debug.h"

#include "common/axis.h"

#include "pg/pg.h"
#include "pg/pg_ids.h"

#include "drivers/time.h"

#include "fc/runtime_config.h"

#include "flight/imu.h"
#include "flight/kalman.h"  // Source: https://github.com/TKJElectronics/KalmanFilter
#include "flight/mixer.h"
#include "flight/pid.h"

#include "io/gps.h"

#include "sensors/acceleration.h"
#include "sensors/barometer.h"
#include "sensors/compass.h"
#include "sensors/gyro.h"
#include "sensors/sensors.h"

Kalman kalmanX, kalmanY, kalmanZ; // Create the Kalman instances

double gyroX, gyroY, gyroZ;
double magX, magY, magZ;

double roll, pitch, yaw; // Roll and pitch are calculated using the gyro while yaw is calculated using the magnetometer

double gyroXangle, gyroYangle, gyroZangle; // Angle calculate using the gyro only
double compAngleX, compAngleY, compAngleZ; // Calculated angle using a complementary filter
double kalAngleX, kalAngleY, kalAngleZ; // Calculated angle using a Kalman filter

void setup() {
	updatePitchRoll();
	updateYaw();

	kalmanX.setAngle(roll); // First set roll starting angle
	gyroXangle = roll;
	compAngleX = roll;

	kalmanY.setAngle(pitch); // Then pitch
	gyroYangle = pitch;
	compAngleY = pitch;

	kalmanZ.setAngle(yaw); // And finally yaw
	gyroZangle = yaw;
	compAngleZ = yaw;

	timer = micros(); // Initialize the timer
}

void loop() {

	double dt = (double)(micros() - timer) / 1000000; // Calculate delta time
	timer = micros();


	/* Roll and pitch estimation */
	updatePitchRoll();
	double gyroXrate = gyroX / 131.0; // Convert to deg/s
	double gyroYrate = gyroY / 131.0; // Convert to deg/s

#ifdef RESTRICT_PITCH
									  // This fixes the transition problem when the accelerometer angle jumps between -180 and 180 degrees
	if ((roll < -90 && kalAngleX > 90) || (roll > 90 && kalAngleX < -90)) {
		kalmanX.setAngle(roll);
		compAngleX = roll;
		kalAngleX = roll;
		gyroXangle = roll;
	}
	else
		kalAngleX = kalmanX.getAngle(roll, gyroXrate, dt); // Calculate the angle using a Kalman filter

	if (abs(kalAngleX) > 90)
		gyroYrate = -gyroYrate; // Invert rate, so it fits the restricted accelerometer reading
	kalAngleY = kalmanY.getAngle(pitch, gyroYrate, dt);
#else
									  // This fixes the transition problem when the accelerometer angle jumps between -180 and 180 degrees
	if ((pitch < -90 && kalAngleY > 90) || (pitch > 90 && kalAngleY < -90)) {
		kalmanY.setAngle(pitch);
		compAngleY = pitch;
		kalAngleY = pitch;
		gyroYangle = pitch;
	}
	else
		kalAngleY = kalmanY.getAngle(pitch, gyroYrate, dt); // Calculate the angle using a Kalman filter

	if (abs(kalAngleY) > 90)
		gyroXrate = -gyroXrate; // Invert rate, so it fits the restricted accelerometer reading
	kalAngleX = kalmanX.getAngle(roll, gyroXrate, dt); // Calculate the angle using a Kalman filter
#endif


													   /* Yaw estimation */
	updateYaw();
	double gyroZrate = gyroZ / 131.0; // Convert to deg/s
									  // This fixes the transition problem when the yaw angle jumps between -180 and 180 degrees
	if ((yaw < -90 && kalAngleZ > 90) || (yaw > 90 && kalAngleZ < -90)) {
		kalmanZ.setAngle(yaw);
		compAngleZ = yaw;
		kalAngleZ = yaw;
		gyroZangle = yaw;
	}
	else
		kalAngleZ = kalmanZ.getAngle(yaw, gyroZrate, dt); // Calculate the angle using a Kalman filter


														  /* Estimate angles using gyro only */
	gyroXangle += gyroXrate * dt; // Calculate gyro angle without any filter
	gyroYangle += gyroYrate * dt;
	gyroZangle += gyroZrate * dt;
	//gyroXangle += kalmanX.getRate() * dt; // Calculate gyro angle using the unbiased rate from the Kalman filter
	//gyroYangle += kalmanY.getRate() * dt;
	//gyroZangle += kalmanZ.getRate() * dt;

	/* Estimate angles using complimentary filter */
	compAngleX = 0.93 * (compAngleX + gyroXrate * dt) + 0.07 * roll; // Calculate the angle using a Complimentary filter
	compAngleY = 0.93 * (compAngleY + gyroYrate * dt) + 0.07 * pitch;
	compAngleZ = 0.93 * (compAngleZ + gyroZrate * dt) + 0.07 * yaw;

	// Reset the gyro angles when they has drifted too much
	if (gyroXangle < -180 || gyroXangle > 180)
		gyroXangle = kalAngleX;
	if (gyroYangle < -180 || gyroYangle > 180)
		gyroYangle = kalAngleY;
	if (gyroZangle < -180 || gyroZangle > 180)
		gyroZangle = kalAngleZ;


	/* Print Data */
#if 1
	Serial.print(roll); Serial.print("\t");
	Serial.print(gyroXangle); Serial.print("\t");
	Serial.print(compAngleX); Serial.print("\t");
	Serial.print(kalAngleX); Serial.print("\t");

	Serial.print("\t");

	Serial.print(pitch); Serial.print("\t");
	Serial.print(gyroYangle); Serial.print("\t");
	Serial.print(compAngleY); Serial.print("\t");
	Serial.print(kalAngleY); Serial.print("\t");

	Serial.print("\t");

	Serial.print(yaw); Serial.print("\t");
	Serial.print(gyroZangle); Serial.print("\t");
	Serial.print(compAngleZ); Serial.print("\t");
	Serial.print(kalAngleZ); Serial.print("\t");
#endif
#if 0 // Set to 1 to print the IMU data
	Serial.print(accX / 16384.0); Serial.print("\t"); // Converted into g's
	Serial.print(accY / 16384.0); Serial.print("\t");
	Serial.print(accZ / 16384.0); Serial.print("\t");

	Serial.print(gyroXrate); Serial.print("\t"); // Converted into degress per second
	Serial.print(gyroYrate); Serial.print("\t");
	Serial.print(gyroZrate); Serial.print("\t");

	Serial.print(magX); Serial.print("\t"); // After gain and offset compensation
	Serial.print(magY); Serial.print("\t");
	Serial.print(magZ); Serial.print("\t");
#endif
#if 0 // Set to 1 to print the temperature
	Serial.print("\t");

	double temperature = (double)tempRaw / 340.0 + 36.53;
	Serial.print(temperature); Serial.print("\t");
#endif

	Serial.println();

	delay(10);
}

void updatePitchRoll() {
	// Source: http://www.freescale.com/files/sensors/doc/app_note/AN3461.pdf eq. 25 and eq. 26
	// atan2 outputs the value of -ƒÎ to ƒÎ (radians) - see http://en.wikipedia.org/wiki/Atan2
	// It is then converted from radians to degrees
#ifdef RESTRICT_PITCH // Eq. 25 and 26
	roll = atan2(accY, accZ) * RAD_TO_DEG;
	pitch = atan(-accX / sqrt(accY * accY + accZ * accZ)) * RAD_TO_DEG;
#else // Eq. 28 and 29
	roll = atan(accY / sqrt(accX * accX + accZ * accZ)) * RAD_TO_DEG;
	pitch = atan2(-accX, accZ) * RAD_TO_DEG;
#endif
}

void updateYaw() { // See: http://www.freescale.com/files/sensors/doc/app_note/AN4248.pdf
	magX *= -1; // Invert axis - this it done here, as it should be done after the calibration
	magZ *= -1;

	magX *= magGain[0];
	magY *= magGain[1];
	magZ *= magGain[2];

	magX -= magOffset[0];
	magY -= magOffset[1];
	magZ -= magOffset[2];

	double rollAngle = kalAngleX * DEG_TO_RAD;
	double pitchAngle = kalAngleY * DEG_TO_RAD;

	double Bfy = magZ * sin(rollAngle) - magY * cos(rollAngle);
	double Bfx = magX * cos(pitchAngle) + magY * sin(pitchAngle) * sin(rollAngle) + magZ * sin(pitchAngle) * cos(rollAngle);
	yaw = atan2(-Bfy, Bfx) * RAD_TO_DEG;

	yaw *= -1;
}


