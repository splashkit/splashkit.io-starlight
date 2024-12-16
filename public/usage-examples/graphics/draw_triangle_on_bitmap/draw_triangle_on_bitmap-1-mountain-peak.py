from splashkit import *

# Create a window and bitmap for the mountain scene
window = open_window("Window", 400, 300)
bitmap = create_bitmap("mountain", 400, 300)

# Fill background with light blue color
clear_bitmap(bitmap, color_light_blue())

# Draw right peak (smallest)
draw_triangle_on_bitmap(bitmap, color_gray(), 
                       175, 250,   # Left base
                       275, 175,   # Peak
                       375, 250)   # Right base

# Draw left peak (medium)
draw_triangle_on_bitmap(bitmap, color_gray(),
                       25, 250,    # Left base
                       125, 125,   # Peak
                       225, 250)   # Right base

# Draw center peak (tallest)
draw_triangle_on_bitmap(bitmap, color_gray(),
                       100, 250,   # Left base
                       200, 100,   # Peak
                       300, 250)   # Right base

while not window_close_requested(window):
    process_events()
    # Draw the bitmap to the window
    draw_bitmap(bitmap, 0, 0)
    refresh_screen()

free_bitmap(bitmap)
close_all_windows()