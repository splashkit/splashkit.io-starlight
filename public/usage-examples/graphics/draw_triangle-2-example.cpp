#include "splashkit.h"

int main()
{
    open_window("Random Colourful Triangles", 800, 600);
    
    clear_screen();
    for (int i = 0; i < 10; i++)
    {
        // Random point 1 for the triangle (x1,y1)
        int x1 = rnd(800);
        int y1 = rnd(600);

        // Random point 2 for the triangle (x2,y2)
        int x2 = rnd(800);
        int y2 = rnd(600);

        // Random point 3 for the triangle (x3,y3)
        int x3 = rnd(800);
        int y3 = rnd(600);

        // Draw triangle using the random points above
        draw_triangle(random_rgb_color(255), x1, y1, x2, y2, x3, y3);
    }

    refresh_screen();
    delay(4000);

    close_all_windows();

    return 0;
}