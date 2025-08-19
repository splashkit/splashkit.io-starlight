#include "splashkit.h"

int main()
{
    write_line("Header Text");
    write_line(); // Add a blank line
    write_line("Body Content:");
    write_line("This is the first line of body content.");
    write_line(); // Add another blank line
    write_line("This is the second line of body content.");
    write_line(); // Add more spacing
    write_line("Footer Text");

    return 0;
}