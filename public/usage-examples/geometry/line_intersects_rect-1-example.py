from splashkit import *

open_window("Avoid the Rectangle", 800, 600)

# Define line's start point and a static rectangle
start_pt = point_at(150, 100)
rectangle = rectangle_from(250, 200, 300, 200)

# Define a draggable line
end_pt = mouse_position()
line = line_from_point_to_point(start_pt, end_pt)

while not quit_requested():
    process_events()

    # Update draggable line
    end_pt = mouse_position()
    line = line_from_point_to_point(start_pt, end_pt)

    # Draw the line and rectangle
    clear_screen(color_white())
    draw_line_record(color_black(), line)
    draw_circle_record(color_black(), circle_at(start_pt, 5))
    draw_circle_record(color_black(), circle_at(end_pt, 5))
    draw_rectangle_record(color_black(), rectangle)

    # Check for intersection and display results
    if line_intersects_rect(line, rectangle):
        draw_text_no_font_no_size("Line and Rectangle intersect", color_red(), 250, 100)
    else:
        draw_text_no_font_no_size("Line and Rectangle do not intersect", color_green(), 250, 100)
    refresh_screen()

close_all_windows()