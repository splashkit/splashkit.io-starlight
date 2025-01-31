#include "splashkit.h"

int main()
{
    double pi = 3.14159265358979323846;
    write_line("Circle Area Calculator:");

    for (double radius = 1.0; radius <= 10.0; radius += 1.0)
    {
        write("Radius: ");
        write(radius); // Writing a double
        write(", Area: ");
        write(pi * radius * radius); // Writing the calculated area as a double
        write_line("");
    }

    return 0;
}