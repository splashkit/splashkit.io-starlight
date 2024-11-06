#include "splashkit.h"

int main()
{
    open_window("free_sprite", 600, 600);

    bitmap player = load_bitmap("player", "player.png");
    sprite player_sprite = create_sprite(bitmap_named("player"));
    sprite_set_x(player_sprite, 300);
    sprite_set_y(player_sprite, 300);

    bool sprite_exists = true; // Track if the sprite exists

    while (!quit_requested())
    {
        process_events();

        clear_screen(COLOR_BLACK);
        if (sprite_exists)
        {
            draw_sprite(player_sprite);
            update_sprite(player_sprite);
        }
        refresh_screen();

        // If UP key is typed, the sprite is removed
        if (sprite_exists && key_typed(UP_KEY))
        {
            free_sprite(player_sprite);
            sprite_exists = false; // Set bool to false to stop drawing/updating
        }
    }

    // Clean up
    if (sprite_exists)
    {
        free_sprite(player_sprite);
    }
    
    close_all_windows();
    
    return 0;
}