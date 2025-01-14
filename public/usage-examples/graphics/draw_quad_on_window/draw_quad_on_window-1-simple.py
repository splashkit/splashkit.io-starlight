from splashkit import *

# Create diamond shaped quads
q1 = quad_from(400, 200, 300, 300, 300, 0, 200, 200)
q2 = quad_from(400, 210, 310, 300, 600, 300, 400, 390)
q3 = quad_from(200, 400, 300, 300, 300, 600, 400, 400)
q4 = quad_from(200, 390, 290, 300, 0, 300, 200, 210)

# Create two Windows
window_1 = open_window("Diamonds On Window 1", 600, 600)
window_2 = open_window("Diamonds On Window 2", 600, 600)

# Move windows to see both side by side
move_window_to(window_1, 0, 0)
move_window_to(window_2, window_width(window_1), 0)

clear_screen(color_white())

# Draw the first and second quad on first window
draw_quad_on_window(window_1, color_black(), q1)
draw_quad_on_window(window_1, color_green(), q2)

# Draw the third and fourth quad on second window
draw_quad_on_window(window_2, color_red(), q3)
draw_quad_on_window(window_2, color_blue(), q4)

refresh_screen()
delay(5000)
close_all_windows()
