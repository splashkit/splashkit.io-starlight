#include "splashkit.h"

int main()
{
    open_window("Fill Triangle Example", 800, 600);
    
    clear_screen();
    fill_triangle(COLOR_RED, 100, 100, 200, 200, 300, 100);
    refresh_screen();

    delay(5000);
    close_all_windows();

    return 0;
}