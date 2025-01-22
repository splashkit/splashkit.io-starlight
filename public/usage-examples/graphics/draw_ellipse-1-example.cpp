#include "splashkit.h"

int main()
{
    open_window("Draw Ellipse", 800, 600);

    clear_screen(COLOR_WHITE);
    // Draw 30 ellipses
    for (int i = 0; i < 30; i++)
    {   
        int width = 600 - i * 20;   // Decrease width by 20 every loop
        int height = 400 - i * 10;  // Decrease height by 10 every loop
        int x = 100 + i * 10;       // Increase x position by 10 every loop
        int y = 100 + i * 5;        // Increase y position by 5 every loop

        // Draw ellipse base on the given data
        draw_ellipse(random_rgb_color(255), x, y, width, height);
    }
    refresh_screen();

    delay(4000);
    close_all_windows();

    return 0;
}