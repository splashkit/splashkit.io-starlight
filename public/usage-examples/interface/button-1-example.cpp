#include "splashkit.h"

int main()
{
    open_window("Button Click Counter", 800, 600);

    // Track click counts for each button
    int red_count = 0;
    int blue_count = 0;
    int green_count = 0;

    while (!quit_requested())
    {
        process_events();
        clear_screen(COLOR_WHITE);

        // Show instructions for the user
        draw_text("Click the buttons to increment counters", COLOR_BLACK, 10, 10);

        // Create a panel with three buttons
        if (start_panel("Click Counter", rectangle_from(50, 50, 200, 200)))
        {
            // Check if each button is clicked and update counts
            if (button("Red"))
            {
                red_count++;
            }
            if (button("Blue"))
            {
                blue_count++;
            }
            if (button("Green"))
            {
                green_count++;
            }
            end_panel("Click Counter");
        }

        // Display each button's click count on the window
        draw_text("Red clicks: " + std::to_string(red_count), COLOR_RED, 300, 100);
        draw_text("Blue clicks: " + std::to_string(blue_count), COLOR_BLUE, 300, 130);
        draw_text("Green clicks: " + std::to_string(green_count), COLOR_GREEN, 300, 160);

        refresh_screen(60);
    }

    close_all_windows();
    return 0;
}
