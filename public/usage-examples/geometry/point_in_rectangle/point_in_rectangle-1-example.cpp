#include "splashkit.h"

int main()
{
    // Variable Declarations
    point_2d mouse_pt;
    rectangle boundary = rectangle_from(150, 150, 300, 100);
    string text;
    color color1;
    color color2;
    timer flashing_timer = create_timer("flash time");

    open_window("Cursor Jail", 600, 600);
    start_timer(flashing_timer);

    while (!quit_requested())
    {
        process_events();

        // Get mouse position
        mouse_pt = mouse_position();

        // Check if mouse is in the boundary
        if (point_in_rectangle(mouse_pt, boundary))
        {
            text = "";
            color1 = color_green();
            color2 = color_green();
            reset_timer(flashing_timer);
        }
        else
        {
            // Flash screen red and blue if mouse has escaped boundary
            text = "JAILBREAK";
            color1 = color_royal_blue();
            color2 = color_dark_red();
        }

        // Draw UI using timer ticks
        if (timer_ticks(flashing_timer) < 500)
        {
            clear_screen(color1);
            fill_rectangle(color_white(), boundary);
            refresh_screen();
        }
        if (timer_ticks(flashing_timer) >= 500 && timer_ticks(flashing_timer) < 1000)
        {
            clear_screen(color2);
            fill_rectangle(color_white(), boundary);
            draw_text(text, color_black(), 250, 400);
            refresh_screen();
        }
        if (timer_ticks(flashing_timer) >= 1000)
        {
            reset_timer(flashing_timer);
        }
    }
    close_all_windows();

    return 0;
}