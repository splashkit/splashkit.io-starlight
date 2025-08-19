from splashkit import *

# Declare variables
TRAIL_LENGTH = 50
pixel_point = point_at(-10, -10)
mouse_history = [pixel_point for _ in range(TRAIL_LENGTH)]
color_list = [color_blue(), color_red(), color_green(), color_yellow(), color_pink()]

open_window("Cursor Trail", 600, 600)

while not quit_requested():
    mouse_point = mouse_position()
    clear_screen(color_black())

    # Set mouse position history
    for i in range(TRAIL_LENGTH - 1):
        # Shuffle forward
        mouse_history[i] = mouse_history[i + 1]

    mouse_history[TRAIL_LENGTH - 1] = mouse_point

    # Draw mouse trail
    for i in range(TRAIL_LENGTH):
        draw_pixel_at_point(color_list[i % 5], mouse_history[i])

    process_events()
    refresh_screen_with_target_fps(60)

close_all_windows()
