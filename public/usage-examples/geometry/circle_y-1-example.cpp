#include "splashkit.h"

int main()
{
    // Create a circle (with random y position value between 200 - 400)
    circle circle = circle_at(400, rnd(200) + 200, 200);

    open_window("Circle Y", 800, 600);

    // Draw the Circle and y coordinate on window
    clear_screen(color_white());
    draw_circle(COLOR_RED, circle);
    draw_text("Circle Y: " + std::to_string(circle_y(circle)), COLOR_BLACK, 100, 100);

    // Draw a line to show the circle Y coordinate
    draw_line(COLOR_BLACK, 0, circle_y(circle), screen_width(), circle_y(circle));

    // Draw 10 circles with radius of 50 and the same circle y coordinate
    for (int i = 0; i < 10; i++)
    {
        draw_circle(COLOR_BLUE, i * 60 + 100, circle_y(circle), 50);
    }
    refresh_screen();
    
    delay(4000);
    close_all_windows();
}
