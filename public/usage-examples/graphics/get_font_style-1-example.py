from splashkit import *

open_window("Get Font Style", 800, 600)

style_number = -1
font = font_named("Century.ttf")

while not quit_requested():
    process_events()
    
    if style_number < 3:
        style_number += 1
    else:
        style_number = 0
        
    if style_number == 0:
        set_font_style(font, FontStyle.normal_font)
    elif style_number == 1:
        set_font_style(font, FontStyle.bold_font)
    elif style_number == 2:
        set_font_style(font, FontStyle.italic_font)
    elif style_number == 3:
        set_font_style(font, FontStyle.underline_font)
        
    clear_screen_to_white()
    # Function is used here ↓
    draw_text_no_font_no_size(f"The assigned font style is currently set to {get_font_style(font)}", color_black(), 40, 60)
    draw_text("The quick brown fox jumps over the lazy dog", color_black(), font, 30, 40, 110)
    refresh_screen()

    delay(2000)

close_all_windows()