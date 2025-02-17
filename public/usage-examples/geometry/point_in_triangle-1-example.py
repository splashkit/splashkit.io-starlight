from splashkit import *

triangle = triangle_from(point_at(700, 200), point_at(500, 1), point_at(200, 500))
mouse_pt = Point2D
text = str
triangle_clr = Color

open_window("Point In Triangle", 800, 600)

while (not quit_requested()):
    process_events()

    mouse_pt = mouse_position()

    # Update text and triangle colour based on the mouse position in relation to the triangle
    if (point_in_triangle(mouse_pt, triangle)):
        triangle_clr = color_red()
        text = "Point in the triangle!"
    else:
        triangle_clr = color_green()
        text = "Point not in the triangle!"

    clear_screen_to_white()
    draw_triangle_record(triangle_clr, triangle)
    draw_text_no_font_no_size(text, color_red(), 100, 100)
    refresh_screen()

close_all_windows()