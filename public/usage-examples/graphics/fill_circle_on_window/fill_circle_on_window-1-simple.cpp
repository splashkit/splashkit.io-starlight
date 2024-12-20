#include "splashkit.h"

int main()
{
    // Open a new window and initialize to a window variable
    window window = open_window("Traffic Lights", 800, 600);
    
    clear_screen(COLOR_WHITE);

    // Use function to place 3 circles in destination window as traffic lights
    fill_circle_on_window(window, COLOR_RED, 400, 100, 50);
    fill_circle_on_window(window, COLOR_YELLOW, 400, 250, 50);
    fill_circle_on_window(window, COLOR_GREEN, 400, 400, 50);

    refresh_screen();
    delay(5000);

    // Close all windows   
    close_all_windows();
}



