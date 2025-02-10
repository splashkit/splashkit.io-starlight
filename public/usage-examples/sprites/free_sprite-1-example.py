from splashkit import *

open_window("Free Sprite Memory Resource", 600, 600)

player = load_bitmap("player", "player.png")
player_sprite = create_sprite(bitmap_named("player"))
sprite_set_x(player_sprite, 300)
sprite_set_y(player_sprite, 300)

sprite_exists = True # Track if the sprite exists

while (not quit_requested()):
    process_events()

    clear_screen(color_black())
    if (sprite_exists):
        draw_sprite(player_sprite)
        update_sprite(player_sprite)
    refresh_screen()

    # If UP key is typed, the sprite is removed
    if (sprite_exists and key_typed(KeyCode.up_key)):
        free_sprite(player_sprite)
        sprite_exists = False # Set bool to false to stop drawing/updating

# Clean up
if (sprite_exists):
    free_sprite(player_sprite)

close_all_windows()