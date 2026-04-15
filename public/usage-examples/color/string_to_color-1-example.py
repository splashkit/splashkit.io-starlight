from splashkit import *

open_window("String To Color", 800, 600)

# Change this string to get different colors 
color_hex = "#921e64d9"
color = string_to_color(color_hex)
rectangle = rectangle_from(200, 100, 400, 300)

clear_screen(color_white())
fill_rectangle_record(color, rectangle)
draw_text_no_font_no_size("Current color's RGBA hex value is " + color_hex, color_black(), 235, 450)
draw_text_no_font_no_size("It's RGB values are: R-" + str(red_of(color)) + ", G-" + str(green_of(color)) + ", B-" + str(blue_of(color)), color_black(), 235, 470)
refresh_screen()

delay(5000)

close_all_windows()