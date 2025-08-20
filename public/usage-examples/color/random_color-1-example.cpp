#include "splashkit.h"

int main()
{
    open_window("Colour Changing Button", 800, 600);

    // Declare cursor point, rectangular button and store colour
    color button_color = color_green();
    point_2d mouse_pt;
    rectangle button = rectangle_from(250, 250, 300, 100);

    while (!quit_requested())
    {
        process_events();

        mouse_pt = mouse_position();

        // Check if the cursor is on the button
        if (point_in_rectangle(mouse_pt, button))
        {
            // Change the colour to a random colour
            if (mouse_clicked(LEFT_BUTTON))
            {
                button_color = random_color();
            }
        }

        clear_screen();
        draw_text("Click the button to change its Colour", color_black(), 250, 200);
        draw_rectangle(color_black(), button);
        fill_rectangle(button_color, button);
        refresh_screen();
    }
    close_all_windows();
    return 0;
}