from splashkit import *

# Create Window
open_window("Night Sky", 600, 600)

clear_screen(color_black())
for _ in range(1000):
    # Set random pixel location on screen
    pixel = random_screen_point()

    # Draw the pixel
    draw_pixel_at_point(random_rgb_color(255), pixel)
refresh_screen()

delay(5000)
close_all_windows()