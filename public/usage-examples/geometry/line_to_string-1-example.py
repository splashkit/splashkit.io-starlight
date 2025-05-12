from splashkit import *

open_window("Line To String", 800, 600)

# Define points for the line
start_point = Point2D()
start_point.x = 100
start_point.y = 150

end_point = Point2D()
end_point.x = 500
end_point.y = 550

# Create a line from start and end points
demo_line = line_from_point_to_point(start_point, end_point)
draw_line_record(color_red(), demo_line)

# Find the text description of the line
desc = line_to_string(demo_line)
draw_text_no_font_no_size(desc, color_black(), 110, 130)

refresh_screen()
delay(5000)

close_all_windows()