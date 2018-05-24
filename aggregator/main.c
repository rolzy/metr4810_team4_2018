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

typedef struct file {
	char* filePath;
	char* MQTT_Topic;
	char QOS;
	char direction;
} FILE1;

typedef struct exec {
	char* filePath;
	char* MQTT_Topic;
	char QOS;
	char direction;
} EXEC;


typedef struct config  {
	const char* serialPort;
	int buad;
	const char* mqttServer;
	const char* CLIENTID;
	char* name;
	COMMAND **serialCommands;
	FILE1 **files;
	EXEC **execs;
	int execLength;
	int commandsLength;
	int fliesLength;
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

int fd = -1;

static char *myStrDup (char *str) {
	char *other = malloc (strlen (str) + 1);
	if (other != NULL)
	strcpy (other, str);
	return other;
}

void forkAndExecute (const char *path, char *const args[]) {
	int pid = fork();
	if (pid == -1) {
		fprintf ( stderr,
		"fork() failed: %s",
		strerror(errno)
		);		
		return;
	}
	if (pid != 0) return;
	// If pid == 0, this is the child process.
	if (execvp(path, args) == -1) {
		fprintf ( stderr,
		"execvp(%s) failed: %s",
		path, strerror(errno)
		);
		exit(-1);
	}
}    

void init_serial(int *fd) {
	if (configuration.serialPort != NULL && configuration.serialPort !=0) {
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
	} else {
		printf("No Serial Port Configured\n");
	}
}

int msgarrvd(void *context, char *topicName, int topicLen, MQTTClient_message *message){
	int i;
	char* payloadptr;
	printf("Message arrived\n");
	printf("     topic: %s\n", topicName);
	printf("   message: ");


	for (int i = 0; i < configuration.commandsLength; i++) {
		//  printf("||comparing with %s||", serialCommands[i]->MQTT_Topic);
		if (fd !=-1) { // check for serial port;	
			if (strcmp(configuration.serialCommands[i]->MQTT_Topic , topicName) == 0) {

				write(fd, configuration.serialCommands[i]->serialKey,  strlen(configuration.serialCommands[i]->serialKey));
				write(fd, ":", 1);

				write(fd, message->payload, message->payloadlen);
				write(fd, "/n", 1);
				break;
			}
		}
	}
	
	for (int i = 0; i < configuration.fliesLength; i++) {	
		if (configuration.files != NULL) {
			if (configuration.files[i]->direction == '<') {
				if (strcmp(configuration.files[i]->MQTT_Topic , topicName) == 0) {
						
				}
			}
		}	
	}
	
	//	printf("topicName:%s   %d \n ", topicName, configuration.execLength); 
	for (int i = 0; i < configuration.execLength; i++) {	
		
		if (configuration.execs != NULL) {
			// printf("||comparing with %s||", configuration.execs[i]->MQTT_Topic);
			if (strcmp(configuration.execs[i]->MQTT_Topic , topicName) == 0) {
				char inBuf[100];
				stpcpy(inBuf,configuration.execs[i]->filePath);
				strcat(inBuf, message);
				
				char *argv[100];
				int argc = 0;

				char *str = strtok (inBuf, " ");
				while (str != NULL) {
					argv[argc++] = myStrDup(str);
					str = strtok (NULL, " ");
				}
				argv[argc] = NULL;

				for (int i = 0; i < argc; i++)
				printf ("Arg #%d = '%s'\n", i, argv[i]);
				putchar ('\n');

				forkAndExecute(argv[0], argv); 
			}
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
	
	MQTTClient_willOptions lastWil = MQTTClient_willOptions_initializer;
	lastWil.topicName = "/status/agg";
	lastWil.message = "Disconnected";
	 
	conn_opts.will = &lastWil;
	conn_opts.keepAliveInterval = 20;
	conn_opts.cleansession = 1;
	MQTTClient_setCallbacks(*client, NULL, connlost, msgarrvd, delivered);
	if ((rc = MQTTClient_connect(*client, &conn_opts)) != MQTTCLIENT_SUCCESS)
	{
		printf("Failed to connect, return code %d\n", rc);
		exit(EXIT_FAILURE);
	}

	for (int i = 0 ; i < configuration.commandsLength ; i++) {
		if (configuration.serialCommands[i]->direction == '<') {
			printf("Subscribing to topic %s for client %s using QoS%d\n"
			, configuration.serialCommands[i]->MQTT_Topic, "arduino", configuration.serialCommands[i]->QOS);
			
			MQTTClient_subscribe(*client,  configuration.serialCommands[i]->MQTT_Topic, configuration.serialCommands[i]->QOS);
		}
	}
	for (int i = 0 ; i < configuration.execLength ; i++) {
		printf("Subscribing to topic %s for client %s using QoS%d\n"
		, configuration.execs[i]->MQTT_Topic, "arduino", configuration.execs[i]->QOS);		
		MQTTClient_subscribe(*client,  configuration.execs[i]->MQTT_Topic, configuration.execs[i]->QOS);
		
	}
}



void set_up_serial_commands(config_t *cfg){
	config_setting_t *setting;
	setting = config_lookup(cfg, "serial");

	if (setting != NULL)
	{	COMMAND** temp_commands;
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


		configuration.serialCommands = temp_commands;
	}
}

void set_up_file_commands(config_t *cfg){
	config_setting_t *setting;
	setting = config_lookup(cfg, "files");

	if (setting != NULL)
	{	FILE1** temp_commands;
		int count = config_setting_length(setting);
		configuration.fliesLength = count;

		temp_commands = malloc(count * sizeof(COMMAND*));

		for (int i = 0 ; i < count; i++) {
			temp_commands[i] =  malloc(sizeof(COMMAND));
		}
		int i;
		printf("%-30s  %-30s   %-6s\n", "files", "MQTT_Topic", "QOS");
		for (i = 0; i < count; ++i)
		{
			config_setting_t *config = config_setting_get_elem(setting, i);

			/* Only output the record if all of the expected fields are present. */
			const char *filePath, *MQTT_Topic, *direction;
			int QOS ;

			if (config_setting_lookup_string(config, "filePath", &filePath)
					&& config_setting_lookup_string(config, "MQTT_Topic", &MQTT_Topic)
					&& config_setting_lookup_int(config, "QOS", &QOS)
					&& config_setting_lookup_string(config, "direction", &direction)) {

				temp_commands[i]->filePath = malloc(strlen(filePath) + 1); //nullchar
				stpcpy(temp_commands[i]->filePath, filePath);

				temp_commands[i]->MQTT_Topic = malloc(strlen(MQTT_Topic) + 1);
				stpcpy(temp_commands[i]->MQTT_Topic, MQTT_Topic);

				temp_commands[i]->QOS = QOS;
				temp_commands[i]->direction = direction[0];
				printf("%-30s  %-30s  %3d\n",
				temp_commands[i]->filePath, temp_commands[i]->MQTT_Topic, temp_commands[i]->QOS);
			}
		}


		configuration.files = temp_commands;
	}
}

void set_up_exec_commands(config_t *cfg){
	config_setting_t *setting;
	setting = config_lookup(cfg, "exec");

	if (setting != NULL)
	{	EXEC** temp_commands;
		int count = config_setting_length(setting);
		configuration.execLength = count;

		temp_commands = malloc(count * sizeof(COMMAND*));

		for (int i = 0 ; i < count; i++) {
			temp_commands[i] =  malloc(sizeof(COMMAND));
		}
		int i;
		printf("%-30s  %-30s   %-6s\n", "files", "MQTT_Topic", "QOS");
		for (i = 0; i < count; ++i)
		{
			config_setting_t *config = config_setting_get_elem(setting, i);

			/* Only output the record if all of the expected fields are present. */
			const char *filePath, *MQTT_Topic;
			int QOS ;

			if (config_setting_lookup_string(config, "filePath", &filePath)
					&& config_setting_lookup_string(config, "MQTT_Topic", &MQTT_Topic)
					&& config_setting_lookup_int(config, "QOS", &QOS)){

				temp_commands[i]->filePath = malloc(strlen(filePath) + 1); //nullchar
				stpcpy(temp_commands[i]->filePath, filePath);

				temp_commands[i]->MQTT_Topic = malloc(strlen(MQTT_Topic) + 1);
				stpcpy(temp_commands[i]->MQTT_Topic, MQTT_Topic);

				temp_commands[i]->QOS = QOS;
				printf("%-30s  %-30s  %3d\n",
				temp_commands[i]->filePath, temp_commands[i]->MQTT_Topic, temp_commands[i]->QOS);
			}
		}
		configuration.execs = temp_commands;
	}
}


void init_commands(config_t *cfg) {

	const char *str;
	/* Get the store name. */
	if (config_lookup_string(cfg, "name", &str)){
		printf("aggregator: %s\n\n", str);
	}else{
		fprintf(stderr, "No 'name' setting in configuration file.\n");
	}
	
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

	set_up_serial_commands(cfg);
	set_up_file_commands(cfg);
	set_up_exec_commands(cfg);
		
}


void process_serial(MQTTClient client,char* buf){
	int n;
	putchar('\n');
	/* Receive string from Arduino */
	n = read(fd, buf, 64);
	/* insert terminating zero in the string */
	buf[n] = 0;
	//check for correct message
	//commmand:payload\n
	if (buf[n-1] != '\n'){
		printf("Bad Message '\\n' not found command:payload\n%s\n", buf);
		return; //not found
	}
	
	//	printf("%i bytes read, buffer contains: %s", n, buf);
	char* delim = strchr(buf, ':');
	
	if (delim == NULL){
		printf("Bad Message ':' not found command:payload\n%s\n", buf);
		return; //not found
	}
	int index = (int)(delim - buf);
	
	buf[index] = 0;
	for (int i = 0; i < configuration.commandsLength; i++) {
		if (configuration.serialCommands[i]->direction == '>') {
			printf("comparing |%s| with |%s| for %s\n sending %s\n",
			buf, configuration.serialCommands[i]->serialKey, 
			configuration.serialCommands[i]->MQTT_Topic,
			&buf[index+1]);
			
			
			if (strcmp(configuration.serialCommands[i]->serialKey , buf) == 0) {

				MQTTClient_message pubmsg = MQTTClient_message_initializer;
				MQTTClient_deliveryToken token;
				pubmsg.payload = &buf[index+1];
				pubmsg.payloadlen = strlen(pubmsg.payload) - 1;
				pubmsg.qos = 0;
				pubmsg.retained = 0;
				MQTTClient_publishMessage(client, 
				configuration.serialCommands[i]->MQTT_Topic, &pubmsg, &token);
				
				break;
			}
		}
	}
	
}

sddsf:dfsdf

void process_files(MQTTClient client){
	for (int i = 0; i < configuration.fliesLength; i++) {	
		

		
		FILE *file;
		unsigned char *buffer;
		unsigned long fileLen;

		//Open file
		file = fopen(configuration.files[i]->filePath, "rb");	
		if (file != NULL) {
			fseek(file, 0, SEEK_END);
			fileLen=ftell(file);
			fseek(file, 0, SEEK_SET);

			//Allocate memory
			buffer=(unsigned char *)malloc(fileLen);
			if (!buffer)
			{
				fprintf(stderr, "Memory error!");
				fclose(file);
				exit(1);
			}

			fread(buffer,fileLen,sizeof(unsigned char),file);
			fclose(file);
			remove(configuration.files[i]->filePath);
			
			printf("seinding %lu bytes\n",fileLen);
			
			MQTTClient_message pubmsg = MQTTClient_message_initializer;
			MQTTClient_deliveryToken token;
			pubmsg.payload = buffer;
			pubmsg.payloadlen = fileLen-1;
			pubmsg.qos = 0;
			pubmsg.retained = 0;
			MQTTClient_publishMessage(client, 
			configuration.files[i]->MQTT_Topic, &pubmsg, &token);
			
			free(buffer);		
			
			
		}
	}
}




int main(int argc, char **argv)
{
	char* configFile;
	config_t cfg;
	config_init(&cfg);
	/* Read the file. If there is an error, report it and exit. 
	"/opt/tp/example.cfg" */
	
	if (argc ==1){
		configFile = "example.cfg";
	} else if (argc ==2){
		configFile = argv[1];
	} else{
		printf("usage ./aggregator /path/to/config");
		return (EXIT_FAILURE);
	}
	
	if (! config_read_file(&cfg, configFile))
	{
		fprintf(stderr, "%s:%d - %s\n", config_error_file(&cfg),
		config_error_line(&cfg), config_error_text(&cfg));
		config_destroy(&cfg);
		return (EXIT_FAILURE);
	}


	init_commands(&cfg);

	//serial setup

	char buf[64] = "temp text";
	init_serial(&fd);

	
	
	if (fd !=-1) {
		/* Send byte to trigger Arduino to send string back */
		write(fd, "led1:H\n", 7);
		write(fd, "\n", 1);
	}
	
	MQTTClient client;
	init_mqtt(&client);
	config_destroy(&cfg);	
	printf("Press Q<Enter> to quit\n\n");
	// char ch;
	do
	{
		if (fd !=-1) {
			process_serial(client,buf);
		}
		
		if (configuration.files !=NULL) {
			process_files(client);
		}

		// ch = getchar();
	} while (1);
	return (EXIT_SUCCESS);
}

/* eof */