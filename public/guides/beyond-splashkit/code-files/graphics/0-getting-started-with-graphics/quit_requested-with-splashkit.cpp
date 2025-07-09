#include "splashkit.h"

int main(int argv, char **args)
{
    open_window("SK Window: QuitRequested", 600, 600);

    // Hang window until quit
    while (!quit_requested())
    {
        process_events();
    }

    // Cleanup and free memory
    close_all_windows();

    return 0;
}