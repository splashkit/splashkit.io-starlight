from splashkit import *

# Open a new window and initialize to a window variable
window = open_window("Traffic Lights", 800, 600)

clear_screen(color_white())

# Use function to place 3 circles in destination window as traffic lights
fill_circle_on_window(window, color_red(), 400, 100, 50)
fill_circle_on_window(window, color_yellow(), 400, 250, 50)
fill_circle_on_window(window, color_green(), 400, 400, 50)

refresh_screen()
delay(5000)

# Close all windows
close_all_windows()
