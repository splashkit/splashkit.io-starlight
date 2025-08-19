from splashkit import *

open_window("spriteY", 600, 600)

load_bitmap("player", "player-run.png")
player_sprite = create_sprite(bitmap_named("player"))

# Setting the x and y coordinate in reference to the window
sprite_set_x(player_sprite, 300)
sprite_set_y(player_sprite, 300)

# Retrieve the y position
y_position = sprite_y(player_sprite)

clear_screen(color_black())
draw_sprite(player_sprite)
draw_text_no_font_no_size("Sprite Y: " + str(y_position), color_white(), 10, 10)
refresh_screen()
delay(5000)

close_all_windows()