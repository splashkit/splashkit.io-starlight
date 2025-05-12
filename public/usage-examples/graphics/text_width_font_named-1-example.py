from splashkit import *

open_window("Text Width", 680, 200)
clear_screen(color_white())

load_font("LOTR", "lotr.ttf")
set_font_style_name_as_string("LOTR", FontStyle.bold_font)
draw_text_font_as_string("Ringbearer", color_black(), "LOTR", 100, 30, 20)

#Getting the width of the text to fill a rectange of that width
width = text_width_font_named("Ringbearer", "LOTR", 100)
fill_rectangle(color_black(), 30, 130, width, 10)
refresh_screen()

delay(5000)
close_all_windows()