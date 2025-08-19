from splashkit import *

open_window("Draw Rectangle", 800, 600)
clear_screen(color_white())

for i in range(21):
    x = i * 40 - 40
    y = 600 - i * 30

    # Draw rectangle using x and y above with width 40 and height 30
    draw_rectangle(random_rgb_color(255), x, y, 40, 30)

refresh_screen()
delay(4000)
close_all_windows()