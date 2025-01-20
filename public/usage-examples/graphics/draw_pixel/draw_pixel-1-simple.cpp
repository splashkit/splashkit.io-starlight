#include "splashkit.h"

int main()
{
    // declare variables
    const int TRAIL_LENGTH = 50;
    point_2d mouse_point;
    point_2d mouse_history[TRAIL_LENGTH] = {};
    color color_list[5] = { color_blue(), color_red(), color_green(), color_yellow(), color_pink() };

    open_window("Cursor Trail", 600, 600);

    while (!quit_requested())
    {
        mouse_point = mouse_position();
        clear_screen(color_black());

        // set mouse position history 
        for (int i = 0; i < TRAIL_LENGTH - 1; i++)
        {
            // shuffle forward
            mouse_history[i] = mouse_history[i + 1];
        }

        mouse_history[TRAIL_LENGTH - 1] = mouse_point;

        // draw mouse trail
        for (int i = 0; i < TRAIL_LENGTH; i++)
        {
            draw_pixel(color_list[i % 5], mouse_history[i]);
        }

        process_events();
        refresh_screen(60);
    }

    close_all_windows();
    return 0;
}
