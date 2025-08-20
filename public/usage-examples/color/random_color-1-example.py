from splashkit import *

open_window("Colour Changing Button", 800, 600)

# Declare cursor point, rectangular button and store colour
button_color = color_green()
mouse_pt = Point2D
button = rectangle_from(250, 250, 300, 100)

while not quit_requested():
    process_events()

    mouse_pt = mouse_position()
    
    # Check if the cursor is on the button
    if point_in_rectangle(mouse_pt, button):
        # Change the colour to a random colour
        if mouse_clicked(MouseButton.left_button):
            button_color = random_color()

    clear_screen(color_white())
    draw_text_no_font_no_size("Click the button to change its Colour", color_black(), 250, 200)
    draw_rectangle_record(color_black(), button)
    fill_rectangle_record(button_color, button)
    refresh_screen()

close_all_windows()