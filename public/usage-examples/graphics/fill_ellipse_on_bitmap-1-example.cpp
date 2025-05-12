#include "splashkit.h"

int main()
{
    // Create a window and bitmap for the water surface
    window window = open_window("Window", 400, 300);
    bitmap bitmap = create_bitmap("water", 400, 300);
    
    // Fill background with light blue
    clear_bitmap(bitmap, rgba_color(200, 230, 255, 255));
    
    // Create different blue tones for ripples (from most opaque to most transparent)
    color ripple_colors[] = {
        rgba_color(100, 150, 255, 100),
        rgba_color(120, 170, 255, 80),
        rgba_color(140, 190, 255, 60),
        rgba_color(160, 210, 255, 40),
        rgba_color(180, 230, 255, 20)
    };
    
    // Create ripple effect with concentric ellipses
    double center_x = 200;  // Center of the bitmap
    double center_y = 150;
    for(int i = 0; i < 5; i++)
    {
        // Larger ellipses with decreasing size from center
        fill_ellipse_on_bitmap(bitmap, ripple_colors[i],
                             center_x - (100 + i*30),  // x gets further from center
                             center_y - (75 + i*20),   // y gets further from center
                             200 + i*60,               // width increases for outer ripples
                             150 + i*40);              // height increases for outer ripples
    }
    
    while (!window_close_requested(window))
    {
        process_events();
        // Draw the bitmap to the window
        draw_bitmap(bitmap, 0, 0);
        refresh_screen();
    }
    
    free_bitmap(bitmap);
    close_all_windows();
    return 0;
}