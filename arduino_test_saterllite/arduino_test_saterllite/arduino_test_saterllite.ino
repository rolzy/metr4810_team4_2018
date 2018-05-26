/*
  Physical Pixel

  An example of using the Arduino board to receive data from the computer. In
  this case, the Arduino boards turns on an LED when it receives the character
  'H', and turns off the LED when it receives the character 'L'.

  The data can be sent from the Arduino Serial Monitor, or another program like
  Processing (see code below), Flash (via a serial-net proxy), PD, or Max/MSP.

  The circuit:
  - LED connected from digital pin 13 to ground

  created 2006
  by David A. Mellis
  modified 30 Aug 2011
  by Tom Igoe and Scott Fitzgerald

  This example code is in the public domain.

  http://www.arduino.cc/en/Tutorial/PhysicalPixel
*/
const int ledPin = 43; // the pin that the LED is attached to
int incomingByte;      // a variable to read incoming serial data into
int motors = 44; //PA0
int pi = 15;//PB7
int naze = 38;//PA6
int led =  43;//PA1
void setup() {
  // initialize serial communication:
  Serial1.begin(9600);
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  
  pinMode(motors, OUTPUT);
  pinMode(pi, OUTPUT);
  pinMode(naze, OUTPUT);
  pinMode(led, OUTPUT);

  digitalWrite(led,HIGH);
 
  digitalWrite(pi,LOW);
  digitalWrite(naze,LOW);
  delay(500);
  digitalWrite(led,LOW);
   digitalWrite(motors,HIGH);
}

unsigned long lastSendTime;
const long intervel = 5000;

String readLine;
byte payloadPosition = 0;

void loop() {
  // see if there's incoming serial data:

  if (millis() - lastSendTime >= intervel) {
    lastSendTime = millis();
    Serial1.print("hb:");
    Serial1.println(lastSendTime);
  }

  if (Serial1.available() > 0) {
    // read the oldest byte in the serial buffer:
    readLine = Serial1.readStringUntil('/n');
    if (readLine.startsWith("p")) {
        digitalWrite(pi,HIGH);
        delay(1000);
       digitalWrite(pi,LOW);
       
    }
    if (readLine.startsWith("c")) {
         digitalWrite(motors,LOW);
           digitalWrite(naze,HIGH);
           delay(1000);
           digitalWrite(naze,LOW);
           delay(1000);
           digitalWrite(motors,HIGH);
    }
    }
  }



