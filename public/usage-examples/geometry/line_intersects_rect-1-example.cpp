#include "splashkit.h"

int main()
{
    open_window("Avoid the Rectangle", 800, 600);

    // Define line's start point and a static rectangle
    point_2d start_pt = point_at(150, 100);
    rectangle rectangle = rectangle_from(250, 200, 300, 200);

    // Define a draggable line
    point_2d end_pt = mouse_position();
    line line = line_from(start_pt, end_pt);

    while (!quit_requested())
    {
        process_events();

        // Update draggable line
        end_pt = mouse_position();
        line = line_from(start_pt, end_pt);

        // Draw the line and rectangle
        clear_screen();
        draw_line(color_black(), line);
        draw_circle(color_black(), circle_at(start_pt, 5));
        draw_circle(color_black(), circle_at(end_pt, 5));
        draw_rectangle(color_black(), rectangle);

        // Check for intersection and display results
        if (line_intersects_rect(line, rectangle))
        {
            draw_text("Line and Rectangle intersect", color_red(), 250, 100);
        }
        else
        {
            draw_text("Line and Rectangle do not intersect", color_green(), 250, 100);
        }
        refresh_screen();
    }

    close_all_windows();

    return 0;
}