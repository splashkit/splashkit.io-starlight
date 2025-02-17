#include "splashkit.h"

int main()
{
    window blue_window = open_window("Blue Rectangle", 200, 200);
    window red_window = open_window("Red Rectangle", 200, 200);
    move_window_to(red_window, window_x(blue_window) + window_width(blue_window), window_y(blue_window));

    // Fill a blue rectangle on the first window
    clear_window(blue_window, COLOR_WHITE);
    fill_rectangle_on_window(blue_window, COLOR_BLUE, 50, 50, 100, 50);
    refresh_window(blue_window);

    // Fill a red rectangle on the second window
    clear_window(red_window, COLOR_WHITE);
    fill_rectangle_on_window(red_window, COLOR_RED, 50, 50, 100, 50);
    refresh_window(red_window);

    delay(5000);

    close_window(blue_window);
    close_window(red_window);

    return 0;
}