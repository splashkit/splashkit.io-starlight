from splashkit import *

open_window("Draw Ellipse", 800, 600)

clear_screen(color_white())
# Draw 30 ellipses
for i in range(30):
    width = 600 - i * 20    # Decrease width by 20 every loop
    height = 400 - i * 10   # Decrease height by 10 every loop
    x = 100 + i * 10        # Increase x position by 10 every loop
    y = 100 + i * 5         # Increase y position by 5 every loop

    # Draw ellipse based on the given data
    draw_ellipse(random_rgb_color(255), x, y, width, height)
refresh_screen()

delay(4000)
close_all_windows()