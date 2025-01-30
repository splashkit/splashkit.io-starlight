from splashkit import *

open_window("Closest point", 600, 600)

# Declare variables
circle_pt = screen_center()
circle = circle_at(circle_pt, 100)
mouse_pt = mouse_position()
closest_point = None

while (not quit_requested()):
    process_events()

    # Get "current" Mouse Position
    mouse_pt = mouse_position()

    # Calculate the closest distance between the current mouse position and the circle
    closest_point = closest_point_on_circle(mouse_pt, circle)

    # Draw circle and indicated points
    clear_screen_to_white()
    draw_circle_record(color_black(), circle)
    fill_circle(color_blue(), mouse_pt.x, mouse_pt.y, 5)
    fill_circle(color_red(), closest_point.x, closest_point.y, 5)
    refresh_screen()

close_all_windows()