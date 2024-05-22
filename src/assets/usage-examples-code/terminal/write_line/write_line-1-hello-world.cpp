/**
 * Usage Example: Printing a string to the terminal.
 **/

#include "splashkit.h"

int main()
{
    // Example 1: Print explicit string
    write_line("Hello World");

    // Example 2: Print value of string variable
    string message = "Hello World from 'message' variable";
    write_line(message);

    // Example 3: Print combination of explicit string and value of string variable
    string hello = "Hello";
    write_line(hello + " World!\nDon't forget spaces between words when printing to the terminal!");
    write_line("Otherwise you get this: " + hello + "World!");

    return 0;
}