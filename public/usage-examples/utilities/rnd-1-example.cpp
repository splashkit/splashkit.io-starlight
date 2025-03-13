#include "splashkit.h"

int main()
{
    write_line("");
    write_line("Let's simulate a Coin Flip!");
    write_line("");
    write_line("Flipping coin ...");
    delay(1500);
    write_line("");

    float random = 0.5F;

    // Add extra "randomness"
    for (int i = 0; i < 100; i++)
    {
        random = rnd();
    }

    // 50% chance of heads or tails
    if (random < 0.5)
    {
        write_line("Heads!");
    }
    else
    {
        write_line("Tails!");
    }
    write_line("");

    return 0;
}