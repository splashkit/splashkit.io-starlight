from splashkit import *

open_window("House Drawing", 800, 600)

clear_screen(color_white())
refresh_screen()
delay(1000)

fill_ellipse(color_bright_green(), 0, 400, 800, 400)
refresh_screen()
delay(1000)

fill_rectangle(color_gray(), 300, 300, 200, 200)
refresh_screen()
delay(1000)

fill_triangle(color_red(), 250, 300, 400, 150, 550, 300)
refresh_screen()
delay(5000)

close_all_windows()
