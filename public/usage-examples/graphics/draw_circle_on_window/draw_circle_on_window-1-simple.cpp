#include "splashkit.h"

int main()
{
    window window = open_window("Bubbles", 800, 600);
    
    clear_screen(COLOR_WHITE);
    for (int i = 0; i < 50; i++)
    {
        // Set random circle values
        double x = rnd(800);
        double y = rnd(600);
        double radius = rnd(50);
        color randomColor = rgb_color(rnd(255), rnd(255), rnd(255));

        // Draw the circle base on the random data
        draw_circle_on_window(window, randomColor, x, y, radius);
    }
    refresh_screen();
    
    delay(4000);
    close_all_windows();

    return 0;
}