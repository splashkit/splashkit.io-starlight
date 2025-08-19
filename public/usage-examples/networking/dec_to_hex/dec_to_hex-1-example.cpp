#include "splashkit.h"

int main()
{
    write_line("Hello! Welcome to the decimal to hexadecimal converter.");

    // Prompt the user for a decimal input
    write_line("Please enter a decimal number:");

    // Read the input as a string
    string dec_input = read_line();

    // Convert the input string to an unsigned integer
    unsigned int dec_value = convert_to_integer(dec_input);

    // Convert the decimal value to hexadecimal format
    string hex_value = dec_to_hex(dec_value);

    // Display the result in hexadecimal format
    write_line("The decimal value in hexadecimal format is: " + hex_value);

    return 0;
}
