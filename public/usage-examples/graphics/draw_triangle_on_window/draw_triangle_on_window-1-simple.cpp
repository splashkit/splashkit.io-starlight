#include "splashkit.h"

int main()
{
    window window = open_window("Draw Triangle on Window", 800, 600);

    clear_screen(COLOR_WHITE);
    for (int i = 0; i < 20; i++)
    {
        // Set the x position for triangles increase by 40 * i every round
        double x = 40 * i;

        // Draw the triangles by increasing x position
        draw_triangle_on_window(window, random_rgb_color(255), 0 + x, 0, 20 + x, 40, 40 + x, 0);
    }
    refresh_screen();

    delay(4000);
    close_all_windows();

    return 0;
}