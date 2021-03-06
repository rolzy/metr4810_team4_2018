// team4_oc.cpp : Defines the entry point for the console application.

// Moving motors and adjusting speed on keyboard input using a switch case
// Testing MSP

#include <iostream>
#include <msp_id.hpp>
#include <msp_msg.hpp>
#include <msg_print.hpp>
#include <FlightController.hpp>
#include <libconfig.h>
#include "MQTTClient.h"
#include <stdio.h>
#include <sys/select.h>
#include <sys/ioctl.h>
#include <termios.h>
#include <stropts.h>
#include <string.h>
#include <fcntl.h>
#include <unistd.h>
#include <stdlib.h>

using namespace std;

typedef struct command {
	char* serialKey;
	char* MQTT_Topic;
	char QOS;
	char direction;
} COMMAND;

typedef struct config {
	const char* serialPort;
	int buad;
	const char* mqttServer;
	const char* CLIENTID;
	char* name;
	COMMAND **serialCommands;
	int execLength;
	int commandsLength;
	int fliesLength;
} CONFIGURATION;

CONFIGURATION configuration;

fcu::FlightController g_fcu("/dev/ttyUSB0", 115200);
MQTTClient client;

char buf[20];

class App {
public:
	std::string name;

	App(const std::string name, const float acc_1g, const float gyro_unit, const float magn_gain, const float si_unit_1g) : acc_1g(acc_1g), gyro_unit(gyro_unit), magn_gain(magn_gain), si_unit_1g(si_unit_1g) {
		this->name = name;
	}

	void onImu(const msp::msg::ImuRaw& imu_raw) {
		std::cout << msp::msg::ImuSI(imu_raw, acc_1g, gyro_unit, magn_gain, si_unit_1g);
	}

	void onAttitude(const msp::msg::Attitude& attitude) {
		//std::cout << "Right Ascention is " << attitude.heading - 180 << " and the declination is " << attitude.ang_y << std::endl;
		sprintf(buf, "%d:%d", attitude.heading, attitude.ang_y); 
		MQTTClient_message pubmsg = MQTTClient_message_initializer;
		MQTTClient_deliveryToken token;
		pubmsg.payload = buf;
		pubmsg.payloadlen = strlen((const char*)pubmsg.payload) - 1;
		pubmsg.qos = 0;
		pubmsg.retained = 0;
		MQTTClient_publishMessage(client,
			"/status/Pos", &pubmsg, &token);
	}

	void onRc(const msp::msg::Rc& rc) {
		std::cout << rc << std::endl;
	}

private:
	const float acc_1g;
	const float gyro_unit;
	const float magn_gain;
	const float si_unit_1g;
};

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

void forkAndExecute(const char *path, char *const args[]) {
	int pid = fork();
	if (pid == -1) {
		fprintf(stderr,
			"fork() failed: %s",
			strerror(errno)
		);
		return;
	}
	if (pid != 0) return;
	// If pid == 0, this is the child process.
	if (execvp(path, args) == -1) {
		fprintf(stderr,
			"execvp(%s) failed: %s",
			path, strerror(errno)
		);
		exit(-1);
	}
}

int fd = -1;

void init_serial(int *fd) {
	if (configuration.serialPort != NULL && configuration.serialPort != 0) {
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
	else {
		printf("No Serial Port Configured\n");
	}
}

void process_serial(MQTTClient client, char* buf) {
	int n;
	putchar('\n');
	/* Receive string from Arduino */
	n = read(fd, buf, 64);
	/* insert terminating zero in the string */
	buf[n] = 0;
	//check for correct message
	//commmand:payload\n
	if (buf[n - 1] != '\n') {
		printf("Bad Message '\\n' not found command:payload\n%s\n", buf);
		return; //not found
	}

	//	printf("%i bytes read, buffer contains: %s", n, buf);
	char* delim = strchr(buf, ':');

	if (delim == NULL) {
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
				&buf[index + 1]);


			if (strcmp(configuration.serialCommands[i]->serialKey, buf) == 0) {

				MQTTClient_message pubmsg = MQTTClient_message_initializer;
				MQTTClient_deliveryToken token;
				pubmsg.payload = &buf[index + 1];
				pubmsg.payloadlen = strlen((const char*)pubmsg.payload) - 1;
				pubmsg.qos = 0;
				pubmsg.retained = 0;
				MQTTClient_publishMessage(client,
					configuration.serialCommands[i]->MQTT_Topic, &pubmsg, &token);

				break;
			}
		}
	}

}

