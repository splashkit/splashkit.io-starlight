#include "splashkit.h"

int main()
{
    string user_input;
    double principal, rate, time, interest;

    write_line("Welcome to the Simple Interest Calculator!");

    // Get principal amount from the user (without input validation for simplicity)
    write("Please enter the principal amount (in dollars): ");
    user_input = read_line();
    principal = to_double(user_input);

    // Get the interest rate from the user
    write("Please enter the interest rate (as a percentage, e.g., 5 for 5%): ");
    user_input = read_line();
    rate = to_double(user_input);

    // Get the time period from the user
    write("Please enter the time period (in years): ");
    user_input = read_line();
    time = to_double(user_input);

    // Calculate simple interest: Interest = Principal * Rate * Time / 100
    interest = (principal * rate * time) / 100;

    // Output the result
    write_line();
    write_line("Calculating interest...");
    write_line();
    delay(1000);

    write_line("For a principal of $" + to_string(principal, 2) + " at an interest rate of " + to_string(rate, 2) + "% over " + to_string(time, 2) + " years:");
    write_line("\tThe simple interest is: $" + to_string(interest, 2));

    return 0;
}