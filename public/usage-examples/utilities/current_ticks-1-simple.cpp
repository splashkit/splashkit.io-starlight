#include "splashkit.h"

int main()
{
    // Get the ticks before delay
    unsigned int ticks_before = current_ticks();
    write_line("Starting tick capture...");
    write_line("Ticks before any delay: " + std::to_string(ticks_before));

    // Delay for 1 second (1000 milliseconds) and capture ticks
    delay(1000);
    unsigned int ticks_after_1s = current_ticks();
    write_line("Ticks after 1 second: " + std::to_string(ticks_after_1s));

    // Delay for 2 more seconds (2000 milliseconds) and capture ticks
    delay(2000);
    unsigned int ticks_after_2s = current_ticks();
    write_line("Ticks after 2 more seconds (3 seconds total): " + std::to_string(ticks_after_2s));

    // Delay for 4 more seconds (4000 milliseconds) and capture ticks
    delay(4000);
    unsigned int ticks_after_4s = current_ticks();
    write_line("Ticks after 4 more seconds (7 seconds total): " + std::to_string(ticks_after_4s));

    // Show the difference in ticks at each capture point
    unsigned int diff_1s = ticks_after_1s - ticks_before;
    unsigned int diff_2s = ticks_after_2s - ticks_after_1s;
    unsigned int diff_4s = ticks_after_4s - ticks_after_2s;

    write_line("Ticks passed in the first second: " + std::to_string(diff_1s));
    write_line("Ticks passed in the next 2 seconds: " + std::to_string(diff_2s));
    write_line("Ticks passed in the final 4 seconds: " + std::to_string(diff_4s));

    return 0;
}
