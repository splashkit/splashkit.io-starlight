#include "splashkit.h"

int main()
{
    // Create a window and bitmap for our caterpillar
    window window = open_window("Window", 400, 200);
    bitmap bitmap = create_bitmap("caterpillar", 400, 200);
    
    // Fill background with light color
    clear_bitmap(bitmap, COLOR_WHITE);

    // Create rainbow colors array
    color colors[] = {COLOR_RED, COLOR_ORANGE, COLOR_YELLOW, 
                     COLOR_GREEN, COLOR_BLUE, COLOR_VIOLET};
    
    // Draw circles for caterpillar segments with alternating y positions
    double x = 50;
    for(int i = 0; i < 6; i++)
    {
        double y = 100 + (i % 2 == 0 ? 20 : -20);  // Alternate up and down
        fill_circle_on_bitmap(bitmap, colors[i], x, y, 40);
        x += 60;
    }
    
    // Draw eyes (adjusted to match first segment position)
    fill_circle_on_bitmap(bitmap, COLOR_BLACK, 60, 100, 8);
    fill_circle_on_bitmap(bitmap, COLOR_BLACK, 60, 130, 8);
    
    while (!window_close_requested(window))
    {
        process_events();
        // Draw the bitmap to the window
        draw_bitmap(bitmap, 0, 0);
        // Refresh the window
        refresh_screen();
    }
    
    free_bitmap(bitmap);
    close_window(window);

    return 0;
}