from splashkit import *

# open a window
window = open_window("Clear Window", 600, 200)

# main loop
while not window_close_requested(window):
    # get user events
    process_events()
    
    # clear screen
    clear_window(window, color_white())
    
    if button_at_position("Red!", rectangle_from(75, 85, 100, 30)):
        clear_window(window, color_red())
        refresh_screen()
        delay(1000)
        continue
    
    if button_at_position("Green!", rectangle_from(250, 85, 100, 30)):
        clear_window(window, color_green())
        refresh_screen()
        delay(1000)
        continue
    
    if button_at_position("Blue!", rectangle_from(425, 85, 100, 30)):
        clear_window(window, color_blue())
        refresh_screen()
        delay(1000)
        continue
    
    # finally draw interface, then refresh screen
    draw_interface()
    refresh_screen()

# close all open windows
close_all_windows()