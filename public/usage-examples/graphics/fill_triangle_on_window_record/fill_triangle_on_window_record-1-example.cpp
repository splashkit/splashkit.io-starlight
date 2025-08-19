#include "splashkit.h"

int main()
{
    window blue_window = open_window("Blue Triangle", 200, 200);
    window red_window = open_window("Red Triangle", 200, 200);
    move_window_to(red_window, window_x(blue_window) + window_width(blue_window), window_y(blue_window));

    // Define the triangles to draw
    triangle blue_triangle = triangle_from(point_at(50, 100), point_at(100, 50), point_at(150, 100));
    triangle red_triangle =  triangle_from(point_at(50, 50), point_at(100, 100), point_at(150, 50));

    // Fill a blue triangle on the first window
    clear_window(blue_window, COLOR_WHITE);
    fill_triangle_on_window(blue_window, COLOR_BLUE, blue_triangle);
    refresh_window(blue_window);

    // Fill a red triangle on the second window
    clear_window(red_window, COLOR_WHITE);
    fill_triangle_on_window(red_window, COLOR_RED, red_triangle);
    refresh_window(red_window);

    delay(5000);

    close_window(blue_window);
    close_window(red_window);

    return 0;
}