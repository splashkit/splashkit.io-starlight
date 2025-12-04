#include "splashkit.h"

int main()
{
    write_line("Testing Quad 14-segment alphanumeric display with HT16K33 I2C driver...");
    
    raspi_init();

    int i2c_device = raspi_i2c_open(1, 0x70);

    raspi_i2c_write(i2c_device, 0b00100001); // Turn on system oscillator
    raspi_i2c_write(i2c_device, 0b10000001); // no blink, display on
    raspi_i2c_write(i2c_device, 0b11100011); // lower brightness

    // clear display
    for (uint8_t i = 0; i < 16; i++)
    {
        raspi_i2c_write(i2c_device, i, 0, 2);
    }

    string message = "HELLO WORLD FROM SPLASHKIT";
    string text = "    " + message + "    ";

    for (int i = 0; i < text.length() - 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            raspi_i2c_write(i2c_device, j * 2, get_alpha_font_14_seg(text[i + j]), 2);
        }
        delay(200);
    }

    // Turn off LED device
    raspi_i2c_write(i2c_device, 0b00100000); // Turn off system oscillator

    // Clean up the GPIO
    raspi_cleanup();

    return 0;
}