#include "splashkit.h"

int main()
{
    open_window("Closest point", 600, 600);

    // Declare variables
    point_2d circle_pt = screen_center();
    circle circle = circle_at(circle_pt, 100);
    point_2d mouse_pt = mouse_position();
    point_2d closest_point;

    while (!quit_requested())
    {
        process_events();

        // Get "current" Mouse Position
        mouse_pt = mouse_position();

        // Calculate the closest distance between the current mouse position and the circle
        closest_point = closest_point_on_circle(mouse_pt, circle);

        // Draw circle and indicated points
        clear_screen();
        draw_circle(COLOR_BLACK, circle);
        fill_circle(COLOR_BLUE, mouse_pt.x, mouse_pt.y, 5);
        fill_circle(COLOR_RED, closest_point.x, closest_point.y, 5);
        refresh_screen();
    }

    close_all_windows();

    return 0;
}