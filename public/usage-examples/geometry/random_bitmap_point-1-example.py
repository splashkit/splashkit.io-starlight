from splashkit import *

# Create Window and empty bitmap
open_window("Random Bitmap Points with Triangles", 600, 600)
bmp = create_bitmap("Random Triangles", 600, 600)

for _ in range(10):
    # Create triangle using random points on bitmap
    triangle = triangle_from(
        random_bitmap_point(bmp),
        random_bitmap_point(bmp),
        random_bitmap_point(bmp))

    fill_triangle_on_bitmap_record(bmp, random_color(), triangle)

# Draw the bitmap
clear_screen(color_white_smoke())
draw_bitmap(bmp, 0, 0)
refresh_screen()

delay(5000)
close_all_windows()