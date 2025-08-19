#include "splashkit.h"

int main()
{
    write_line("Let's make this more interesting!");

    int min_value = 1;
    int max_value = 0;

    // Loop until a valid range is provided
    while (min_value >= max_value)
    {
        // Get user input for the range
        write_line("Please enter the minimum number:");
        min_value = convert_to_integer(read_line());

        write_line("Please enter the maximum number:");
        max_value = convert_to_integer(read_line());

        // Check if min is smaller than max
        if (min_value >= max_value)
        {
            write_line("Oops! The minimum value should be less than the maximum value. Let's re-enter both values.");
        }
    }

    write_line("Get ready to generate a random number between " + std::to_string(min_value) + " and " + std::to_string(max_value) + "...");
    write_line("Drum roll please...");

    // Generate a random number in the specified range
    int random_number = rnd(min_value, max_value);

    write_line("Your lucky number is: " + std::to_string(random_number) + "!");
    write_line("How does it feel? Want to try again?");
    
    return 0;
}