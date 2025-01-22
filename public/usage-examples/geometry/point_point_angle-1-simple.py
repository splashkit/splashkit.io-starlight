from splashkit import *

# Define the variables
window = open_window('How Does "Point Point Angle" Work?', 400, 400)
arial = load_font("arial", "arial.ttf")
horizontal_line = line_from(0, screen_height() / 2, screen_width(), screen_height() / 2)
vertical_line = line_from(screen_width() / 2, 0, screen_width() / 2, screen_height())
zero_line = line_from(screen_width() / 2, screen_height() / 2, screen_width(), screen_height() / 2)
outer_circle = circle_at(screen_center(), 100)
center_circle = circle_at(screen_center(), 4)
center_pt = screen_center()
mouse_pt = None
angle = ""

pt_pt_angle = 0  # Store the "Point Point Angle"

while not quit_requested():
    process_events()

    # Get "current" Mouse Position
    mouse_pt = mouse_position()

    # Calculate the angle between the center point and the current mouse position
    pt_pt_angle = point_point_angle(center_pt, mouse_pt)

    # Round to 2 decimal places for nicer output
    angle = str(round(pt_pt_angle, 2))

    # Draw background annotation
    clear_screen(color_white())
    draw_line_record(color_black(), horizontal_line)
    draw_line_record(color_black(), vertical_line)
    draw_circle_record(color_black(), outer_circle)
    draw_line_record(color_red(), zero_line)
    fill_circle_record(color_red(), center_circle)
    draw_text("0", color_blue(), arial, 16, 350, screen_height() / 2 - 20)
    draw_text("o", color_blue(), arial, 10, 360, screen_height() / 2 - 23)
    draw_text("90", color_blue(), arial, 16, screen_width() / 2 + 5, 350)
    draw_text("o", color_blue(), arial, 10, screen_width() / 2 + 24, 347)
    draw_text("-90", color_blue(), arial, 16, screen_width() / 2 + 5, 35)
    draw_text("o", color_blue(), arial, 10, screen_width() / 2 + 29, 32)
    draw_text("180", color_blue(), arial, 16, 30, screen_height() / 2 - 20)
    draw_text("o", color_blue(), arial, 10, 58, screen_height() / 2 - 23)
    draw_line_point_to_point(color_red(), center_pt, mouse_position())
    fill_rectangle(color_green(), mouse_x() + 10, mouse_y() - 10, 80, 30)
    draw_text(angle, color_white(), arial, 16, mouse_x() + 20, mouse_y() - 5)
    draw_text("o", color_white(), arial, 10, mouse_x() + 20 + text_width(angle, arial, 16), mouse_y() - 8)
    refresh_screen()

close_all_windows()
free_all_fonts()
