#include "splashkit.h"

int main(int argv, char **args)
{
    // Create window
    open_window("SK Window: DrawRectangle", 600, 600);

    // Define a rectangle
    rectangle rect = rectangle_from(100.0, 100.0, 400.0, 300.0);

    // Clear screen with a black color
    clear_screen(COLOR_BLACK);

    // Draw & fill blue rectangle
    fill_rectangle(COLOR_BLUE, rect);

    // Display drawing
    refresh_screen();

    // Hold window until quit requested
    while (!quit_requested())
    {
        process_events();
    }

    // Cleanup and free memory
    close_all_windows();

    return 0;
}