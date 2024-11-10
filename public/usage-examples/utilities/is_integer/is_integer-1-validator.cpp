#include "splashkit.h"

int main()
{
    write_line("Welcome to the Integer Validation Checker!");

    string input;
    bool valid_input = false;

    // Loop until the user enters a valid integer
    while (!valid_input)
    {
        write_line("Please enter a valid integer:");
        input = read_line();

        // Check if the input is a valid integer
        if (is_integer(input))
        {
            int number = convert_to_integer(input);  // Convert input to integer
            write_line("Great! You've entered a valid integer: " + std::to_string(number));
            valid_input = true;  // Exit loop on valid input
        }
        else
        {
            write_line("Oops! That's not a valid integer. Please try again.");
        }
    }

    write_line("Thank you for using the Integer Validation Checker!");

    return 0;
}
