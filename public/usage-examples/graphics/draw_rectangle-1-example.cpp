#include "splashkit.h"

int main()
{
    open_window("Draw Rectangle", 800, 600);
    clear_screen(COLOR_WHITE);

    for (int i = 0; i < 21; i++)
    {
        int x = i * 40 - 40;
        int y = 600 - i * 30;

        // Draw rectangle using x and y above with width 40 and height 30
        draw_rectangle(random_rgb_color(255), x, y, 40, 30);
    }

    refresh_screen();
    delay(4000);
    close_all_windows();

    return 0;
}