#include "splashkit.h"

int main()
{
    string mouse_position_text = "Click to see coordinates...";

    open_window("Mouse Clicked Location", 600, 600);

    while (!quit_requested())
    {
        process_events();

        // Check for mouse click
        if (mouse_clicked(LEFT_BUTTON))
        {
            mouse_position_text = "Mouse clicked at " + point_to_string(mouse_position());
        }

        // Print mouse position to screen
        clear_screen(COLOR_GHOST_WHITE);
        draw_text(mouse_position_text, COLOR_BLACK, 100, 300);
        refresh_screen();
    }

    close_all_windows();
    return 0;
}