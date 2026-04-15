from splashkit import *

# Declare constants and variables
FPS = 60 # Set frame rate to 60 frames per second
time = 0
scale_factor = 1

# Create a 600 x 600 bitmap with a white "ring" on black background
bmp = create_bitmap("ring", 600, 600)
clear_bitmap(bmp, color_black())
fill_circle_on_bitmap(bmp, color_white(), 300, 300, 300)
fill_circle_on_bitmap(bmp, color_black(), 300, 300, 200)

open_window("Mesmerising Bitmap Scaling", 800, 600)

while not quit_requested():
    process_events()

    # Increment the time and calculate the scale factor
    time += 1.0 / FPS
    scale_factor = time * time

    # Reset time if the bitmap is over 2.5 times its initial size
    if scale_factor > 2.5:
        time = 0

    # Create the draw options that will scale the bitmap
    opts = option_scale_bmp(scale_factor, scale_factor)

    # Draw the scaled bitmap onto the window and refresh
    clear_screen(color_black())
    draw_bitmap_with_options(bmp, 100, 0, opts)
    refresh_screen_with_target_fps(FPS)

# Clean up
close_all_windows()