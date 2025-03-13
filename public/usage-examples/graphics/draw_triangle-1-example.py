from splashkit import *

open_window("Triangle Coordinates", 800, 400)

# Top middle triangle point
x1 = 400
y1 = 100

# Bottom left triangle point
x2 = 200
y2 = 300

# Bottom right triangle point
x3 = 600
y3 = 300

clear_screen_to_white()

# Draw triangle using the points above
draw_triangle(color_red(), x1, y1, x2, y2, x3, y3)

# Draw triangle information
fill_circle(color_blue(), x1, y1, 3)
fill_circle(color_blue(), x2, y2, 3)
fill_circle(color_blue(), x3, y3, 3)
draw_text_no_font_no_size(f"(x={x1}, y={y1})", color_blue(), x1 - 50, y1 - 20)
draw_text_no_font_no_size(f"(x={x2}, y={y2})", color_blue(), x2 - 120, y2)
draw_text_no_font_no_size(f"(x={x3}, y={y3})", color_blue(), x3 + 10, y3)
refresh_screen()
delay(10000)

close_all_windows()