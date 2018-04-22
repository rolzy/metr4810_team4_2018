// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>

int main()
{
	int flag = 0;
	int speed[8] = { 0,0,0,0,0,0,0,0 };
	char input;

	for (;;) {
		if (_kbhit()) {
			input = _getch();
			switch (input) {
			case 'w':
				speed[0] += 100;
				for (int n = 0; n < 8; n++) {
					_cprintf("%d,", speed[n]);
				}
				_cprintf("\n");
				break;
			case 's':
				speed[0] -= 100;
				for (int n = 0; n < 8; n++) {
					_cprintf("%d,", speed[n]);
				}
				_cprintf("\n");
				break;
			case 'a':
				speed[1] += 100;
				for (int n = 0; n < 8; n++) {
					_cprintf("%d,", speed[n]);
				}
				_cprintf("\n");
				break;
			case 'd':
				speed[1] -= 100;
				for (int n = 0; n < 8; n++) {
					_cprintf("%d,", speed[n]);
				}
				_cprintf("\n");
				break;
			case 'q':
				flag = 1;
				break;
			}
		}
		if (flag)
		break;
	}

    return 0;
}

