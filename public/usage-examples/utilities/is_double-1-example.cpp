#include "splashkit.h"

int main()
{
    string values[6] = {"123", "45.67", "-50", "abc", "789", "0"};

    for (int i = 0; i < 6; i++)
    {
        // Print the value along with the result using "true" or "false"
        write(values[i] + " - ");

        // Check if string is a valid double
        if (is_double(values[i]))
            write_line("true");
        else
            write_line("false");
    }

    return 0;
}
