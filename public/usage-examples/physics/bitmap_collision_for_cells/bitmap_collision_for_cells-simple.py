from splashkit import *

# Open the window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmaps
sk_bmp = load_bitmap("skbox", "skbox.png")
file_bmp = load_bitmap("file", "file_image.png")
bug_bmp = load_bitmap("bug", "bug_image.png")

# Set the bitmap locations using Point2D
sk_bmp_loc = Point2D()
sk_bmp_loc.x = 50
sk_bmp_loc.y = 50

file_bmp_loc = Point2D()
file_bmp_loc.x = 20
file_bmp_loc.y = 20

bug_bmp_loc = Point2D()
bug_bmp_loc.x = 200
bug_bmp_loc.y = 150

# Clear the screen and draw the bitmaps
clear_screen(color_white())
draw_bitmap(sk_bmp, sk_bmp_loc.x, sk_bmp_loc.y)
draw_bitmap(file_bmp, file_bmp_loc.x, file_bmp_loc.y)
draw_bitmap(bug_bmp, bug_bmp_loc.x, bug_bmp_loc.y)

# Check for collisions
if bitmap_collision_for_cells(sk_bmp, 50, 50, 50, file_bmp, 20, 20, 20):
    write_line("SplashKit got a new file!")

if bitmap_collision_for_cells(sk_bmp, 50, 50, 50, bug_bmp, 200, 200, 150):
    write_line("SplashKit has bugs!")

# Refresh the screen and wait
refresh_screen()
delay(4000)

# Close all windows
close_all_windows()
