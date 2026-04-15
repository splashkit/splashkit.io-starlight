#include "splashkit.h"

int main()
{
    // Declare constants and variables
    const int FPS = 60; // Set frame rate to 60 frames per second
    double time = 0;
    double scaleFactor = 1;

    // Create a 600 x 600 bitmap with a white "ring" on black background
    bitmap bmp = create_bitmap("ring", 600, 600);
    clear_bitmap(bmp, COLOR_BLACK);
    fill_circle_on_bitmap(bmp, COLOR_WHITE, 300, 300, 300);
    fill_circle_on_bitmap(bmp, COLOR_BLACK, 300, 300, 200);

    open_window("Mesmerising Bitmap Scaling", 800, 600);

    while (!quit_requested())
    {
        process_events();

        // Increment the time and calculate the scale factor
        time += 1.0 / FPS;
        scaleFactor = time * time;

        // Reset time if the bitmap is over 2.5 times its initial size
        if (scaleFactor > 2.5)
        {
            time = 0;
        }

        // Create the draw options that will scale the bitmap
        drawing_options opts = option_scale_bmp(scaleFactor, scaleFactor);

        // Draw the scaled bitmap onto the window and refresh
        clear_screen(COLOR_BLACK);
        draw_bitmap(bmp, 100, 0, opts);
        refresh_screen(FPS);
    }

    // Clean up
    close_all_windows();
    return 0;
}