from splashkit import *

open_window("Glowing Blue Circle", 600, 600)

outer_circle_radius = 255

# Create a circle in center of window
outer_circle = circle_at(screen_center(), outer_circle_radius)

# Get center point of circle
circle_centre = center_point(outer_circle)

while not quit_requested():
    process_events()

    # Draw glowing circle
    clear_screen(color_black())
    for i in range(outer_circle_radius, 5, -1):
        fill_circle_record(rgb_color(0, 0, 255 - i), circle_at(circle_centre, i))
    refresh_screen()
close_all_windows()