from splashkit import *

window = open_window("Point In Circle", 800, 600)
circle = circle_at_from_points(400, 300, 100)
mouse_pt = Point2D
text = str
circle_clr = Color

while (not quit_requested()):
    process_events()

    mouse_pt = mouse_position()

    # Update text and circle colour based on the mouse position in relation to the circle
    if (point_in_circle(mouse_pt, circle)):
        circle_clr = color_red()
        text = "Point in the Circle!"
    else:
        circle_clr = color_green()
        text = "Point not in the Circle!"

    clear_screen_to_white()
    draw_circle_record(circle_clr, circle)
    draw_text_no_font_no_size(text, color_red(), 100, 100)
    refresh_screen()

close_window(window)