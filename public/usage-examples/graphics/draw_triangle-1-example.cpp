#include "splashkit.h"

int main()
{
    open_window("Triangle Coordinates", 800, 400);

    // Top middle triangle point
    int x1 = 400;
    int y1 = 100;

    // Bottom left triangle point
    int x2 = 200;
    int y2 = 300;

    // Bottom right triangle point
    int x3 = 600;
    int y3 = 300;

    clear_screen();

    // Draw triangle using the points above
    draw_triangle(COLOR_RED, x1, y1, x2, y2, x3, y3);

    // Draw triangle information
    fill_circle(COLOR_BLUE, x1, y1, 3);
    fill_circle(COLOR_BLUE, x2, y2, 3);
    fill_circle(COLOR_BLUE, x3, y3, 3);
    draw_text("(x=" + std::to_string(x1) + ", y=" + std::to_string(y1) + ")", COLOR_BLUE, x1 - 50, y1 - 20);
    draw_text("(x=" + std::to_string(x2) + ", y=" + std::to_string(y2) + ")", COLOR_BLUE, x2 - 120, y2);
    draw_text("(x=" + std::to_string(x3) + ", y=" + std::to_string(y3) + ")", COLOR_BLUE, x3 + 10, y3);
    refresh_screen();
    delay(10000);

    close_all_windows();
    return 0;
}