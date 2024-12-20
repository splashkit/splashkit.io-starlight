#include <splashkit.h>

int read_integer(string prompt)
{
    // This function converts user input into an integer with input validation using SplashKit functions.

    string input_string;

    // Prompt user with message in terminal and read input from user
    write(prompt);
    input_string = read_line();

    // Holds program in a loop if user enters a valid integer
    while (!is_integer(input_string))
    {
        write_line("Please enter a valid integer.");
        write(prompt);
        input_string = read_line();
    }

    // Convert to integer and return
    return convert_to_integer(input_string);
}

int main(int argc, char *argv[])
{
    int first_num = read_integer("Please enter first number (whole number): ");
    int second_num = read_integer("Please enter second number (whole number): ");

    write("The sum of the two integers is: ");
    write_line(first_num + second_num);
    return 0;
}