from splashkit import *

mouse_position_text = "Click to see coordinates..."

open_window("Mouse Clicked Location", 600, 600)

while not quit_requested():
    process_events()

    # check for mouse click
    if mouse_clicked(MouseButton.left_button):
        mouse_position_text = "Mouse clicked at " + point_to_string(mouse_position())
    
    # Print mouse position to screen
    clear_screen(color_ghost_white())
    draw_text_no_font_no_size(mouse_position_text, color_black(), 100, 300)
    refresh_screen()

close_all_windows()