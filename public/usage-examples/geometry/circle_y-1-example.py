from splashkit import *

# Create a circle (with random y position value between 200 - 400)
circle = circle_at_from_points(400, rnd_int(200) + 200, 200)

open_window("Circle Y", 800, 600)

# Draw the circle and y coordinate on window
clear_screen(color_white())
draw_circle_record(color_red(), circle)
draw_text_no_font_no_size("Circle Y: " + str(circle_y(circle)), color_black(), 100, 100)

# Draw a line to show the circle Y coordinate
draw_line(color_black(), 0, circle_y(circle), screen_width(), circle_y(circle))

# Draw 10 circles with radius of 50 and the same circle y coordinate
for i in range(10):
    draw_circle(color_blue(), i * 60 + 100, circle_y(circle), 50)
refresh_screen()
    
delay(4000)
close_all_windows()