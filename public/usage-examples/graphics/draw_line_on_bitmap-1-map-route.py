from splashkit import *

# Create a Window and bitmap for the map
window = open_window("Window", 400, 300)
bitmap = create_bitmap("map", 400, 300)

# Fill background with white
clear_bitmap(bitmap, color_white())

# Draw the route line and points
draw_line_on_bitmap(bitmap, color_green(),
                   100, 80,    # Starting point (x1, y1)
                   300, 220)   # End point (x2, y2)
fill_circle_on_bitmap(bitmap, color_red(), 100, 80, 5)    # Start point
fill_circle_on_bitmap(bitmap, color_red(), 300, 220, 5)   # End point

while not window_close_requested(window):
    process_events()
    # Draw the bitmap to the current window
    draw_bitmap(bitmap, 0, 0)
    refresh_screen()

free_bitmap(bitmap)
close_all_windows()