#include "splashkit.h"

int main()
{
    // Open Window
    open_window("Basic Bitmap Drawing", 315, 330);

    // Load bitmap image
    load_bitmap("skbox", "skbox.png");

    while (!quit_requested())
    {
        process_events();

        clear_screen(rgb_color(67, 80, 175));
        draw_bitmap("skbox", 50, 50); // draw bitmap image
        refresh_screen();
    }
    close_all_windows();
    free_all_bitmaps();

    return 0;
}