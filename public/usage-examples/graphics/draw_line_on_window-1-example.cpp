#include "splashkit.h"

int main()
{
    // Create Window
    window window = open_window("Colourful Starburst", 600, 600);

    clear_screen(COLOR_BLACK);

    // Draws starburst pattern with changing colours to specific window
    draw_line_on_window(window, COLOR_YELLOW, 0, 0, 600, 600);
    draw_line_on_window(window, COLOR_GREEN, 0, 150, 600, 450);
    draw_line_on_window(window, COLOR_TEAL, 0, 300, 600, 300);
    draw_line_on_window(window, COLOR_BLUE, 0, 450, 600, 150);
    draw_line_on_window(window, COLOR_VIOLET, 0, 600, 600, 0);
    draw_line_on_window(window, COLOR_PURPLE, 150, 0, 450, 600);
    draw_line_on_window(window, COLOR_PINK, 300, 0, 300, 600);
    draw_line_on_window(window, COLOR_RED, 450, 0, 150, 600);
    draw_line_on_window(window, COLOR_ORANGE, 600, 0, 0, 600);

    refresh_screen();

    delay(5000);
    close_all_windows();
    
    return 0;
}