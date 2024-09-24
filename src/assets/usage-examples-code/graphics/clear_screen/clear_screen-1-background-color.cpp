#include "splashkit.h"

int main()
{
    open_window("Back Ground", 800, 600);
    clear_screen(COLOR_BLUE);
    refresh_screen(60);
    delay(4000);

    close_all_windows();

    return 0;
}