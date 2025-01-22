#include "splashkit.h"

int main()
{
    open_window("Point At Origin", 800, 600);

    // Create a point at origin
    point_2d point = point_at_origin();

    // Create red circle at the origin point
    clear_screen();
    fill_circle(COLOR_RED, point.x, point.y, 4);
    refresh_screen();

    delay(4000);
    close_all_windows();
}