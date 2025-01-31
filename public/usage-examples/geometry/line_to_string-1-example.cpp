#include "splashkit.h"

int main()
{
    open_window("Line To String", 800, 600);

    // Define points for the line
    point_2d start_point = {100, 150};
    point_2d end_point = {500, 550};

    // Create a line from start and end points
    line demo_line = line_from(start_point, end_point);
    draw_line(COLOR_RED, demo_line);

    // Find the text description of the line
    string desc = line_to_string(demo_line);
    draw_text(desc, COLOR_BLACK, 110, 130);

    refresh_screen();
    delay(5000);

    close_all_windows();
    return 0;
}