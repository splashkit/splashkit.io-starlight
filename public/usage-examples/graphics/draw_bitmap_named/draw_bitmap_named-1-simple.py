from splashkit import *

# Open Window
open_window("Basic Bitmap Drawing", 315, 330)

# Load bitmap image
load_bitmap("skbox", "skbox.png")

while (not quit_requested()):
    process_events()

    clear_screen(rgb_color(67, 80, 175))
    draw_bitmap_named("skbox", 50, 50); # draw bitmap image
    refresh_screen()
close_all_windows()