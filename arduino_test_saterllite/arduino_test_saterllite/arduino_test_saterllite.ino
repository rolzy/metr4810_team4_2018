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

struct RGB {
  byte value[3];
  byte pin[3];
};

struct RGB rgb1, rgb2;

const int ledPin = 13; // the pin that the LED is attached to
int incomingByte;      // a variable to read incoming serial data into

void setup() {
  // initialize serial communication:
  Serial.begin(9600);
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);

  rgb2.pin[2] = 6;
  rgb2.pin[1] = 7;
  rgb2.pin[0] = 9;

  rgb1.pin[0] = A0;
  rgb1.pin[1] = A2;
  rgb1.pin[2] = A3;
  for (int i = 0; i < 3; i++) {
    pinMode(rgb2.pin[i], OUTPUT);
    pinMode(rgb1.pin[i], OUTPUT);
  }
}

unsigned long lastSendTime;
const long intervel = 5000;

String readLine;
byte payloadPosition = 0;

void loop() {
  // see if there's incoming serial data:

  if (millis() - lastSendTime >= intervel) {
    lastSendTime = millis();
    Serial.print("hb");
    Serial.println(lastSendTime);
  }

  if (Serial.available() > 0) {
    // read the oldest byte in the serial buffer:
    readLine = Serial.readStringUntil('/n');
    if (readLine.startsWith("led1")) {
      payloadPosition =  readLine.indexOf(":");
      // if it's a capital H (ASCII 72), turn on the LED:
      if (readLine.charAt(payloadPosition + 1) == 'H') {
        digitalWrite(ledPin, HIGH);
      }
      // if it's an L (ASCII 76) turn off the LED:
      if (readLine.charAt(payloadPosition + 1) == 'L') {
        digitalWrite(ledPin, LOW);
      }
    }

    if (readLine.startsWith("rgb1")) {
      payloadPosition =  readLine.indexOf(":");
      // if it's a capital H (ASCII 72), turn on the LED:
      for (int i = 0; i < 3; i++) {
        if (readLine.charAt(payloadPosition + 1+ i) == 'H') {
          digitalWrite(rgb1.pin[i], HIGH);
        } else {
          digitalWrite(rgb1.pin[i], LOW);
        }
      }

    }
    
    if (readLine.startsWith("rgb2")) {
      payloadPosition =  readLine.indexOf(":");
      // if it's a capital H (ASCII 72), turn on the LED:
      for (int i = 0; i < 3; i++) {
        if (readLine.charAt(payloadPosition +1 + i) == 'H') {
          digitalWrite(rgb2.pin[i], HIGH);
        } else {
          digitalWrite(rgb2.pin[i], LOW);
        }
      }

    }
  }
}


