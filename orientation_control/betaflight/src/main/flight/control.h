#include <stdbool.h>
#include "common/time.h"
#include "pg/pg.h"

#pragma once

typedef struct controlProfile_s {
	float rA;
	float d;
} controlProfile_t;

PG_DECLARE_ARRAY(controlProfile_t, MAX_PROFILE_COUNT, controlProfiles);

void controlInitPosition(const controlProfile_t *controlProfile);
void controlInit(const controlProfile_t *controlProfile);
