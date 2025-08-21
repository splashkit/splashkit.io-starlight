#include "splashkit.h"

int main()
{
    open_window("Move Camera Demo", 800, 600);
    
    double target_x = 0, target_y = 0;
    
    while (!window_close_requested("Move Camera Demo"))
    {
        process_events();
        
        // Use arrow keys to move the camera
        if (key_down(RIGHT_KEY))
            target_x += 5;
        if (key_down(LEFT_KEY))
            target_x -= 5;
        if (key_down(DOWN_KEY))
            target_y += 5;
        if (key_down(UP_KEY))
            target_y -= 5;
        
        // Move camera to the new position
        move_camera_to(target_x, target_y);
        
        clear_screen(COLOR_DARK_GREEN);
        
        // Draw a large world with objects
        for (int x = -500; x < 1500; x += 100)
        {
            for (int y = -500; y < 1200; y += 100)
            {
                fill_circle(COLOR_RED, x, y, 20);
                draw_text(std::to_string(x) + "," + std::to_string(y), 
                         COLOR_WHITE, x - 15, y + 25);
            }
        }
        
        // Draw camera boundaries
        point_2d cam_pos = camera_position();
        draw_rectangle(COLOR_YELLOW, cam_pos.x, cam_pos.y, 800, 600);
        
        // Show instructions
        draw_text("Use arrow keys to move camera", COLOR_WHITE, 10, 10);
        draw_text("Camera at: (" + std::to_string((int)cam_pos.x) + ", " + 
                 std::to_string((int)cam_pos.y) + ")", COLOR_WHITE, 10, 30);
        
        refresh_screen(60);
    }
    
    close_window("Move Camera Demo");
    return 0;
}
