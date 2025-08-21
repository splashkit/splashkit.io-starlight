#include "splashkit.h"

int main()
{
    open_window("Camera Position Demo", 800, 600);
    
    // Get the initial camera position
    point_2d current_pos = camera_position();
    write_line("Initial camera position: (" + std::to_string(current_pos.x) + ", " + std::to_string(current_pos.y) + ")");
    
    // Move camera to a new position
    move_camera_to(100, 50);
    
    // Check the new position
    current_pos = camera_position();
    write_line("New camera position: (" + std::to_string(current_pos.x) + ", " + std::to_string(current_pos.y) + ")");
    
    // Draw something to visualize the camera position
    while (!window_close_requested("Camera Position Demo"))
    {
        process_events();
        clear_screen(COLOR_BLACK);
        
        // Draw a reference grid to show camera movement
        for (int x = 0; x < 1000; x += 100)
        {
            draw_line(COLOR_GRAY, x, 0, x, 800);
        }
        for (int y = 0; y < 800; y += 100)
        {
            draw_line(COLOR_GRAY, 0, y, 1000, y);
        }
        
        // Show current camera position on screen
        current_pos = camera_position();
        draw_text("Camera: (" + std::to_string((int)current_pos.x) + ", " + std::to_string((int)current_pos.y) + ")", 
                  COLOR_WHITE, 10, 10);
        
        refresh_screen(60);
    }
    
    close_window("Camera Position Demo");
    return 0;
}
