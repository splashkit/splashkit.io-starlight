#include "splashkit.h"

int main()
{
    // open a window
    window wind = open_window("DON'T CLICK THE BUTTON!", 400, 200);

    bool countdown_started = false;
    int countdown = 5;
    timer countdown_timer = create_timer("countdown");

    while (!quit_requested())
    {
        // get user events
        process_events();

        // clear screen
        clear_window(wind, COLOR_WHITE);

        if (!countdown_started)
        {
            // Show the button before countdown starts
            if (button("Click Me!", rectangle_from(150, 85, 100, 30)))
            {
                countdown_started = true;
                start_timer(countdown_timer);
            }
        }
        else
        {
            // Display countdown
            draw_text("This window will self destruct in " + std::to_string(countdown), COLOR_BLACK, "arial", 18, 50, 85);

            // Check if 1 second has passed
            if (timer_ticks(countdown_timer) > 1000)
            {
                countdown--;
                reset_timer(countdown_timer);

                if (countdown <= 0)
                {
                    close_window(wind);
                    break;
                }
            }
        }

        draw_interface();
        refresh_window(wind);
    }

    // close all open windows
    close_all_windows();
}