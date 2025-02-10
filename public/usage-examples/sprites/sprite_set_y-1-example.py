from splashkit import *

open_window("sprite_set_y", 600, 600)

load_bitmap("player", "player-run.png")
player_sprite = create_sprite(bitmap_named("player"))

# Setting the x coordinate in refrence to the window
sprite_set_y(player_sprite, 300)

clear_screen(color_black())
draw_sprite(player_sprite)
refresh_screen()
delay(5000)

close_all_windows()