int msgarrvd(void *context, char *topicName, int topicLen, MQTTClient_message *message) {
	int i;
	double coords[2];
	double pidConstants[3];
	char *payloadptr, **ap, *token[2];
	char *payloadCopy = strdup((char*)message->payload);

	printf("Message arrived\n");
	printf("     topic: %s\n", topicName);
	printf("   message: ");


	for (int i = 0; i < configuration.commandsLength; i++) {
		//  printf("||comparing with %s||", serialCommands[i]->MQTT_Topic);
		if (fd != -1) { // check for serial port;
			if (strcmp(configuration.serialCommands[i]->MQTT_Topic, topicName) == 0) {

				write(fd, configuration.serialCommands[i]->serialKey, strlen(configuration.serialCommands[i]->serialKey));
				write(fd, ":", 1);
				write(fd, message->payload, message->payloadlen);
				write(fd, "/n", 1);
				break;
			}
		}
	}
	payloadptr = (char*)message->payload;
	for (i = 0; i < message->payloadlen; i++)
	{
		putchar(*payloadptr++);
	}
	putchar('\n');

	/* Act accordingly for different messages */

	if (strcmp(topicName, "/control/Pos") == 0) {
		for(ap=token; (*ap = strsep(&payloadCopy,":")) != NULL;) {
			if (**ap != '\0') {
				++ap;
			}
		}
		*ap = NULL;
		for(int i=0; i<2; i++) {
			coords[i] = atof(token[i]) + 45;
		}
		g_fcu.setOrientation(coords[0]*10, coords[1]*10);
	}
	else if (strcmp(topicName, "/control/Pid") == 0) {
		for (ap = token; (*ap = strsep(&payloadCopy, ":")) != NULL;) {
			if (**ap != '\0') {
				++ap;
			}
		}
		*ap = NULL;
		for (int i = 0; i<3; i++) {
			pidConstants[i] = atof(token[i]);
		}
		g_fcu.setPID(pidConstants[0] * 100, pidConstants[1] * 100, pidConstants[2] * 100);
	}
	else if (strcmp(topicName, "/control/Start") == 0) {
		g_fcu.startControl(1);
	}
	else if (strcmp(topicName, "/control/Calibrate") == 0) {
		g_fcu.calibrate(1);
	}
	else if (strcmp(topicName, "/control/Read") == 0) {
		g_fcu.readOrigin(1);
	}
	else if (strcmp(topicName, "/control/CalMag") == 0) {
		g_fcu.calMag();
	}
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
	lastWil.topicName = "/lastWil/agg";
	lastWil.message = configuration.name;

	conn_opts.will = &lastWil;
	conn_opts.keepAliveInterval = 20;
	conn_opts.cleansession = 1;
	MQTTClient_setCallbacks(*client, NULL, connlost, msgarrvd, delivered);
	if ((rc = MQTTClient_connect(*client, &conn_opts)) != MQTTCLIENT_SUCCESS)
	{
		printf("Failed to connect, return code %d\n", rc);
		exit(EXIT_FAILURE);
	}

	for (int i = 0; i < configuration.commandsLength; i++) {
		if (configuration.serialCommands[i]->direction == '<') {
			printf("Subscribing to topic %s for client %s using QoS%d\n"
				, configuration.serialCommands[i]->MQTT_Topic, "", configuration.serialCommands[i]->QOS);

			MQTTClient_subscribe(*client, configuration.serialCommands[i]->MQTT_Topic, configuration.serialCommands[i]->QOS);
		}
	}
}

void set_up_serial_commands(config_t *cfg) {
	config_setting_t *setting;
	setting = config_lookup(cfg, "serial");

	if (setting != NULL)
	{
		COMMAND** temp_commands;
		int count = config_setting_length(setting);
		configuration.commandsLength = count;

		temp_commands = (COMMAND**)malloc(count * sizeof(COMMAND*));

		for (int i = 0; i < count; i++) {
			temp_commands[i] = (COMMAND*)malloc(sizeof(COMMAND));
		}
		int i;
		printf("%-30s  %-30s   %-6s\n", "serialKey", "MQTT_Topic", "QOS");
		for (i = 0; i < count; ++i)
		{
			config_setting_t *config = config_setting_get_elem(setting, i);

			/* Only output the record if all of the expected fields are present. */
			const char *serialKey, *MQTT_Topic, *direction;
			int QOS;

			if (config_setting_lookup_string(config, "serialKey", &serialKey)
				&& config_setting_lookup_string(config, "MQTT_Topic", &MQTT_Topic)
				&& config_setting_lookup_int(config, "QOS", &QOS)
				&& config_setting_lookup_string(config, "direction", &direction)) {

				temp_commands[i]->serialKey = (char*)malloc(strlen(serialKey) + 1); //nullchar
				stpcpy(temp_commands[i]->serialKey, serialKey);

				temp_commands[i]->MQTT_Topic = (char*)malloc(strlen(MQTT_Topic) + 1);
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

void init_commands(config_t *cfg) {
	const char *str;
	/* Get the store name. */
	if (config_lookup_string(cfg, "name", &str)) {
		printf("aggregator: %s\n\n", str);
	}
	else {
		fprintf(stderr, "No 'name' setting in configuration file.\n");
	}

	config_setting_t *setting;
	//load setting
	setting = config_lookup(cfg, "settings");
	if (setting != NULL)
	{
		printf("Settings \n");
		if (config_setting_lookup_string(setting, "serial", &configuration.serialPort))
			printf("%-30s", configuration.serialPort);

		if (config_setting_lookup_string(setting, "CLIENTID", &configuration.CLIENTID))
			printf("%-30s", configuration.CLIENTID);

		if (config_setting_lookup_string(setting, "mqttServer", &configuration.mqttServer))
			printf("%-30s", configuration.mqttServer);

		if (config_setting_lookup_int(setting, "buad", &configuration.buad))
			printf("%-30d", configuration.buad);

		putchar('\n');
	}

	set_up_serial_commands(cfg);
}


int main(int argc, char *argv[]) {
	/* Operation Variables */
	g_fcu.initialise();
	App app("MultiWii", 512.0, 1.0 / 4.096, 0.92f / 10.0f, 9.80665f);
	char const* configFile = "Control.cfg";
	config_t cfg;
	config_init(&cfg);

	if (!config_read_file(&cfg, configFile))
	{
		fprintf(stderr, "%s:%d - %s\n", config_error_file(&cfg),
			config_error_line(&cfg), config_error_text(&cfg));
		config_destroy(&cfg);
		return (EXIT_FAILURE);
	}

	init_commands(&cfg);

	char buf[64] = "temp text";
	init_serial(&fd);

	init_mqtt(&client);
	config_destroy(&cfg);
	g_fcu.subscribe(&App::onAttitude, &app, 0.5);
	do
	{
		if (fd != -1) {
			process_serial(client, buf);
		}
	} while (1);
	return (EXIT_SUCCESS);
}
