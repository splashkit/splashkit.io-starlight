#include "splashkit.h"

int main(int argv, char **args)
{
    // Create Window
    window win = open_window("SK Window: OpenWindow", 800, 600);

    // Hold window 4 seconds
    delay(4000);

    // Cleanup and free memory
    close_all_windows();

    return 0;
}