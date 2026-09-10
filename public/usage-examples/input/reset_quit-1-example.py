from splashkit import *

open_window("Quit Confirmation", 600, 300)

running = True     # controls the main loop
confirming = False # True while the "Really quit?" prompt is showing
cancelled = 0      # how many times the quit request was cancelled

while running:
    process_events()

    # quit_requested becomes True when the window's close button is clicked,
    # and stays True until the program exits or reset_quit is called
    if quit_requested():
        confirming = True

    if confirming:
        # Y confirms the quit and ends the loop
        if key_typed(KeyCode.y_key):
            running = False

        # N cancels it - reset_quit makes quit_requested return False again
        if key_typed(KeyCode.n_key):
            reset_quit()
            confirming = False
            cancelled += 1

    clear_screen(color_white())

    if confirming:
        draw_text_font_as_string("Really quit?", color_red(), "Arial", 28, 220, 90)
        draw_text_font_as_string("[Y] Yes    [N] No", color_black(), "Arial", 20, 215, 150)
    else:
        draw_text_font_as_string("Running - click the X to quit", color_green(), "Arial", 24, 150, 90)
        draw_text_font_as_string("Quit requests cancelled: " + str(cancelled),
                                 color_black(), "Arial", 20, 175, 150)

    draw_text_font_as_string("reset_quit cancels a pending quit request",
                             color_gray(), "Arial", 16, 145, 230)

    refresh_screen_with_target_fps(60)

close_all_windows()
