from splashkit import *

open_window("create_sprite", 600, 600)

# Load the bitmap for creating a sprite
player = load_bitmap("player_bitmap", "player.png")
player_sprite = create_sprite(player)

# Setting the x coordinate in reference to the window
sprite_set_x(player_sprite, 300)
sprite_set_y(player_sprite, 300)

# Retrieve the y position using sprite_x function
x_position = sprite_x(player_sprite)

clear_screen(color_black())
draw_sprite(player_sprite)
refresh_screen()
delay(5000)

close_all_windows()