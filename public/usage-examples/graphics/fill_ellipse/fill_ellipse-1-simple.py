from splashkit import *

open_window("Fill Ellipse", 800, 600)

clear_screen(color_white())

fill_ellipse(color_blue(), 200, 200, 400, 200) 
# Added a rectangle with the same arguments as above for x, y, width, and height 
draw_rectangle(color_red(), 200, 200, 400, 200)
refresh_screen()

delay(4000)
close_all_windows()
