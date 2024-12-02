from splashkit import *

open_window("Fill Triangle Example", 800, 600)

clear_screen_to_white()
fill_triangle(color_red(), 100, 100, 200, 200, 300, 100)
refresh_screen()

delay(5000)
close_all_windows()