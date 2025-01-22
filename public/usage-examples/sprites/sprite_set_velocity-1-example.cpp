#include "splashkit.h"

int main()
{
    open_window("sprite-set-velocity", 600, 600);

    load_bitmap("player", "player-run.png");
    sprite player_sprite = create_sprite(bitmap_named("player"));
    sprite_set_x(player_sprite, 300);
    sprite_set_y(player_sprite, 300);

    // Create vector for sprite's velocity
    vector_2d vel = vector_to(0.01,0);
    
    while (!quit_requested())
    {
        process_events();

        // Set sprite velocity and update sprite
        sprite_set_velocity(player_sprite, vel);
        update_sprite(player_sprite);

        clear_screen(COLOR_BLACK);
        draw_sprite(player_sprite);
        refresh_screen();
    }
    
    close_all_windows();

    return 0;
}