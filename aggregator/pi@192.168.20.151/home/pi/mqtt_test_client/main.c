/* ----------------------------------------------------------------------------
   libconfig - A library for processing structured configuration files
   Copyright (C) 2005-2018  Mark A Lindner
   This file is part of libconfig.
   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public License
   as published by the Free Software Foundation; either version 2.1 of
   the License, or (at your option) any later version.
   This library is distributed in the hope that it will be useful, but
   WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.
   You should have received a copy of the GNU Library General Public
   License along with this library; if not, see
   <http://www.gnu.org/licenses/>.
   ----------------------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>
#include <libconfig.h>


/* This example reads the configuration file 'example.cfg' and displays
 * some of its contents.
 */

int main(int argc, char **argv)
{
  config_t cfg;
  config_setting_t *setting;
  const char *str;

  
  config_init(&cfg);
  printf("1");

  /* Read the file. If there is an error, report it and exit. */
  if(! config_read_file(&cfg, "example.cfg"))
  {
    fprintf(stderr, "%s:%d - %s\n", config_error_file(&cfg),
            config_error_line(&cfg), config_error_text(&cfg));
    config_destroy(&cfg);
    return(EXIT_FAILURE);
  }

  /* Get the store name. */
  if(config_lookup_string(&cfg, "name", &str))
    printf("Aggigator: %s\n\n", str);
  else
    fprintf(stderr, "No 'name' setting in configuration file.\n");

  /* Output a list of all books in the inventory. */
  setting = config_lookup(&cfg, "config");
  if(setting != NULL)
  {
    int count = config_setting_length(setting);
    int i;

    printf("%-30s  %-30s   %-6s\n", "serialKey", "MQTT_Topic", "QOS");

    for(i = 0; i < count; ++i)
    {
      config_setting_t *book = config_setting_get_elem(setting, i);

      /* Only output the record if all of the expected fields are present. */
      const char *serialKey, *MQTT_Topic;
      int QOS;

      if(!(config_setting_lookup_string(book, "serialKey", &serialKey)
           && config_setting_lookup_string(book, "MQTT_Topic", &MQTT_Topic)
           && config_setting_lookup_int(book, "QOS", &QOS)))
        continue;

      printf("%-30s  %-30s  %3d\n", serialKey, MQTT_Topic, QOS);
    }
    putchar('\n');
  }

  config_destroy(&cfg);
  return(EXIT_SUCCESS);
}

/* eof */