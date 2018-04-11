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

float kp_1 = 2, ki_1 = 0.005, kd_1 = 1.0;
float kp_2 = 2, ki_2 = 0.005, kd_2 = 1.0;

int main(void)
{
    init();

	pid_1 = pid_create(&rightAscention, &yaw, &output_1, &setpoint_1, kp_1, ki_1, kd_1);
	pid_2 = pid_create(&declination, &pitch, &output_2, &setpoint_2, kp_2, ki_2, kd_2);

    while (true) {
        scheduler();
        processLoopback();
#ifdef SIMULATOR_BUILD
        delayMicroseconds_real(50); // max rate 20kHz
#endif
		if (pid_need_compute(pid_1)) {
			yaw = (float)DECIDEGREES_TO_DEGREES(attitude.values.yaw);
			setpoint_1 = currentControlProfile->rA;
			computePID(pid_1);
			rcData[0] = output_1;
		}
		
		if (pid_need_compute(pid_2)) {
			pitch = (float)attitude.values.pitch;
			setpoint_2 = currentControlProfile->d;
			computePID(pid_2);
			rcData[1] = output_2;
		}
    }
    return 0;
}
