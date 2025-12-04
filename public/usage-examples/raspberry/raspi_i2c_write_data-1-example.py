from splashkit import *

write_line("Testing Quad 14-segment alphanumeric display with HT16K33 I2C driver...")

raspi_init()

i2c_device = raspi_i2c_open(1, 0x70)

raspi_i2c_write(i2c_device, 0b00100001) # Turn on system oscillator
raspi_i2c_write(i2c_device, 0b10000001) # no blink, display on
raspi_i2c_write(i2c_device, 0b11100011) # lower brightness

# clear display
for i in range(16):
    raspi_i2c_write_data(i2c_device, i, 0, 2)

message = "HELLO WORLD FROM SPLASHKIT"
text = "    " + message + "    "

for i in range(len(text) - 3):
    for j in range(4):
        raspi_i2c_write_data(i2c_device, j * 2, get_alpha_font_14_seg(text[i + j]), 2)
    delay(200)

# Turn off LED device
raspi_i2c_write(i2c_device, 0b00100000) # Turn off system oscillator

# Clean up the GPIO
raspi_cleanup()