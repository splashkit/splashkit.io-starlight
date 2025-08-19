from splashkit import *

# Open a new window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmaps
sk_bmp = load_bitmap("skbox", "skbox.png")
file_bmp = load_bitmap("file", "file_image.png")
bug_bmp = load_bitmap("bug", "bug_image.png")

# Create a sprite using the bitmap
sk_sprite = create_sprite(sk_bmp)

# Define positions
sk_sprite_loc = point_at(50, 50)
file_bmp_loc = point_at(20, 20)
bug_bmp_loc = point_at(200, 150)

# Set sprite position
sprite_set_position(sk_sprite, sk_sprite_loc)

# Clear the screen and draw all elements
clear_screen(color_white())
draw_sprite(sk_sprite)
draw_bitmap(file_bmp, file_bmp_loc.x, file_bmp_loc.y)
draw_bitmap(bug_bmp, bug_bmp_loc.x, bug_bmp_loc.y)

# Check for collisions
if sprite_bitmap_collision(sk_sprite, file_bmp, file_bmp_loc.x, file_bmp_loc.y):
    write_line("SplashKit got a new file!")

if sprite_bitmap_collision(sk_sprite, bug_bmp, bug_bmp_loc.x, bug_bmp_loc.y):
    write_line("SplashKit has bugs!")

# Refresh the screen and delay before closing
refresh_screen()
delay(4000)

close_all_windows()