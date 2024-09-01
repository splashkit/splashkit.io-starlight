#include "splashkit.h"

int main()
{
    open_window("Fill Circle", 800, 600);
    clear_screen();
    fill_circle(COLOR_BLUE, 300, 300, 200);
    refresh_screen(60);
    delay(4000);

    close_all_windows();

    return 0;
}