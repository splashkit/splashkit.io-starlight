#include "splashkit.h"

int main()
{
    open_window("RGB Color Demo", 800, 600);
    
    while (!window_close_requested("RGB Color Demo"))
    {
        process_events();
        clear_screen(COLOR_BLACK);
        
        // Create custom colors using RGB values
        color purple = rgb_color(128, 0, 128);
        color orange = rgb_color(255, 165, 0);
        color teal = rgb_color(0, 128, 128);
        color pink = rgb_color(255, 192, 203);
        
        // Draw colored rectangles
        fill_rectangle(purple, 50, 50, 150, 100);
        fill_rectangle(orange, 220, 50, 150, 100);
        fill_rectangle(teal, 50, 200, 150, 100);
        fill_rectangle(pink, 220, 200, 150, 100);
        
        // Label each color
        draw_text("Purple (128,0,128)", COLOR_WHITE, 50, 160);
        draw_text("Orange (255,165,0)", COLOR_WHITE, 220, 160);
        draw_text("Teal (0,128,128)", COLOR_WHITE, 50, 310);
        draw_text("Pink (255,192,203)", COLOR_WHITE, 220, 310);
        
        // Show RGB color creation in action
        draw_text("Creating colors with rgb_color(r, g, b)", COLOR_WHITE, 50, 20);
        
        // Dynamic color example - change over time
        int time_value = current_ticks() / 10;
        color dynamic = rgb_color(time_value % 256, (time_value * 2) % 256, (time_value * 3) % 256);
        fill_circle(dynamic, 600, 300, 80);
        draw_text("Dynamic Color", COLOR_WHITE, 550, 400);
        
        refresh_screen(60);
    }
    
    close_window("RGB Color Demo");
    return 0;
}
