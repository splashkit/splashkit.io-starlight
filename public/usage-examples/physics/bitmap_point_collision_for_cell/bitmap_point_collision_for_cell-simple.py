from splashkit import *

# Open the window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmap
sk_bmp = load_bitmap("skbox", "skbox.png")

# Set the bitmap and dot locations using Point2D
sk_bmp_loc = Point2D()
sk_bmp_loc.x = 50
sk_bmp_loc.y = 50

black_dot_loc = Point2D()
black_dot_loc.x = 20
black_dot_loc.y = 20

red_dot_loc = Point2D()
red_dot_loc.x = 200
red_dot_loc.y = 150

# Clear the screen and draw the bitmap and dots
clear_screen(color_white())
draw_bitmap(sk_bmp, sk_bmp_loc.x, sk_bmp_loc.y)
fill_circle_record(color_black(), circle_at(black_dot_loc, 2))
fill_circle_record(color_red(), circle_at(red_dot_loc, 2))

# Check for collisions
if bitmap_point_collision_for_cell(sk_bmp, 50, 50, 50, 20, 20):
    write_line("Black Dot Collision")
if bitmap_point_collision_for_cell(sk_bmp, 50, 50, 50, 200, 200):
    write_line("Red Dot Collision!")

# Refresh the screen and wait
refresh_screen()
delay(4000)

# Close all windows
close_all_windows()
