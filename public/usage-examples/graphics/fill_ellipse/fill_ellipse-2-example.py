from splashkit import *

open_window("Clover Drawing with Fill Ellipse", 1000, 600)

clear_screen(color_white())

fill_ellipse(color_green(), 150, 225, 400, 200) 
fill_ellipse(color_green(), 375, 0, 200, 400) 
fill_ellipse(color_green(), 400, 225, 400, 200) 
fill_rectangle(color_brown(), 470, 400, 10, 150)
refresh_screen()

delay(4000)

close_all_windows()
