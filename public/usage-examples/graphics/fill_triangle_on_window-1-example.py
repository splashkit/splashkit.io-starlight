from splashkit import *

blue_window = open_window("Blue Triangle", 200, 200)
red_window = open_window("Red Triangle", 200, 200)
move_window_to(red_window, window_x(blue_window) + window_width(blue_window), window_y(blue_window))

# Fill a blue triangle on the first window
clear_window(blue_window, color_white())
fill_triangle_on_window(blue_window, color_blue(), 50, 100, 100, 50, 150, 100)
refresh_window(blue_window)

# Fill a red triangle on the second window
clear_window(red_window, color_white())
fill_triangle_on_window(red_window, color_red(), 50, 50, 100, 100, 150, 50)
refresh_window(red_window)

delay(10000)

close_window(blue_window)
close_window(red_window)