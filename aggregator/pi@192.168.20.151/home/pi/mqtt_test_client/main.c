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
	char direction;
} COMMAND;



typedef struct config  {
	const char* serialPort;
	int buad;
	const char* mqttServer;
	const char* CLIENTID;
	char* name;
	COMMAND **commands;
	int commandsLength;
} CONFIGURATION;

CONFIGURATION configuration;

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


void init_serial(int *fd) {
	struct termios toptions;
	/* open serial port */
	*fd = open(configuration.serialPort, O_RDWR | O_NOCTTY);
	printf("fd opened as %i\n", *fd);

	/* wait for the Arduino to reboot */
	usleep(3500000);

	/* get current serial port settings */
	tcgetattr(*fd, &toptions);
	/* set 9600 baud both ways */
	cfsetispeed(&toptions, configuration.buad);
	cfsetospeed(&toptions, configuration.buad);
	/* 8 bits, no parity, no stop bits */
	toptions.c_cflag &= ~PARENB;
	toptions.c_cflag &= ~CSTOPB;
	toptions.c_cflag &= ~CSIZE;
	toptions.c_cflag |= CS8;
	/* Canonical mode */
	toptions.c_lflag |= ICANON;
	/* commit the serial port settings */
	tcsetattr(*fd, TCSANOW, &toptions);
}


