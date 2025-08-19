#include "splashkit.h"

int main()
{
    window window = open_window("Point In Circle", 800, 600);
    circle circle = circle_at(400, 300, 100);
    point_2d mouse_pt;
    string text;
    color circle_clr;

    while (!quit_requested())
    {
        process_events();

        mouse_pt = mouse_position();

        // Update text and circle colour based on the mouse position in relation to the circle
        if (point_in_circle(mouse_pt, circle))
        {
            circle_clr = color_red();
            text = "Point in the Circle!";
        }
        else
        {
            circle_clr = color_green();
            text = "Point not in the Circle!";
        }

        clear_screen();
        draw_circle(circle_clr, circle);
        draw_text(text, color_red(), 100, 100);
        refresh_screen();
    }
    close_window(window);

    return 0;
}