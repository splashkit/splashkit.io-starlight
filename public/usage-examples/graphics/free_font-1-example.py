from splashkit import *

open_window("Freeing Fonts", 800, 200)
bebas_neue = load_font("BebasNeue", "BebasNeue.ttf")

while (not quit_requested()):
    process_events()

    clear_screen_to_white()
    if (has_font(bebas_neue)):
        draw_text("Using BebasNeue Font: Press Space bar to free font", color_black(), bebas_neue, 30, 20, 50)
    else:
        draw_text("Using System Font: BebasNeue font has been freed", color_black(), get_system_font(), 30, 20, 50)
        draw_text("Press Space bar to load BebasNeue font again", color_black(), get_system_font(), 30, 20, 100)
    refresh_screen()

    if (key_typed(KeyCode.space_key)):
        # If the font is loaded, it is freed
        # If the font has been free, it is loaded again
        if (has_font(bebas_neue)):
            free_font(bebas_neue)
        else:
            bebas_neue = load_font("BebasNeue", "BebasNeue.ttf")

# Clean up
if (has_font(bebas_neue)):
    free_font(bebas_neue)

close_all_windows()