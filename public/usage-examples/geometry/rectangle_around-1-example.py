from splashkit import *

open_window("Boring Screensaver", 800, 600)

circle = Circle
circle_size = 30
rotation_degrees = 0
circle_coordinates = 0
growing = True
main_timer = create_timer("main_timer")
start_timer(main_timer)
reverse_timer = create_timer("reverse_timer")
start_timer(reverse_timer)

while (not quit_requested()):
    rotation_degrees = rotation_degrees + 0.005
    circle_coordinates = point_at((300 + 150 * cosine(rotation_degrees)), (300 + 150 * sine(rotation_degrees)))
    circle = circle_at(circle_coordinates, circle_size)

    if timer_ticks(main_timer) >= 40 and growing == True:
        circle_size += 1
        reset_timer(main_timer)
    elif timer_ticks(reverse_timer) >= 3000:
        growing = False

    if timer_ticks(main_timer) >= 40 and growing == False:
        circle_size -= 1
        reset_timer(main_timer)
    elif timer_ticks(reverse_timer) >= 6000:
        growing = True
        reset_timer(reverse_timer)
        
    process_events()

    clear_screen_to_white()
    # A rectangle is drawn which encompasses the circle. It shares the same height, width and position
    draw_rectangle_record(color_black(), rectangle_around_circle(circle))
    fill_circle_record(color_red(), circle)
    refresh_screen()

close_all_windows()