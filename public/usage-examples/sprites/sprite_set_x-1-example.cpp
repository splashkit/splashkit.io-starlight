#include "splashkit.h"

int main()
{
    open_window("sprite_set_x", 600, 600);

    load_bitmap("player", "player-run.png");
    sprite player_sprite = create_sprite(bitmap_named("player"));

    // Setting the x coordinate in refrence to the window
    sprite_set_x(player_sprite, 300);

    clear_screen(COLOR_BLACK);
    draw_sprite(player_sprite);
    refresh_screen();
    delay(5000);

    close_all_windows();

    return 0;
}