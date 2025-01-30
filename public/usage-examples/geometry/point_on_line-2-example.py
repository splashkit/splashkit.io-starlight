from splashkit import *

# Variable Declarations
bar_x = 100
slider = line_from(100, 300, 500, 300)
bar = line_from(bar_x, 310, bar_x, 290)
percent = 0
bar_selected = False

window = open_window("Volume Slider", 600, 600)

while not quit_requested():
    process_events()

    # Check if user has clicked on the bar Line
    if (mouse_down(MouseButton.left_button) and point_on_line(mouse_position(), bar)):
        bar_selected = True

    # Check if user has released mouse button
    if (mouse_up(MouseButton.left_button)):
        bar_selected = False

    # Update bar location
    if (bar_selected and mouse_x() >= 100 and mouse_x() <= 500):
        bar_x = mouse_x()                             # sets bar_x value to mouse x value
        percent = int((bar_x - 100) / (500 - 100) * 100) # convert bar_x position to percent value
        bar = line_from(bar_x, 310, bar_x, 290)

    # Draw lines and volume text
    clear_screen(color_white())
    draw_line_record(color_black(), bar)
    draw_line_record(color_black(), slider)
    draw_text_no_font_no_size("Volume: " + str(percent), color_black(), 200, 450)
    refresh_screen()

close_window(window)