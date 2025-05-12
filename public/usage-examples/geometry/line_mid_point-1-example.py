from splashkit import *

open_window("Line Mid Point", 800, 600)

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

# Find the mid point and mark it
mid_point = line_mid_point(demo_line)
draw_circle(color_black(), mid_point.x, mid_point.y, 2)

# Display the midpoint coordinates
draw_text_no_font_no_size("Midpoint Coordinates: " +
                          str(mid_point.x) + ", " + str(mid_point.y), color_black(), mid_point.x + 10, mid_point.y - 10)

refresh_screen()
delay(5000)

close_all_windows()