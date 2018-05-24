/*
 * GccApplication2.c
 *
 * Created: 21/05/2018 12:12:40 PM
 * Author : lachl
 */ 

#include <avr/io.h>


#include <avr/io.h>
//#ifndef F_CPU
//#define F_CPU 16000000UL // 16 MHz clock speed

#include <util/delay.h>

void Init_Power (void){
	DDRA |= (1 << PA0) || DDRA |= (1 << PA1) || DDRA |= (1 << PA6) || DDRB |= (1 << PB7);
	PORTB |= (0 << PB7) || PORTA |= (0 << PA0) || PORTA |= (0 << PA1) || PORTA |= (0 << PA6);	
}

void Cycle_Telemetry (void){
	PORTB |= (1 << PB7);
	_delay_ms(3000);
	PORTB |= (0 << PB7);	
}

void Cycle_Orientation (void){
	PORTA |= (1 << PA0) || PORTA |= (1 << PA6);
	_delay_ms(3000);
	PORTA |= (0 << PA0) || PORTA |= (0 << PA6);
}

int main(void)
{
	
	
	/* Replace with your application code */
	while (1)
 	{
// 		PORTC |= (1<<PC0);
		
		
//  		PORTC = 0xFF; //Turns ON All LEDs
//  		_delay_ms(2000); //1 second delay
//  		PORTC= 0x00; //Turns OFF All LEDs
//  		_delay_ms(2000); //1 second delay
	}
}

