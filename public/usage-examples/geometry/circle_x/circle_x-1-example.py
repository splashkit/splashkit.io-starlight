from splashkit import *

# Create a circle (with random x position value bewteen 200 - 600)
circle = circle_at_from_points(rnd_int(400) + 200, 300, 200)

open_window("Circle X", 800, 600)

# Draw the circle and x coordinate on window
clear_screen(color_white())
draw_circle_record(color_red(), circle)
draw_text_no_font_no_size(f"Circle X: {circle_x(circle)}", color_black(), 100, 100)
refresh_screen()

delay(4000)
close_all_windows()