int msgarrvd(void *context, char *topicName, int topicLen, MQTTClient_message *message)
{
	int i;
	char* payloadptr;
	printf("Message arrived\n");
	printf("     topic: %s\n", topicName);
	printf("   message: ");


	for (int i = 0; i < configuration.commandsLength; i++) {
		//  printf("||comparing with %s||", commands[i]->MQTT_Topic);
		if (strcmp(configuration.commands[i]->MQTT_Topic , topicName) == 0) {

			write(fd, configuration.commands[i]->serialKey,  strlen(configuration.commands[i]->serialKey));
			write(fd, ":", 1);

			write(fd, message->payload, message->payloadlen);
			write(fd, "/n", 1);
			break;
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

void init_mqtt(MQTTClient *client) {

	MQTTClient_connectOptions conn_opts = MQTTClient_connectOptions_initializer;
	int rc;
	MQTTClient_create(client, configuration.mqttServer, configuration.CLIENTID,
	MQTTCLIENT_PERSISTENCE_NONE, NULL);
	conn_opts.keepAliveInterval = 20;
	conn_opts.cleansession = 1;
	MQTTClient_setCallbacks(*client, NULL, connlost, msgarrvd, delivered);
	if ((rc = MQTTClient_connect(*client, &conn_opts)) != MQTTCLIENT_SUCCESS)
	{
		printf("Failed to connect, return code %d\n", rc);
		exit(EXIT_FAILURE);
	}

	for (int i = 0 ; i < configuration.commandsLength ; i++) {
		if (configuration.commands[i]->direction == '<') {
			printf("Subscribing to topic %s for client %s using QoS%d\n"
			, configuration.commands[i]->MQTT_Topic, "arduino", configuration.commands[i]->QOS);
			
			MQTTClient_subscribe(*client,  configuration.commands[i]->MQTT_Topic, configuration.commands[i]->QOS);
		}
	}
}

void init_commands(config_t *cfg) {

	const char *str;
	/* Get the store name. */
	if (config_lookup_string(cfg, "name", &str))
	printf("aggregator: %s\n\n", str);
	else
	fprintf(stderr, "No 'name' setting in configuration file.\n");

	config_setting_t *setting;
	//load setting
	setting = config_lookup(cfg, "settings");
	if (setting != NULL)
	{
		printf("Settings \n");
		if (config_setting_lookup_string(setting, "serial", &configuration.serialPort))
		printf("%-30s",     configuration.serialPort);

		if ( config_setting_lookup_string(setting, "CLIENTID", &configuration.CLIENTID))
		printf("%-30s",     configuration.CLIENTID);

		if ( config_setting_lookup_string(setting, "mqttServer", &configuration.mqttServer))
		printf("%-30s",     configuration.mqttServer);

		if ( config_setting_lookup_int(setting, "buad", &configuration.buad))
		printf("%-30d",     configuration.buad);

		putchar('\n');
	}

	setting = config_lookup(cfg, "config");

	COMMAND** temp_commands;

	if (setting != NULL)
	{
		int count = config_setting_length(setting);
		configuration.commandsLength = count;

		temp_commands = malloc(count * sizeof(COMMAND*));

		for (int i = 0 ; i < count; i++) {
			temp_commands[i] =  malloc(sizeof(COMMAND));
		}
		int i;
		printf("%-30s  %-30s   %-6s\n", "serialKey", "MQTT_Topic", "QOS");
		for (i = 0; i < count; ++i)
		{
			config_setting_t *config = config_setting_get_elem(setting, i);

			/* Only output the record if all of the expected fields are present. */
			const char *serialKey, *MQTT_Topic, *direction;
			int QOS ;

			if (config_setting_lookup_string(config, "serialKey", &serialKey)
					&& config_setting_lookup_string(config, "MQTT_Topic", &MQTT_Topic)
					&& config_setting_lookup_int(config, "QOS", &QOS)
					&& config_setting_lookup_string(config, "direction", &direction)) {

				temp_commands[i]->serialKey = malloc(strlen(serialKey) + 1); //nullchar
				stpcpy(temp_commands[i]->serialKey, serialKey);

				temp_commands[i]->MQTT_Topic = malloc(strlen(MQTT_Topic) + 1);
				stpcpy(temp_commands[i]->MQTT_Topic, MQTT_Topic);

				temp_commands[i]->QOS = QOS;
				temp_commands[i]->direction = direction[0];
				printf("%-30s  %-30s  %3d\n",
				temp_commands[i]->serialKey, temp_commands[i]->MQTT_Topic, temp_commands[i]->QOS);
			}
		}


		configuration.commands = temp_commands;
	}
}

int main(int argc, char **argv)
{
	config_t cfg;
	config_init(&cfg);
	/* Read the file. If there is an error, report it and exit. 
	"/opt/tp/example.cfg" */
	
	if (argc !=2){
		printf("usage ./aggregator /path/to/config")
	return (EXIT_FAILURE);
	}
		
	if (! config_read_file(&cfg,argv[1] ))
	{
		fprintf(stderr, "%s:%d - %s\n", config_error_file(&cfg),
		config_error_line(&cfg), config_error_text(&cfg));
		config_destroy(&cfg);
		return (EXIT_FAILURE);
	}

	init_commands(&cfg);

	//serial setup
	int n;
	char buf[64] = "temp text";
	init_serial(&fd);

	/* Send byte to trigger Arduino to send string back */
	write(fd, "led1:H\n", 7);
	write(fd, "\n", 1);

	MQTTClient client;
	init_mqtt(&client);

	printf("Press Q<Enter> to quit\n\n");
	// char ch;
	do
	{
		putchar('\n');
		/* Receive string from Arduino */
		n = read(fd, buf, 64);
		/* insert terminating zero in the string */
		buf[n] = 0;
		//check for correct message
		//commmand:payload\n
		if (buf[n-1] != '\n'){
			printf("Bad Message '\\n' not found command:payload\n%s\n", buf);
			continue; //not found
		}
		
	//	printf("%i bytes read, buffer contains: %s", n, buf);
		char* delim = strchr(buf, ':');
		
		if (delim == NULL){
			printf("Bad Message ':' not found command:payload\n%s\n", buf);
			continue; //not found
		}
		int index = (int)(delim - buf);
		
		buf[index] = 0;
		for (int i = 0; i < configuration.commandsLength; i++) {
			if (configuration.commands[i]->direction == '>') {
			  printf("comparing |%s| with |%s| for %s\n sending %s\n",
			  buf, configuration.commands[i]->serialKey, 
			  configuration.commands[i]->MQTT_Topic,
			   &buf[index+1]);
			
			
				if (strcmp(configuration.commands[i]->serialKey , buf) == 0) {

					MQTTClient_message pubmsg = MQTTClient_message_initializer;
					MQTTClient_deliveryToken token;
					pubmsg.payload = &buf[index+1];
					pubmsg.payloadlen = strlen(pubmsg.payload) - 1;
					pubmsg.qos = 0;
					pubmsg.retained = 0;
					MQTTClient_publishMessage(client, 
						configuration.commands[i]->MQTT_Topic, &pubmsg, &token);
					
					break;
				}
			}
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