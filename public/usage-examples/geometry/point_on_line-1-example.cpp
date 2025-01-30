#include "splashkit.h"

int main()
{
    // Variable Declarations
    line line = line_from(100, 300, 500, 300);

    // Create window
    window window = open_window("Select Point", 600, 600);

    while (!quit_requested())
    {
        // Display line
        clear_screen(color_white());
        draw_line(color_black(), line);

        // Draw text if cursor is on line
        if (point_on_line(mouse_position(), line))
        {
            draw_text("Point on line: " + point_to_string(mouse_position()), color_black(), 200, 450);
        }

        refresh_screen();
        process_events();
    }
    close_window(window);
    
    return 0;
}