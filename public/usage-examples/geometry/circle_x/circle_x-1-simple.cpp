#include "splashkit.h"

int main()
{
    // Create a circle (with random x position value bewteen 200 - 600)
    circle circle = circle_at(rnd(400) + 200, 300, 200);

    open_window("Circle X", 800, 600);

    // Draw the Circle and x coordinate on window
    clear_screen(color_white());
    draw_circle(COLOR_RED, circle);
    draw_text("Circle X: " + std::to_string(circle_x(circle)), COLOR_BLACK, 100, 100);
    refresh_screen();

    delay(4000);
    close_all_windows();
}