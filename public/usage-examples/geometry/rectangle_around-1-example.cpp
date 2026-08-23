#include "splashkit.h"

int main()
{
    open_window("Boring Screensaver", 800, 600);

    circle circle;
    int circle_size = 30;
    float rotation_degrees = 0;
    point_2d circle_coordinates;
    bool growing = true;
    timer main_timer = create_timer("main_timer");
    start_timer(main_timer);
    timer reverse_timer = create_timer("reverse_timer");
    start_timer(reverse_timer);

    while (!quit_requested())
    {
        rotation_degrees += 0.005;
        circle_coordinates = point_at((300 + 150 * cosine(rotation_degrees)), (300 + 150 * sine(rotation_degrees)));
        circle = circle_at(circle_coordinates, circle_size);

        if (timer_ticks(main_timer) >= 40 && growing == true)
        {
            circle_size += 1;
            reset_timer(main_timer);
        }
        else if (timer_ticks(reverse_timer) >= 3000)
        {
            growing = false;
        }

        if (timer_ticks(main_timer) >= 40 && growing == false)
        {
            circle_size -= 1;
            reset_timer(main_timer);
        }
        else if (timer_ticks(reverse_timer) >= 6000)
        {
            growing = true;
            reset_timer(reverse_timer);
        }

        process_events();

        clear_screen();
        // A rectangle is drawn which encompasses the circle. It shares the same height, width and position
        draw_rectangle(color_black(), rectangle_around(circle));
        fill_circle(color_red(), circle);
        refresh_screen();
    }
    close_all_windows();
    return 0;
}