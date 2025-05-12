#include "splashkit.h"

int main()
{
    write_line("Countdown:");
    for (int i = 10; i >= 0; i--) // Countdown from 10 to 0
    {
        write("T-minus ");
        write(i); // Writing an integer
        write_line(" seconds...");
    }
    write_line("Lift off!");

    return 0;
}