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

#include <stdbool.h>
#include <stdint.h>

#include "common/maths.h"

#include "platform.h"

#include "fc/config.h"
#include "fc/fc_init.h"

#include "flight/control.h"
#include "flight/imu.h"

#include "rx/rx.h"

#include "scheduler/scheduler.h"

/* Initialize two PID structs, one for right ascention and one for declination */
struct pid_controller rightAscention;
struct pid_controller declination;

pid_t pid_1;
pid_t pid_2;

float yaw = 0.0;
float pitch = 0.0;

float setpoint_1 = 0.0;
float setpoint_2 = 0.0;

float output_1 = 0.0;
float output_2 = 0.0;

float kp_1 = 0.556, ki_1 = 1.0, kd_1 = 0.028;
float kp_2 = 0.556, ki_2 = 1.0, kd_2 = 0.028;

int main(void)
{
    init();

	/* Create two PID sessions */
	pid_1 = pid_create(&rightAscention, &yaw, &output_1, &setpoint_1, kp_1, ki_1, kd_1);
	pid_2 = pid_create(&declination, &pitch, &output_2, &setpoint_2, kp_2, ki_2, kd_2);

    while (true) {
        scheduler();
        processLoopback();
#ifdef SIMULATOR_BUILD
        delayMicroseconds_real(50); // max rate 20kHz
#endif

		/* Check if the time elapsed since last PID iteration is over the sample time */
		if (pid_need_compute(pid_1)) {
			/* Read the current orientation in radians */
			yaw = ((double)DECIDEGREES_TO_DEGREES(attitude.values.yaw)-180) * 0.0174533;
			if (yaw - setpoint_1 < 0) {
				setDirection(pid_1, E_PID_DIRECT);
			}
			else {
				setDirection(pid_1, E_PID_REVERSE);
			}
			setpoint_1 = (double)currentControlProfile->rA * 0.0174533;
			computePID(pid_1, 0);
			rcData[2] = (int)(yaw);
		}
		
		if (pid_need_compute(pid_2)) {
			pitch = (double)DECIDEGREES_TO_DEGREES(attitude.values.pitch)*-0.0174533;
			if (pitch - setpoint_2 < 0) {
				setDirection(pid_2, E_PID_DIRECT);
			}
			else {
				setDirection(pid_2, E_PID_REVERSE);
			}
			setpoint_2 = (double)currentControlProfile->d * 0.0174533;
			computePID(pid_2, 1);
			rcData[3] = (int)(pitch);
		}
    }
    return 0;
}
