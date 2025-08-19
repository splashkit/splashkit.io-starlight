#include "splashkit.h"

int main()
{
    // Example 1: Print single integer
    write_line(1);
    write_line(2);
    write_line(3);
    write_line(-1);
    write_line(-2);
    write_line(-3);

    // Example 2: Print multi-digit integer
    write_line(12345);
    write_line(953221311);
    write_line(-165746);

    // Example 3: Print integer after calculation
    int a = 222 - 111;
    int b = 10 * 12;
    int c = 100 / 5;
    write_line(a - b);
    write_line(b);
    write_line(c);

    return 0;
}