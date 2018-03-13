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
	
install:aggregator
	cp aggregator /opt/tp/
	cp example.cfg /opt/tp/