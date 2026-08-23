from splashkit import *

open_window("Saturation Of", 800, 600)

color = random_rgb_color(255)
# Function used here ↓
color_saturation = round(saturation_of(color), 6)
rectangle = rectangle_from(200, 100, 400, 300)

clear_screen(color_white())
fill_rectangle_record(color, rectangle)
draw_text_no_font_no_size("This color's saturation is " + str(color_saturation), color_black(), 235, 450)
draw_text_no_font_no_size("It's RGBA values are: R-" + str(red_of(color)) + ", G-" + str(green_of(color)) + ", B-" + str(blue_of(color)) + ", A-" + str(alpha_of(color)), color_black(), 235, 470)
refresh_screen()

delay(5000)

close_all_windows()