#include "splashkit.h"

int main()
{
    open_window("Distance From Center", 600, 600);
    
    // Define the variables
    point_2d center_pt = screen_center();
    point_2d mouse_pt;
    float pt_pt_distance;

    while (!quit_requested())
    {
        process_events();

        // Get "current" Mouse Position
        mouse_pt = mouse_position();

        // Calculate the distance between the center point and the current mouse position
        pt_pt_distance = point_point_distance(center_pt, mouse_pt);

        // Draw line and distance between center of window (filled circle) and mouse point
        clear_screen();
        fill_circle(COLOR_RED, center_pt.y, center_pt.y, 5);
        draw_line(COLOR_BLUE, center_pt, mouse_pt);
        draw_text(std::to_string(pt_pt_distance), COLOR_BLACK, mouse_pt.x + 10, mouse_pt.y - 10);
        refresh_screen();
    }

    // Close all opened windows
    close_all_windows();

    return 0;
}