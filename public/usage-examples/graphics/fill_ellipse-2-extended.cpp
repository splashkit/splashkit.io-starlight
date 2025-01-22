#include "splashkit.h"

int main()
{
    open_window("Clover Drawing with Fill Ellipse", 1000, 600);

    clear_screen();
    fill_ellipse(COLOR_GREEN, 150, 225, 400, 200);
    fill_ellipse(COLOR_GREEN, 375, 0, 200, 400);
    fill_ellipse(COLOR_GREEN, 400, 225, 400, 200);
    fill_rectangle(COLOR_BROWN, 470, 400, 10, 150);
    refresh_screen();

    delay(4000);

    close_all_windows();

    return 0;
}