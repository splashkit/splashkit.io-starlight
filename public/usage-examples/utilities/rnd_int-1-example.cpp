#include "splashkit.h"

int main()
{
    write_line("Get ready to generate a random number up to 1000...");
    write_line("Drum roll please...");
    delay(2000); // Delay for 2 seconds

    // Generate a random number up to the ubound
    int random_number = rnd(1000);

    write_line("Your lucky number is: " + std::to_string(random_number) + "!!");
    write_line("Feeling lucky? Maybe it's time to play the lottery!");

    return 0;
}