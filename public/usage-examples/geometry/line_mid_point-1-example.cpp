#include "splashkit.h"

int main()
{
    open_window("Line Mid Point", 800, 600);

    // Define points for the line
    point_2d start_point = {100, 150};
    point_2d end_point = {500, 550};

    // Create a line from start and end points
    line demo_line = line_from(start_point, end_point);
    draw_line(COLOR_RED, demo_line);

    // Find the mid point and mark it
    point_2d mid_point = line_mid_point(demo_line);
    draw_circle(COLOR_BLACK, mid_point.x, mid_point.y, 2);

    // Display the midpoint coordinates
    draw_text("Midpoint coordinates: " + std::to_string(mid_point.x) + ", " + std::to_string(mid_point.y), COLOR_BLACK, mid_point.x + 10, mid_point.y - 10);

    refresh_screen();
    delay(5000);

    close_all_windows();
    return 0;
}