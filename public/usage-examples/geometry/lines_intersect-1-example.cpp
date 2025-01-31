#include "splashkit.h"

int main()
{
    open_window("Lines Intersect", 800, 600);

    // Define points for the lines
    point_2d start_point_a = {100, 150};
    point_2d end_point_a = {500, 550};

    point_2d start_point_b = {100, 550};
    point_2d end_point_b = {500, 150};

    point_2d start_point_c = {550, 150};
    point_2d end_point_c = {550, 500};

    // Draw the lines
    line demo_line_a = line_from(start_point_a, end_point_a);
    draw_line(COLOR_RED, demo_line_a);
    draw_text("A", COLOR_BLACK, start_point_a.x - 20, start_point_a.y - 10);

    line demo_line_b = line_from(start_point_b, end_point_b);
    draw_line(COLOR_BLUE, demo_line_b);
    draw_text("B", COLOR_BLACK, start_point_b.x - 20, start_point_b.y - 10);

    line demo_line_c = line_from(start_point_c, end_point_c);
    draw_line(COLOR_GREEN, demo_line_c);
    draw_text("C", COLOR_BLACK, start_point_c.x - 20, start_point_c.y - 10);

    // Check intersections
    bool intersect_ab = lines_intersect(demo_line_a, demo_line_b);
    bool intersect_ac = lines_intersect(demo_line_a, demo_line_c);

    // Display intersection results
    draw_text("A and B intersect: " + std::string(intersect_ab ? "Yes" : "No"), COLOR_BLACK, 150, 130);
    draw_text("A and C intersect: " + std::string(intersect_ac ? "Yes" : "No"), COLOR_BLACK, 150, 150);

    refresh_screen();
    delay(5000);

    close_all_windows();
    return 0;
}