#include "splashkit.h"

int main()
{
    write_line("Welcome to the Integer Validation Checker!");

    // Get the user input as a string
    write_line("Please enter a valid integer:");
    string input = read_line();

    // Check if the input is a valid integer
    // Loop while the user input is NOT valid (aka check for the wrong answers here)
    while (!is_integer(input))
    {
        write_line("Oops! That's not a valid integer. Please try again.");
        // Allow the user to enter their input again
        write_line("Please enter a valid integer:");
        input = read_line();
    }

    // Convert input to integer
    int number = convert_to_integer(input);
    write_line("Great! You've entered a valid integer: " + std::to_string(number));

    write_line("Thank you for using the Integer Validation Checker!");

    return 0;
}