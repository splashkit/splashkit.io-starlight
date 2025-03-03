from splashkit import *

open_window("Random Colourful Triangles", 800, 600)

clear_screen_to_white()
for i in range(10):
    # Random point 1 for the triangle (x1,y1)
    x1 = rnd_range(0,800)
    y1 = rnd_range(0,600)
    
    # Random point 2 for the triangle (x2,y2)
    x2 = rnd_range(0,800)
    y2 = rnd_range(0,600)
    
    # Random point 3 for the triangle (x3,y3)
    x3 = rnd_range(0,800)
    y3 = rnd_range(0,600)

    # Draw triangle using the random points above
    draw_triangle(random_rgb_color(255), x1, y1, x2, y2, x3, y3)

refresh_screen()
delay(4000)

close_all_windows()