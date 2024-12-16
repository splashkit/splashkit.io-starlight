#include "splashkit.h"

int main()
{
    // Create a Window and bitmap for the map
    window window = open_window("Window", 400, 400);
    bitmap planet = create_bitmap("planet", 400, 400);
    
    // Fill background with dark color
    clear_bitmap(planet, COLOR_BLACK);
    
    // Create color
    color red = COLOR_RED;
    
    // Draw the main planet circle
    fill_circle_on_bitmap(planet, rgba_color(180, 0, 0, 255), 200, 200, 150);
    draw_circle_on_bitmap(planet, red, 200, 200, 150);
    
    // Add some surface details with smaller circles
    for(int i = 0; i < 15; i++)
    {
        double x = rnd(100, 300);  // Random between 100 and 300
        double y = rnd(100, 300);  // Random between 100 and 300
        double size = rnd(10, 30); // Random between 10 and 30
        draw_circle_on_bitmap(planet, red, x, y, size);
    }
    
    while (!window_close_requested(window))
    {
        process_events();
        // Draw the bitmap to the window
        draw_bitmap(planet, 0, 0);
        refresh_screen();
    }
    
    free_bitmap(planet);
    close_all_windows();
    return 0;
}