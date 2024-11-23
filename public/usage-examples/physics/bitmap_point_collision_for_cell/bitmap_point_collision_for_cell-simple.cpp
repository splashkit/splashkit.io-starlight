#include "splashkit.h"

int main()
{
    // Open the window
    open_window("Bitmap Collisions", 315, 330);

    // Load the bitmap
    bitmap sk_bmp = load_bitmap("skbox", "skbox.png");

    // Set the bitmap and dot locations
    point_2d sk_bmp_loc = {50, 50};
    point_2d black_dot_loc = {20, 20};
    point_2d red_dot_loc = {200, 150};

    // Clear the screen and draw the bitmap and dots
    clear_screen(COLOR_WHITE);
    draw_bitmap(sk_bmp, sk_bmp_loc.x, sk_bmp_loc.y);
    fill_circle(COLOR_BLACK, circle_at(black_dot_loc, 2));
    fill_circle(COLOR_RED, circle_at(red_dot_loc, 2));

    // Check for collisions
    if (bitmap_point_collision(sk_bmp, 50, 50, 50, 20, 20))
        write_line("Black Dot Collision");

    if (bitmap_point_collision(sk_bmp, 50, 50, 50, 200, 200))
        write_line("Red Dot Collision!");

    // Refresh the screen and wait
    refresh_screen();
    delay(4000);

    // Close all windows
    close_all_windows();

    return 0;
}
