// team4_oc.cpp : Defines the entry point for the console application.
//
//
#include <iostream>
#include "FlightController.hpp"

int main(int argc, char *argv[]) {
    const std::string device = (argc>1) ? std::string(argv[1]) : "COM4";
    const size_t baudrate = (argc>2) ? std::stoul(argv[2]) : 115200;
    fcu::FlightController fcu(device, baudrate);
    fcu.initialise();
   
    int n;
    int flag = 0;
    std::array<int,8> speed = {1500, 1500, 1500, 1500, 0, 0, 0, 0 };

    while(true) {
        char input;
        std::cin >> input;

        switch(input) {
        case 'w':
            speed[0] += 100;
            for(n=0; n < 8; n++) {
                std::cout << speed[n] << std::endl;
            }
            fcu.setMotors({speed[0],speed[1],speed[2],speed[3],speed[4],speed[5],speed[6],speed[7]});
            std::this_thread::sleep_for(std::chrono::seconds(1));
            break;
        case 's':
            speed[0] -= 100;
            for(n=0; n < 8; n++) {
                std::cout << speed[n] << std::endl;
            }
            fcu.setMotors({speed[0],speed[1],speed[2],speed[3],speed[4],speed[5],speed[6],speed[7]});
            std::this_thread::sleep_for(std::chrono::seconds(1));
            break;
        case 'd':
            speed[1] += 100;
            for(n=0; n < 8; n++) {
                std::cout << speed[n] << std::endl;
            }
            break;
        case 'a':
            speed[1] -= 100;
            for(n=0; n < 8; n++) {
                std::cout << speed[n] << std::endl;
            }
            break;
        case 'q':
            flag=1;
            break;
        }
        if (flag)
            break;
    }

	fcu.disarm_block();
}

