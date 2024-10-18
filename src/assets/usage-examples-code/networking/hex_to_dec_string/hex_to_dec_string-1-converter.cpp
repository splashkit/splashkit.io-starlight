#include "splashkit.h"

int main()
{
    write_line("Hello! Welcome to the hexadecimal to decimal converter.");

    // Prompt the user for a hexadecimal input
    write_line("Please enter a hexadecimal number:");

    // Read the input as a string
    string hex_input = read_line();

    // Convert the hexadecimal string to a decimal string
    string dec_value = hex_to_dec_string(hex_input);

    // Display the result in decimal format
    write_line("The hexadecimal value in decimal format is: " + dec_value);

    return 0;
}
