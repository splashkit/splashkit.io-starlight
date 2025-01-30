from splashkit import *

# Variable Declarations
line = line_from(100, 300, 500, 300)

# Create window
window = open_window("Select Point", 600, 600)

while not quit_requested():
    # Display line
    clear_screen(color_white())
    draw_line_record(color_black(), line)

    if point_on_line(mouse_position(), line):
        # Draw text if cursor is on line
        draw_text_no_font_no_size("Point on line: " + point_to_string(mouse_position()), color_black(), 200, 450)

    refresh_screen()
    process_events()

close_window(window)