#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>

#include <platform.h>

#include "build/build_config.h"
#include "build/debug.h"

#include "common/axis.h"
#include "common/maths.h"
#include "common/filter.h"

#include "config/config_reset.h"
#include "pg/pg.h"
#include "pg/pg_ids.h"

#include "drivers/sound_beeper.h"
#include "drivers/time.h"

#include "fc/fc_core.h"
#include "fc/fc_rc.h"

#include "fc/rc_controls.h"
#include "fc/runtime_config.h"

#include "flight/control.h"
#include "flight/imu.h"
#include "flight/mixer.h"

#include "io/gps.h"

#include "sensors/gyro.h"
#include "sensors/acceleration.h"

float rightAscention, declination;

PG_REGISTER_ARRAY_WITH_RESET_FN(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles, PG_CONTROL_PROFILE, 2);

void resetControlProfile(controlProfile_t *controlProfile)
{
	RESET_CONFIG(controlProfile_t, controlProfile,
		.rA = 0.0,
		.d = 0.0
	);
}

void pgResetFn_controlProfiles(controlProfile_t *controlProfiles)
{
	for (int i = 0; i < MAX_PROFILE_COUNT; i++) {
		resetControlProfile(&controlProfiles[i]);
	}
}

void controlInitPosition(const controlProfile_t *controlProfile)
{
	rightAscention = controlProfile->rA;
	declination = controlProfile->d;
}

void controlInit(const controlProfile_t *controlProfile)
{
	controlInitPosition(controlProfile);
}