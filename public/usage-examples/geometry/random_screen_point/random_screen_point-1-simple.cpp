#include "splashkit.h"

int main()
{
    // Create Window
    open_window("Night Sky", 600, 600);

    clear_screen(COLOR_BLACK);
    for (int i = 0; i < 1000; i++)
    {
        // Set random pixel location on screen
        point_2d pixel = random_screen_point();

        // Draw the pixel
        draw_pixel(random_rgb_color(255), pixel);
    }
    refresh_screen();

    delay(5000);
    close_all_windows();

    return 0;
}