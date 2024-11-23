#include "splashkit.h"

int main()
{
    // Open the window
    open_window("Bitmap Collisions", 315, 330);

    // Load the bitmap and set its location
    bitmap sk_bmp = load_bitmap("skbox", "skbox.png");
    point_2d bmp_loc = {50, 50};

    // Define the rectangles
    rectangle black_rectangle;
    black_rectangle.x = 20;
    black_rectangle.y = 20;
    black_rectangle.width = 20;
    black_rectangle.height = 20;

    rectangle red_rectangle;
    red_rectangle.x = 150;
    red_rectangle.y = 200;
    red_rectangle.width = 20;
    red_rectangle.height = 20;

    // Clear the screen and draw the elements
    clear_screen(rgb_color(67, 80, 175));
    draw_bitmap(sk_bmp, bmp_loc.x, bmp_loc.y);
    fill_rectangle(COLOR_BLACK, black_rectangle);
    fill_rectangle(COLOR_RED, red_rectangle);

    // Check for collisions
    if (bitmap_rectangle_collision(sk_bmp, 50, 50, 50, black_rectangle))
        write_line("Black Rectangle Collision!");

    if (bitmap_rectangle_collision(sk_bmp, 50, 50, 50, red_rectangle))
        write_line("Red Rectangle Collision!");

    // Refresh the screen and wait
    refresh_screen();
    delay(4000);

    // Close all windows
    close_all_windows();

    return 0;
}
