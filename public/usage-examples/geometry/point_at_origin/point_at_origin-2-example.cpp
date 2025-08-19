#include "splashkit.h"

int main()
{
    open_window("Point At Origin", 800, 600);

    // Create a point at origin
    point_2d point = point_at_origin();

    // Create "sun" at the origin point
    clear_screen();
    for (int i = 200; i > 10; i--)
    {
        fill_circle(rgb_color(255, i + 50, i % 30), point.x, point.y, i);
    }
    refresh_screen();

    delay(4000);
    close_all_windows();
}