#include "splashkit.h"

int main()
{
    open_window("Draw Circle Example", 800, 600);

    clear_screen(COLOR_WHITE);
    
    // Draw a large red filled circle in the center
    fill_circle(COLOR_RED, 400, 300, 100);
    
    // Draw circles with different colors, sizes, and positions
    draw_circle(COLOR_BLUE, 200, 150, 80);
    draw_circle(COLOR_GREEN, 600, 150, 60);
    draw_circle(COLOR_ORANGE, 200, 450, 70);
    draw_circle(COLOR_PURPLE, 600, 450, 65);
    
    // Draw smaller circles with varying colors
    for (int i = 0; i < 8; i++)
    {
        int radius = 20 + i * 5;
        int x = 400 + (i - 4) * 80;
        int y = 100;
        draw_circle(random_rgb_color(255), x, y, radius);
    }
    
    refresh_screen();

    delay(5000);
    close_all_windows();

    return 0;
}
