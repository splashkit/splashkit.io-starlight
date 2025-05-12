#include "splashkit.h"

int main()
{
    write_line("Welcome to the Number Guessing Game!");
    write_line("I'm thinking of a number between 1 and 100...");
    
    string input; // User input
    int secret_number = 42; // Set a secret number
    int guess = -1;  // Initialise with an invalid guess

    while (guess != secret_number)
    {
        // Ask the user for their guess
        write_line("Please enter your guess:");
        input = read_line();

        // Validate if the input is a valid integer
        if (is_integer(input))
        {
            // Convert input string to integer
            guess = convert_to_integer(input);

            // Check if the guess is correct
            if (guess > secret_number)
            {
                write_line("Too high! Try again.");
            }
            else if (guess < secret_number)
            {
                write_line("Too low! Try again.");
            }
        }
        else
        {
            write_line("That's not a valid integer! Please enter a number.");
        }
    }
    
    write_line("Congratulations! You've guessed the correct number: " + std::to_string(guess));

    return 0;
}