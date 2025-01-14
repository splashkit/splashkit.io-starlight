from splashkit import *

open_window("Point At Origin", 800, 600)

# Create a point at origin
point = point_at_origin()

# Create "sun" at the origin point
clear_screen(color_white())
for i in range(200, 10, -1):
    fill_circle(rgb_color(255, i + 50, i % 30), point.x, point.y, i)
refresh_screen()

delay(4000)
close_all_windows()