from splashkit import *

open_window("Draw Circle Example", 800, 600)

clear_screen(color_white())

# Draw a large red filled circle in the center
fill_circle(color_red(), 400, 300, 100)

# Draw circles with different colors, sizes, and positions
draw_circle(color_blue(), 200, 150, 80)
draw_circle(color_green(), 600, 150, 60)
draw_circle(color_orange(), 200, 450, 70)
draw_circle(color_purple(), 600, 450, 65)

# Draw smaller circles with varying colors
for i in range(8):
    radius = 20 + i * 5
    x = 400 + (i - 4) * 80
    y = 100
    draw_circle(random_rgb_color(255), x, y, radius)

refresh_screen()

delay(5000)
close_all_windows()
