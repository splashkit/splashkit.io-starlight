from splashkit import *

open_window("Draw Circles", 800, 600)

# Create circles with different radii
circle1 = circle_at(screen_center(), 50)
circle2 = circle_at(screen_center(), 100)

clear_screen(color_white())

# Draw the circles with different colors
draw_circle_record(color_red(), circle1)
draw_circle_record(color_blue(), circle2)
draw_circle_record(color_orange(), circle_at(screen_center(), 150))
draw_circle_record(color_green(), circle_at(screen_center(), 200))

refresh_screen()

delay(4000)
close_all_windows()
