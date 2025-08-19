#include "splashkit.h"

int main()
{
    open_window("create_sprite", 600, 600);

    // Load the bitmap for creating a sprite
    bitmap player = load_bitmap("player_bitmap", "player.png");

    // Create the player sprite
    sprite player_sprite = create_sprite(player);

    sprite_set_x(player_sprite, 300);
    sprite_set_y(player_sprite, 300);

    clear_screen(COLOR_BLACK);
    draw_sprite(player_sprite);
    refresh_screen();
    delay(5000);
    
    close_all_windows();

    return 0;
}