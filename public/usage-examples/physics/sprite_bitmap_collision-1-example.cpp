#include "splashkit.h"

int main()
{
    // Open a new window
    open_window("Bitmap Collisions", 315, 330);

    // Load the bitmaps
    bitmap sk_bmp = load_bitmap("skbox", "skbox.png");
    bitmap file_bmp = load_bitmap("file", "file_image.png");
    bitmap bug_bmp = load_bitmap("bug", "bug_image.png");

    // Create a sprite using the bitmap
    sprite sk_sprite = create_sprite(sk_bmp);

    // Define positions
    point_2d sk_sprite_loc = point_at(50, 50);
    point_2d file_bmp_loc = point_at(20, 20);
    point_2d bug_bmp_loc = point_at(200, 150);

    // Set sprite position
    sprite_set_position(sk_sprite, sk_sprite_loc);

    // Clear the screen and draw all elements
    clear_screen(COLOR_WHITE);
    draw_sprite(sk_sprite);
    draw_bitmap(file_bmp, file_bmp_loc.x, file_bmp_loc.y);
    draw_bitmap(bug_bmp, bug_bmp_loc.x, bug_bmp_loc.y);

    // Check for collisions
    if (sprite_bitmap_collision(sk_sprite, file_bmp, file_bmp_loc.x, file_bmp_loc.y))
        write_line("SplashKit got a new file!");

    if (sprite_bitmap_collision(sk_sprite, file_bmp, bug_bmp_loc.x, bug_bmp_loc.y))
        write_line("SplashKit has bugs!");

    // Refresh the screen and delay before closing
    refresh_screen();
    delay(4000);

    close_all_windows();

    return 0;
}