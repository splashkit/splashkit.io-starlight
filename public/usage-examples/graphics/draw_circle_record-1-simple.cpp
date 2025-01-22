#include "splashkit.h"

int main()
{
    open_window("Draw Circles", 800, 600);

    // Create circles with different radii
    circle circle1 = circle_at(screen_center(), 50);
    circle circle2 = circle_at(screen_center(), 100);

    clear_screen();

    // Draw the circles with different colors
    draw_circle(COLOR_RED, circle1);
    draw_circle(COLOR_BLUE, circle2);
    draw_circle(COLOR_ORANGE, circle_at(screen_center(), 150));
    draw_circle(COLOR_GREEN, circle_at(screen_center(), 200));

    refresh_screen();

    delay(4000);
    close_all_windows();

    return 0;
}