#include "splashkit.h"

int main(int argv, char **args)
{
    // Print instructions in terminal
    write_line("\nClick anywhere on the image to change the background colour\n");

    // Declare Variables
    color eye_select = COLOR_BLACK;

    // Open Window
    open_window("SK Window: Eyedropper", 800, 600);

    // Load bitmaps
    load_bitmap("image", "photo.jpg");
    load_bitmap("eyedrop", "eyedrop.png");

    while (!quit_requested())
    {
        process_events();

        // Clear screen with mouse color
        clear_screen(eye_select);

        // Draw image
        draw_bitmap("image", 75, 125);

        // Draw eyedropper as curser
        draw_bitmap("eyedrop", mouse_x() - 3, mouse_y() - bitmap_height("eyedrop") + 3);
        hide_mouse();

        // Set color at cursor when click
        if (mouse_clicked(LEFT_BUTTON))
            eye_select = get_pixel(mouse_x(), mouse_y());

        // Display drawing
        refresh_screen();
    }

    // Cleanup and free memory
    close_all_windows();
    free_all_sound_effects();
    free_all_music();

    return 0;
}