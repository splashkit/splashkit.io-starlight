#include "splashkit.h"

int main()
{
    open_window("Camera X/Y Demo", 800, 600);
    
    // Move camera to test position
    move_camera_to(150, 75);
    
    while (!window_close_requested("Camera X/Y Demo"))
    {
        process_events();
        
        // Get individual camera coordinates
        double cam_x = camera_x();
        double cam_y = camera_y();
        
        clear_screen(COLOR_NAVY);
        
        // Show the individual coordinates
        draw_text("Camera X: " + std::to_string((int)cam_x), COLOR_WHITE, 10, 10);
        draw_text("Camera Y: " + std::to_string((int)cam_y), COLOR_WHITE, 10, 35);
        
        // Compare with camera_position()
        point_2d full_pos = camera_position();
        draw_text("Full position X: " + std::to_string((int)full_pos.x), COLOR_YELLOW, 10, 70);
        draw_text("Full position Y: " + std::to_string((int)full_pos.y), COLOR_YELLOW, 10, 95);
        
        // Show that they are the same
        if (cam_x == full_pos.x && cam_y == full_pos.y)
        {
            draw_text("✓ Individual coordinates match full position", COLOR_GREEN, 10, 130);
        }
        
        // Draw grid lines at camera boundaries
        draw_line(COLOR_RED, cam_x, 0, cam_x, 600);  // Left edge
        draw_line(COLOR_RED, cam_x + 800, 0, cam_x + 800, 600);  // Right edge
        draw_line(COLOR_RED, 0, cam_y, 800, cam_y);  // Top edge
        draw_line(COLOR_RED, 0, cam_y + 600, 800, cam_y + 600);  // Bottom edge
        
        // Interactive: click to move camera
        if (mouse_clicked(LEFT_BUTTON))
        {
            point_2d click = mouse_position();
            move_camera_to(click.x + cam_x - 400, click.y + cam_y - 300);
        }
        
        draw_text("Click to move camera", COLOR_WHITE, 10, 550);
        
        refresh_screen(60);
    }
    
    close_window("Camera X/Y Demo");
    return 0;
}
