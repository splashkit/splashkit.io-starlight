#include "splashkit.h"

int main()
{
    // Open a new window
    open_window("Bitmap Collisions", 315, 330);

    // Load the bitmap
    bitmap sk_bmp = load_bitmap("skbox", "skbox.png");

    // Create a sprite using the bitmap
    sprite sk_sprite = create_sprite(sk_bmp);

    // Define sprite and collision point positions
    point_2d sk_sprite_loc = {50, 50};
    point_2d collision_loc_1 = {20, 20};
    point_2d collision_loc_2 = {200, 150};

    // Set sprite position
    sprite_set_position(sk_sprite, sk_sprite_loc);

    // Clear the screen and draw elements
    clear_screen(COLOR_WHITE);
    draw_sprite(sk_sprite);
    fill_circle(COLOR_BLACK, circle_at(collision_loc_1, 2));
    fill_circle(COLOR_RED, circle_at(collision_loc_2, 2));

    // Check for collisions
    if (sprite_point_collision(sk_sprite, collision_loc_1))
        write_line("Black Dot Collision");
    if (sprite_point_collision(sk_sprite, collision_loc_2))
        write_line("Red Dot Collision");

    // Refresh the screen and delay before closing
    refresh_screen();
    delay(4000);

    close_all_windows();

    return 0;
}
