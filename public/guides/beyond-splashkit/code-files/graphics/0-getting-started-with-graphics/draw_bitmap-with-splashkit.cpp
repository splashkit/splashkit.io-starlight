#include "splashkit.h"

int main(int argv, char **args)
{
    // Create window
    open_window("SK Window: DrawBitmap", 800, 600);

    // Load image
    bitmap image = load_bitmap("photo", "photo.jpg");

    // Hold window until quit requested
    while (!quit_requested())
    {
        process_events();

        // Clear screen with black
        clear_screen(COLOR_BLACK);

        // Draw image to screen
        draw_bitmap("photo", 75, 125);

        // Display drawing
        refresh_screen();
    }

    // Cleanup and free memory
    close_all_windows();
    free_all_bitmaps();

    return 0;
}