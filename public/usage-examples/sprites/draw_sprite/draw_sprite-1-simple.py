from splashkit import *

start = open_window("draw_sprite", 600, 600)

load_bitmap("player", "player.png")
player_sprite = create_sprite(bitmap_named("player"))
sprite_set_x(player_sprite, 300)
sprite_set_y(player_sprite, 300)

clear_screen(color_black())

# Draw the sprite
draw_sprite(player_sprite)

refresh_screen()
delay(5000)
close_all_windows()