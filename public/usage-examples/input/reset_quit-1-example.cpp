#include "splashkit.h"
#include <string>

int main()
{
    open_window("Quit Confirmation", 600, 300);

    bool running = true;     // controls the main loop
    bool confirming = false; // true while the "Really quit?" prompt is showing
    int cancelled = 0;       // how many times the quit request was cancelled

    while (running)
    {
        process_events();

        // quit_requested becomes true when the window's close button is clicked,
        // and stays true until the program exits or reset_quit is called
        if (quit_requested())
            confirming = true;

        if (confirming)
        {
            // Y confirms the quit and ends the loop
            if (key_typed(Y_KEY))
                running = false;

            // N cancels it - reset_quit makes quit_requested return false again
            if (key_typed(N_KEY))
            {
                reset_quit();
                confirming = false;
                cancelled++;
            }
        }

        clear_screen(COLOR_WHITE);

        if (confirming)
        {
            draw_text("Really quit?", COLOR_RED, "Arial", 28, 220, 90);
            draw_text("[Y] Yes    [N] No", COLOR_BLACK, "Arial", 20, 215, 150);
        }
        else
        {
            draw_text("Running - click the X to quit", COLOR_GREEN, "Arial", 24, 150, 90);

            // std::to_string converts a number to a string
            draw_text("Quit requests cancelled: " + std::to_string(cancelled),
                      COLOR_BLACK, "Arial", 20, 175, 150);
        }

        draw_text("reset_quit cancels a pending quit request", COLOR_GRAY, "Arial", 16, 145, 230);

        refresh_screen(60);
    }

    close_all_windows();
    return 0;
}
