#include "splashkit.h"

int main()
{
    open_window("Glowing Blue Circle", 600, 600);

    int outer_circle_radius = 255;

    // Create a circle in center of window
    circle outer_circle = circle_at(screen_center(), outer_circle_radius);

    // Get center point of circle
    point_2d circle_centre = center_point(outer_circle);

    while (!quit_requested())
    {
        process_events();

        // Draw glowing circle
        clear_screen(color_black());
        for (int i = outer_circle_radius; i > 5; i--)
        {
            fill_circle(rgb_color(0, 0, 255 - i), circle_at(circle_centre, i));
        }
        refresh_screen();
    }
    close_all_windows();

    return 0;
}