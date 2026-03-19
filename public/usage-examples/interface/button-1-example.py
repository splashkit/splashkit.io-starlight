from splashkit import *

open_window("Button Click Counter", 800, 600)

# Track click counts for each button
red_count = 0
blue_count = 0
green_count = 0

while not quit_requested():
    process_events()
    clear_screen_to_white()

    # Show instructions for the user
    draw_text_no_font_no_size("Click the buttons to increment counters", color_black(), 10, 10)

    # Create a panel with three buttons
    if start_panel("Click Counter", rectangle_from(50, 50, 200, 200)):
        # Check if each button is clicked and update counts
        if button("Red"):
            red_count += 1
        if button("Blue"):
            blue_count += 1
        if button("Green"):
            green_count += 1
        end_panel("Click Counter")

    # Display each button's click count on the window
    draw_text_no_font_no_size("Red clicks: " + str(red_count), color_red(), 300, 100)
    draw_text_no_font_no_size("Blue clicks: " + str(blue_count), color_blue(), 300, 130)
    draw_text_no_font_no_size("Green clicks: " + str(green_count), color_green(), 300, 160)

    refresh_screen_with_target_fps(60)

close_all_windows()
