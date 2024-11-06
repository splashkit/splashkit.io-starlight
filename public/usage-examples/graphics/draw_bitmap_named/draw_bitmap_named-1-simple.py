from splashkit import *

open_window("Basic Bitmap Drawing", 315, 330)

load_bitmap("skbox", "skbox.png") # Load bitmap image

while (not quit_requested()):
    process_events()

    clear_screen(rgb_color(67, 80, 175))
    draw_bitmap_named("skbox", 50, 50); # draw bitmap image
    refresh_screen()
close_all_windows()