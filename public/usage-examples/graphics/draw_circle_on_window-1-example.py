from splashkit import *

window = open_window("Bubbles", 800, 600)

clear_screen(color_white())
for _ in range(50):
    # Set random circle values
    x = rnd_int(800)
    y = rnd_int(600)
    radius = rnd_int(50)
    random_color = rgb_color(rnd_int(255), rnd_int(255), rnd_int(255))

    # Draw the circle base on the random data
    draw_circle_on_window(window, random_color, x, y, radius)
refresh_screen()

delay(4000)
close_all_windows()