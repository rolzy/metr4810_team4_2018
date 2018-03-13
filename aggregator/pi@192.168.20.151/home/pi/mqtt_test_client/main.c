/* ----------------------------------------------------------------------------
   Aggigator v1
   Bradley King
   10/02/2018
   ----------------------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>
#include <libconfig.h>


//serial
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <stdint.h>
#include <fcntl.h>
#include <termios.h>
#include <errno.h>
#include <sys/ioctl.h>

#define DEBUG 1

//daemon
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <string.h>

//mqtt
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "MQTTClient.h"
#define TIMEOUT     10000L

//will allocate memory at runtime.
typedef struct command {
	char* serialKey;
	char* MQTT_Topic;
	char QOS;
}COMMAND;

COMMAND *commands; 


volatile MQTTClient_deliveryToken deliveredtoken;

void delivered(void *context, MQTTClient_deliveryToken dt)
{
  printf("Message with token value %d delivery confirmed\n", dt);
  deliveredtoken = dt;
}

void connlost(void *context, char *cause)
{
  printf("\nConnection lost\n");
  printf("     cause: %s\n", cause);
}

int fd;


void init_serial(int *fd, struct termios *toptions) {

  /* open serial port */
  *fd = open("/dev/ttyUSB0", O_RDWR | O_NOCTTY);
  printf("fd opened as %i\n", *fd);

  /* wait for the Arduino to reboot */
  usleep(3500000);

  /* get current serial port settings */
  tcgetattr(*fd, toptions);
  /* set 9600 baud both ways */
  cfsetispeed(toptions, B9600);
  cfsetospeed(toptions, B9600);
  /* 8 bits, no parity, no stop bits */
  toptions->c_cflag &= ~PARENB;
  toptions->c_cflag &= ~CSTOPB;
  toptions->c_cflag &= ~CSIZE;
  toptions->c_cflag |= CS8;
  /* Canonical mode */
  toptions->c_lflag |= ICANON;
  /* commit the serial port settings */
  tcsetattr(*fd, TCSANOW, toptions);
}


int msgarrvd(void *context, char *topicName, int topicLen, MQTTClient_message *message)
{
  int i;
  char* payloadptr;
  printf("Message arrived\n");
  printf("     topic: %s\n", topicName);
  printf("   message: ");

  
  
  for (int i =0; i<4; i++) {
	if (strcmp(commands[i].MQTT_Topic , topicName) ==0) {
		
	write(fd,commands[i].serialKey, 5);
	write(fd,":", 1);
	
  write(fd, message->payload, message->payloadlen);
  write(fd, "\n", 1);

	}
  }

  payloadptr = message->payload;
  for (i = 0; i < message->payloadlen; i++)
  {
    putchar(*payloadptr++);
  }
  putchar('\n');
  MQTTClient_freeMessage(&message);
  MQTTClient_free(topicName);
  return 1;
}

void init_mqtt(MQTTClient *client, config_t *cfg) {

  config_setting_t *setting;
  //load setting
  setting = config_lookup(cfg, "settings");
  if (setting != NULL)
  {
    /* Only output the record if all of the expected fields are present. */
    const char *serial, *CLIENTID, *mqttServer;

    if (config_setting_lookup_string(setting, "serial", &serial)
        && config_setting_lookup_string(setting, "CLIENTID", &CLIENTID)
        && config_setting_lookup_string(setting, "mqttServer", &mqttServer))

      printf("Settings \n%-30s  %-30s  %-30s\n", serial, CLIENTID , mqttServer);

    putchar('\n');


    MQTTClient_connectOptions conn_opts = MQTTClient_connectOptions_initializer;
    int rc;
    MQTTClient_create(client, mqttServer, CLIENTID,
                      MQTTCLIENT_PERSISTENCE_NONE, NULL);
    conn_opts.keepAliveInterval = 20;
    conn_opts.cleansession = 1;
    MQTTClient_setCallbacks(*client, NULL, connlost, msgarrvd, delivered);
    if ((rc = MQTTClient_connect(*client, &conn_opts)) != MQTTCLIENT_SUCCESS)
    {
      printf("Failed to connect, return code %d\n", rc);
      exit(EXIT_FAILURE);
    }

  }

}


