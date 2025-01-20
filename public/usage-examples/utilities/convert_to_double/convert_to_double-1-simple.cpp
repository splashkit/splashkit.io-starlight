#include "splashkit.h"

int main()
{
    write_line("Welcome to the Simple Interest Calculator!");

    // Get principal amount from the user
    write_line("Please enter the principal amount (in dollars):");
    string principal_input = read_line();

    // Get the interest rate from the user
    write_line("Please enter the interest rate (as a percentage, e.g., 5 for 5%):");
    string rate_input = read_line();

    // Get the time period from the user
    write_line("Please enter the time period (in years):");
    string time_input = read_line();

    // Convert inputs to double
    double principal = convert_to_double(principal_input);
    double rate = convert_to_double(rate_input);
    double time = convert_to_double(time_input);

    // Calculate simple interest: Interest = Principal * Rate * Time / 100
    double interest = (principal * rate * time) / 100;

    // Output the result
    write_line("Calculating interest...");
    delay(1000);

    write_line("For a principal of $" + std::to_string(principal) + " at an interest rate of " + std::to_string(rate) + "% over " + std::to_string(time) + " years:");
    write_line("The simple interest is: $" + std::to_string(interest));

    return 0;
}