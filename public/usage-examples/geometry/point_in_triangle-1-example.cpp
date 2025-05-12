#include "splashkit.h"

int main()
{
    triangle triangle = triangle_from(700, 200, 500, 1, 200, 500);
    point_2d mouse_pt;
    string text;
    color triangle_clr;

    open_window("Point In Triangle", 800, 600);

    while (!quit_requested())
    {
        process_events();

        mouse_pt = mouse_position();

        // Update text and triangle colour based on the mouse position in relation to the triangle
        if (point_in_triangle(mouse_pt, triangle))
        {
            triangle_clr = color_red();
            text = "Point in the triangle!";
        }
        else
        {
            triangle_clr = color_green();
            text = "Point not in the triangle!";
        }

        clear_screen();
        draw_triangle(triangle_clr, triangle);
        draw_text(text, color_red(), 100, 100);
        refresh_screen();
    }
    close_all_windows();

    return 0;
}