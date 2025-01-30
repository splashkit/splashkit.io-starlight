from splashkit import *

open_window("Distance From Center", 600, 600)

# Define the variables
center_pt = screen_center()
mouse_pt = None
pt_pt_distance = 0 # Store the "Point Point Distance"

while (not quit_requested()):
    process_events()

    # Get "current" Mouse Position
    mouse_pt = mouse_position()

    # Calculate the distance between the center point and the current mouse position
    pt_pt_distance = point_point_distance(center_pt, mouse_pt)

    # Draw line and distance between center of window (filled circle) and mouse point
    clear_screen_to_white()
    fill_circle(color_red(), center_pt.y, center_pt.y, 5)
    draw_line_point_to_point(color_blue(), center_pt, mouse_pt)
    draw_text_no_font_no_size(str(pt_pt_distance), color_black(), mouse_pt.x + 10, mouse_pt.y - 10)
    refresh_screen()

# Close all opened windows
close_all_windows()