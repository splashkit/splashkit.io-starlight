#include "splashkit.h"

int main()
{
    // Variable Declarations
    double bar_x = 100;
    line slider = line_from(100, 300, 500, 300);
    line bar = line_from(bar_x, 310, bar_x, 290);
    int percent = 0;
    bool bar_selected = false;

    window window = open_window("Volume Slider", 600, 600);

    while (!quit_requested())
    {
        process_events();

        // Check if user has clicked on the bar Line
        if (mouse_down(LEFT_BUTTON) && point_on_line(mouse_position(), bar))
        {
            bar_selected = true;
        }
        
        // Check if user has released mouse button
        if (mouse_up(LEFT_BUTTON))
        {
            bar_selected = false;
        }

        // Update bar location
        if (bar_selected && mouse_x() >= 100 && mouse_x() <= 500)
        {
            bar_x = mouse_x();                             // sets bar_x value to mouse x value
            percent = int((bar_x - 100) / (500 - 100) * 100); // convert bar_x position to percent value
            bar = line_from(bar_x, 310, bar_x, 290);
        }

        // Draw lines and volume text
        clear_screen(color_white());
        draw_line(color_black(), bar);
        draw_line(color_black(), slider);
        draw_text("Volume: " + std::to_string(percent), color_black(), 200, 450);
        refresh_screen();
    }
    close_window(window);

    return 0;
}