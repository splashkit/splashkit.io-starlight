#include "splashkit.h"

int main()
{
    open_window("sprite_set_position", 600, 600);

    load_bitmap("player", "player-run.png");
    sprite player_sprite = create_sprite(bitmap_named("player"));
    sprite_set_x(player_sprite, 200);
    sprite_set_y(player_sprite, 300);

    clear_screen(COLOR_BLACK);
    draw_sprite(player_sprite);
    refresh_screen();
    delay(2000);

    // Create point_2d object which stores the new coordinates
    point_2d pos = point_at(450, 300);

    // Set the new sprite position
    sprite_set_position(player_sprite, pos);

    clear_screen(COLOR_BLACK);
    draw_sprite(player_sprite);
    refresh_screen();
    delay(5000);

    close_all_windows();

    return 0;
}