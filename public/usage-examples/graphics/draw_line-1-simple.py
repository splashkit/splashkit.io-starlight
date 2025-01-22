from splashkit import *

open_window("Colourful Starburst", 600, 600)
clear_screen(color_black())

# Draws starburst pattern with changing colours to window
draw_line(color_yellow(), 0, 0, 600, 600)
draw_line(color_green(), 0, 150, 600, 450)
draw_line(color_teal(), 0, 300, 600, 300)
draw_line(color_blue(), 0, 450, 600, 150)
draw_line(color_violet(), 0, 600, 600, 0)
draw_line(color_purple(), 150, 0, 450, 600)
draw_line(color_pink(), 300, 0, 300, 600)
draw_line(color_red(), 450, 0, 150, 600)
draw_line(color_orange(), 600, 0, 0, 600)

refresh_screen()
delay(5000)
close_all_windows()
