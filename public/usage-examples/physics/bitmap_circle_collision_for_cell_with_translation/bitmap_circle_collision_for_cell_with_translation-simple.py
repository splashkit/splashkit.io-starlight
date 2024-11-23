from splashkit import *

# Open the window
open_window("Bitmap Collisions", 315, 330)

# Load the bitmap and set its location
sk_bmp = load_bitmap("skbox", "skbox.png")
bmp_loc = Point2D()
bmp_loc.x = 50
bmp_loc.y = 50

# Create a translation matrix for the bitmap
bmp_matrix = translation_matrix_to_point(bmp_loc)

# Define the circles and their locations
black_circle = Circle()
black_circle.center.x = 20
black_circle.center.y = 20
black_circle.radius = 20

red_circle = Circle()
red_circle.center.x = 150
red_circle.center.y = 150
red_circle.radius = 20

# Clear the screen and draw the elements
clear_screen(rgb_color(67, 80, 175))
draw_bitmap(sk_bmp, bmp_loc.x, bmp_loc.y)
draw_circle_record(color_black(), black_circle)
draw_circle_record(color_red(), red_circle)

# Check for collisions using the matrix
if bitmap_circle_collision_for_cell_with_translation(sk_bmp, 50, bmp_matrix, black_circle):
    write_line("Black Circle Collision!")
if bitmap_circle_collision_for_cell_with_translation(sk_bmp, 50, bmp_matrix, red_circle):
    write_line("Red Circle Collision!")

# Refresh the screen, wait, and close all windows
refresh_screen()
delay(4000)
close_all_windows()