void init_commands(COMMAND** Commands, config_t *cfg, MQTTClient client){
	  config_setting_t *setting;
	 setting = config_lookup(cfg, "config");
  if (setting != NULL)
  {
    int count = config_setting_length(setting);
	Commands = malloc(count*sizeof(COMMAND*));
	
	for (int i =0 ; i<count;i++){
		Commands[i] =  malloc(sizeof(COMMAND));
	}
	
    int i;

    printf("%-30s  %-30s   %-6s\n", "serialKey", "MQTT_Topic", "QOS");

    for (i = 0; i < count; ++i)
    {
      config_setting_t *book = config_setting_get_elem(setting, i);

      /* Only output the record if all of the expected fields are present. */
      const char *serialKey, *MQTT_Topic;
      int QOS;

      if (config_setting_lookup_string(book, "serialKey", &serialKey)
            && config_setting_lookup_string(book, "MQTT_Topic", &MQTT_Topic)
            && config_setting_lookup_int(book, "QOS", &QOS)){
			
			Commands[i]->serialKey = malloc(strlen(serialKey)+1);//nullchar
			stpcpy(Commands[i]->serialKey, serialKey);
			
			Commands[i]->MQTT_Topic = malloc(strlen(MQTT_Topic)+1);
			stpcpy(Commands[i]->MQTT_Topic, MQTT_Topic);
			
			Commands[i]->QOS = QOS;
		      printf("%-30s  %-30s  %3d\n", 
			  Commands[i]->serialKey, Commands[i]->MQTT_Topic, Commands[i]->QOS);

      printf("Subscribing to topic %s for client %s using QoS%d\n"
             , MQTT_Topic, "arduino", QOS);
      MQTTClient_subscribe(client, MQTT_Topic, QOS);		
				
			}
        




    }
    
  }
	
}

int main(int argc, char **argv)
{
  config_t cfg;
  const char *str;


  //serial setup
  int n;
  char buf[64] = "temp text";
  struct termios toptions;
  init_serial(&fd, &toptions);

  /* Send byte to trigger Arduino to send string back */
  write(fd, "led1:H\n", 7);
  write(fd, "\n", 1);

  config_init(&cfg);

  /* Read the file. If there is an error, report it and exit. */
  if (! config_read_file(&cfg, "/opt/tp/example.cfg"))
  {
    fprintf(stderr, "%s:%d - %s\n", config_error_file(&cfg),
            config_error_line(&cfg), config_error_text(&cfg));
    config_destroy(&cfg);
    return (EXIT_FAILURE);
  }

  /* Get the store name. */
  if (config_lookup_string(&cfg, "name", &str))
    printf("Aggigator: %s\n\n", str);
  else
    fprintf(stderr, "No 'name' setting in configuration file.\n");

  MQTTClient client;
  init_mqtt(&client, &cfg);

  /* Output a list of all books in the inventory. */

	init_commands(&commands, &cfg,client);
  
  printf("Press Q<Enter> to quit\n\n");
 // char ch;
  do
  {
    /* Receive string from Arduino */
    n = read(fd, buf, 64);
    /* insert terminating zero in the string */
    buf[n] = 0;

    printf("%i bytes read, buffer contains: %s\n", n, buf);

    if (buf[0] == 'h') {
      MQTTClient_message pubmsg = MQTTClient_message_initializer;
      MQTTClient_deliveryToken token;
      pubmsg.payload = &buf[2];
      pubmsg.payloadlen = strlen(pubmsg.payload) - 1;
      pubmsg.qos = 0;
      pubmsg.retained = 0;
      MQTTClient_publishMessage(client, "/arduino/heartbeat", &pubmsg, &token);
    }

    // ch = getchar();
  } while (1);

  write(fd, "led1:L\n", 7);
  write(fd, "\n", 1);
  usleep(3500000);
  config_destroy(&cfg);
  return (EXIT_SUCCESS);
}

/* eof */