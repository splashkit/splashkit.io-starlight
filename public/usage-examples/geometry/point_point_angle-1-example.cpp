#include "splashkit.h"

int main()
{
    // Define the variables
    window window = open_window("How Does \"Point Point Angle\" Work?", 400, 400);
    font arial = load_font("arial", "arial.ttf");
    line horizontal_line = line_from(0, screen_height() / 2, screen_width(), screen_height() / 2);
    line vertical_line = line_from(screen_width() / 2, 0, screen_width() / 2, screen_height());
    line zero_line = line_from(screen_width() / 2, screen_height() / 2, screen_width(), screen_height() / 2);
    circle outer_circle = circle_at(screen_center(), 100);
    circle center_circle = circle_at(screen_center(), 4);
    point_2d center_pt = screen_center();
    point_2d mouse_pt;
    char angle[10];

    float pt_pt_angle; // Store the "Point Point Angle"

    while (!quit_requested())
    {
        process_events();

        // Get "current" Mouse Position
        mouse_pt = mouse_position();

        // Calculate the angle between the center point and the current mouse position
        pt_pt_angle = point_point_angle(center_pt, mouse_pt);

        // Round to 2 decimal places for nicer output
        snprintf(angle, 10, "%.2f", pt_pt_angle);

        // Draw background annotation
        clear_screen(color_white());
        draw_line(color_black(), horizontal_line);
        draw_line(color_black(), vertical_line);
        draw_circle(color_black(), outer_circle);
        draw_line(color_red(), zero_line);
        fill_circle(color_red(), center_circle);
        draw_text("0", color_blue(), arial, 16, 350, screen_height() / 2 - 20);
        draw_text("o", color_blue(), arial, 10, 360, screen_height() / 2 - 23);
        draw_text("90", color_blue(), arial, 16, screen_width() / 2 + 5, 350);
        draw_text("o", color_blue(), arial, 10, screen_width() / 2 + 24, 347);
        draw_text("-90", color_blue(), arial, 16, screen_width() / 2 + 5, 35);
        draw_text("o", color_blue(), arial, 10, screen_width() / 2 + 29, 32);
        draw_text("180", color_blue(), arial, 16, 30, screen_height() / 2 - 20);
        draw_text("o", color_blue(), arial, 10, 58, screen_height() / 2 - 23);
        draw_line(color_red(), center_pt, mouse_position());
        fill_rectangle(color_green(), mouse_x() + 10, mouse_y() - 10, 80, 30);
        draw_text(angle, color_white(), arial, 16, mouse_x() + 20, mouse_y() - 5);
        draw_text("o", color_white(), arial, 10, mouse_x() + 20 + text_width(angle, arial, 16), mouse_y() - 8);
        refresh_screen();
    }

    close_all_windows();
    free_all_fonts();

    return 0;
}