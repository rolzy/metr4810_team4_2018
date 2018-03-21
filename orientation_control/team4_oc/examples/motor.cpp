// team4_oc.cpp : Defines the entry point for the console application.
//
//
#include <iostream>
#include <string>
#include "FlightController.hpp"
//
int main(int argc, char *argv[]) {
  const std::string device = (argc>1) ? std::string(argv[1]) : "COM4";
  const size_t baudrate = (argc>2) ? std::stoul(argv[2]) : 115200;
//
  fcu::FlightController fcu(device, baudrate);
  fcu.initialise();
//
// spin motors 1 to 4
  fcu.setMotors({ 1100,1100,1100,1100,0,0,0,0 });
//
  std::this_thread::sleep_for(std::chrono::seconds(1));
//
  // stop motors
  fcu.setMotors({ 1500,1500,1500,1500,1500,1500,1500,1500 });
}

