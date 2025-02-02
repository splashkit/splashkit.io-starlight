from splashkit import *

# Open a new window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmap
sk_bmp = load_bitmap("skbox", "skbox.png")

# Create a sprite using the bitmap
sk_sprite = create_sprite(sk_bmp)

# Define sprite and collision point positions
sk_sprite_loc = point_at(50, 50)
file_sprite_loc = point_at(20, 20)
bug_sprite_loc = point_at(200, 150)

# Set sprite position
sprite_set_position(sk_sprite, sk_sprite_loc)

# Clear the screen and draw elements
clear_screen(color_white())
draw_sprite(sk_sprite)
fill_circle_record(color_black(), circle_at(collision_loc_1, 2))
fill_circle_record(color_red(), circle_at(collision_loc_2, 2))

# Check for collisions
if sprite_point_collision(sk_sprite, collision_loc_1):
    write_line("Black Dot Collision")
if sprite_point_collision(sk_sprite, collision_loc_2):
    write_line("Red Dot Collision")

# Refresh the screen and delay before closing
refresh_screen()
delay(4000)

close_all_windows()
