#include "splashkit.h"

int main()
{
    write_line("Type a phrase in ALL CAPS (SHOUT IT!):");
    string input = read_line();

    // Convert input to lowercase
    string quieted = to_lowercase(input);

    write_line("Calm down... here it is in lowercase: " + quieted);

    return 0;
}
