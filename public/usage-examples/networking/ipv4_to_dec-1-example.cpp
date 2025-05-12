#include "splashkit.h"

int main()
{
    write_line("Hello! Welcome to the IP to decimal converter.");

    // Prompt the user for an IP input in dotted decimal format (e.g., 127.0.0.1)
    write_line("Please enter an IPv4 address in dotted decimal format (e.g., 127.0.0.1):");

    // Read the input as a string
    string ip_input = read_line();

    // Convert the IPv4 string to a decimal
    unsigned int ip_as_dec = ipv4_to_dec(ip_input);

    // Display the result
    write_line("The IP address in decimal format is: " + std::to_string(ip_as_dec));

    return 0;
}