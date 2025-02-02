from splashkit import *

# Open a new window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmap
sk_bmp = load_bitmap("skbox", "skbox.png")

# Create a sprite using the bitmap
sk_sprite = create_sprite(sk_bmp)

# Define sprite and rectangle positions
sk_sprite_loc = point_at(50, 50)
sprite_set_position(sk_sprite, sk_sprite_loc)

# Define the first rectangle
test_rectangle_1 = rectangle_from(20, 20, 20, 20)

# Define the second rectangle
test_rectangle_2 = rectangle_from(150, 200, 20, 20)

# Clear the screen and draw elements
clear_screen(color_white())
draw_sprite(sk_sprite)
fill_rectangle_record(color_black(), test_rectangle_1)
fill_rectangle_record(color_red(), test_rectangle_2)

# Check for collisions
if sprite_rectangle_collision(sk_sprite, test_rectangle_1):
    write_line("Black Rectangle Collision")
if sprite_rectangle_collision(sk_sprite, test_rectangle_2):
    write_line("Red Rectangle Collision")

# Refresh the screen and delay before closing
refresh_screen()
delay(4000)

close_all_windows()