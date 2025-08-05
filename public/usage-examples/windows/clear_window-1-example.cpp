#include "splashkit.h"

int main()
{
    // open a window
    window clear = open_window("Clear Window", 600, 200);

    while (!quit_requested())
    {
        // get user events
        process_events();

        // clear screen
        clear_screen(COLOR_WHITE);

        // Buttons that change the colour of the screen
        if (button_at("Red!", rectangle_from(75, 85, 100, 30)))
        {
            clear_window(clear, COLOR_RED);
            refresh_screen();
            delay(1000); // prevent multiple clicks
            continue;
        }
        if (button("Green!", rectangle_from(250, 85, 100, 30)))
        {
            clear_window(clear, COLOR_GREEN);
            refresh_screen();
            delay(1000);
            continue;
        }

        if (button("Blue!", rectangle_from(425, 85, 100, 30)))
        {
            clear_window(clear, COLOR_BLUE);
            refresh_screen();
            delay(1000);
            continue;
        }

        draw_interface();
        refresh_screen();
    }

    // close all open windows
    close_all_windows();
    return 0;
}
