from splashkit import *

open_window("Lines Intersect", 800, 600)

# Define points for the lines
start_point_a = Point2D()
start_point_a.x = 100
start_point_a.y = 150
end_point_a = Point2D()
end_point_a.x = 500
end_point_a.y = 550

start_point_b = Point2D()
start_point_b.x = 100
start_point_b.y = 550
end_point_b = Point2D()
end_point_b.x = 500
end_point_b.y = 150

start_point_c = Point2D()
start_point_c.x = 550
start_point_c.y = 150
end_point_c = Point2D()
end_point_c.x = 550
end_point_c.y = 500

# Draw the lines
demo_line_a = line_from_point_to_point(start_point_a, end_point_a)
draw_line_record(color_red(), demo_line_a)
draw_text_no_font_no_size(
    "A", color_black(), start_point_a.x - 20, start_point_a.y - 10)

demo_line_b = line_from_point_to_point(start_point_b, end_point_b)
draw_line_record(color_blue(), demo_line_b)
draw_text_no_font_no_size(
    "B", color_black(), start_point_b.x - 20, start_point_b.y - 10)

demo_line_c = line_from_point_to_point(start_point_c, end_point_c)
draw_line_record(color_green(), demo_line_c)
draw_text_no_font_no_size(
    "C", color_black(), start_point_c.x - 20, start_point_c.y - 10)

# Check intersections
intersect_ab = lines_intersect(demo_line_a, demo_line_b)
intersect_ac = lines_intersect(demo_line_a, demo_line_c)

# Display intersection results
draw_text_no_font_no_size(
    "A and B intersect: " + ("Yes" if intersect_ab else "No"), color_black(), 150, 130)
draw_text_no_font_no_size(
    "A and C intersect: " + ("Yes" if intersect_ac else "No"), color_black(), 150, 150)

refresh_screen()
delay(5000)

close_all_windows()