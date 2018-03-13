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
	rm /opt/tp/example.cfg /opt/tp/aggregator
	
run: aggregator
	./aggregator
	
libs:
	sudo apt-get install libconfig-dev
	sudo apt-get install libssl-dev
	git clone https://github.com/eclipse/paho.mqtt.c.git
	cd paho.mqtt.c
	make
	sudo make install
	
install:aggregator
	mkdir /opt/tp/
	cp aggregator /opt/tp/
	cp example.cfg /opt/tp/

service:
	cp aggregator.service /etc/systemd/system/
	sudo systemctl enable aggregator
	sudo systemctl start aggregator