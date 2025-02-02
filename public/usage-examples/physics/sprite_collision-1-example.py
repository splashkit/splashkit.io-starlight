from splashkit import *

# Open a new window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmaps
sk_bmp = load_bitmap("skbox", "skbox.png")
file_bmp = load_bitmap("file", "file_image.png")
bug_bmp = load_bitmap("bug", "bug_image.png")

# Create sprites from the bitmaps
sk_sprite = create_sprite(sk_bmp)
file_sprite = create_sprite(file_bmp)
bug_sprite = create_sprite(bug_bmp)

# Define sprite positions
sk_sprite_loc = point_at(50, 50)
file_sprite_loc = point_at(20, 20)
bug_sprite_loc = point_at(200, 150)

# Set sprite positions
sprite_set_position(sk_sprite, sk_sprite_loc)
sprite_set_position(file_sprite, file_sprite_loc)
sprite_set_position(bug_sprite, bug_sprite_loc)

# Clear the screen and draw sprites
clear_screen(color_white())
draw_sprite(sk_sprite)
draw_sprite(file_sprite)
draw_sprite(bug_sprite)

# Check for collisions
if sprite_collision(sk_sprite, file_sprite):
    write_line("SplashKit got a new file!")

if sprite_collision(sk_sprite, bug_sprite):
    write_line("SplashKit has bugs!")

# Refresh the screen and delay before closing
refresh_screen()
delay(4000)

close_all_windows()