#include "splashkit.h"

int main()
{
    // Create 4 diamond shapes using quads
    quad q1 = quad_from(400, 200, 300, 300, 300, 0, 200, 200);
    quad q2 = quad_from(400, 210, 310, 300, 600, 300, 400, 390);
    quad q3 = quad_from(200, 400, 300, 300, 300, 600, 400, 400);
    quad q4 = quad_from(200, 390, 290, 300, 0, 300, 200, 210);

    open_window("Ninja Star", 600, 600);
    clear_screen(COLOR_WHITE);

    // Draw the quads
    draw_quad(COLOR_BLACK, q1);
    draw_quad(COLOR_GREEN, q2);
    draw_quad(COLOR_RED, q3);
    draw_quad(COLOR_BLUE, q4);

    refresh_screen();
    delay(5000);
    close_all_windows();
    return 0;
}