#include "splashkit.h"

int main()
{
    open_window("sprite_x", 600, 600);

    load_bitmap("player", "player-run.png");
    sprite player_sprite = create_sprite(bitmap_named("player"));

    // Setting the x coordinate in reference to the window
    sprite_set_x(player_sprite, 300);

    // Retrieve the x position
    double x_position = sprite_x(player_sprite);

    clear_screen(COLOR_BLACK);
    draw_sprite(player_sprite);
    draw_text("Sprite X: " + std::to_string((int)x_position), COLOR_WHITE, 10, 10);
    refresh_screen();
    delay(5000);

    close_all_windows();

    return 0;
}