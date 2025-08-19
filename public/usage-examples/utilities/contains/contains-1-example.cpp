#include "splashkit.h"

int main()
{
    string text = "Hello World, hello world";
    string subtext = "World";
    write_line("Text: " + text);
    write_line("Subtext: " + subtext);

    // Check if "Hello World" contains "World"
    if (contains(text, subtext))
    {
        write_line("The string contains 'World'.");
    }
    else
    {
        write_line("The string does not contain 'World'.");
    }
}