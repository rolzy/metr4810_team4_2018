CC=gcc 
CFLAGS=-Wall -lpaho-mqtt3c  -lconfig -g 
HEADERS=
all: aggregator
aggregator.o: main.c $(HEADERS)
	$(CC) $(CFLAGS) -c main.c -o aggregator.o
aggregator: aggregator.o
	$(CC) $(CFLAGS) aggregator.o -o aggregator
clean:
	rm -f aggregator aggregator.o
	rm /opt/tp/PowerController.cfg /opt/tp/aggregator
	
run: aggregator
	./aggregator
	
libs:
	sudo apt-get install libconfig-dev
	sudo apt-get install libssl-dev
	git clone https://github.com/eclipse/paho.mqtt.c.git
	cd paho.mqtt.c
	make
	sudo make install
	
install:aggregator stopDaemons
	mkdir -p /opt/tp/
	cp aggregator /opt/tp/
	cp PowerController.cfg /opt/tp/

	
stopDaemons:
	systemctl stop aggregator.service
	systemctl stop aggregatorCam.service
	systemctl stop Flight.service
	
startDaemons:
	systemctl start aggregator.service
	systemctl start aggregatorCam.service
	systemctl start Flight.service
	
service:install
	cp aggregator.service /etc/systemd/system/
	sudo systemctl enable aggregator
	sudo systemctl start aggregator
	

installCam:aggregator
	mkdir -p /opt/tp/
	cp aggregator /opt/tp/
	cp Camera.cfg /opt/tp/
	
serviceCam:installCam
	cp aggregatorCam.service /etc/systemd/system/
	sudo systemctl enable aggregatorCam
	sudo systemctl start aggregatorCam
	
	
installControl:aggregator
	mkdir -p /opt/tp/
	cp ~/orientation_control/team4_oc/build/control  /opt/tp/
	cp ~/orientation_control/team4_oc/build/Control.cfg /opt/tp/
	
serviceControl:installCam
	cp aggregatorFlight.service /etc/systemd/system/
	sudo systemctl enable aggregatorCam
	sudo systemctl start aggregatorCam

