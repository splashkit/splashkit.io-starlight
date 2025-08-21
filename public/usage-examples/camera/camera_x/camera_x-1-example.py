from splashkit import *

def main():
    open_window("Camera X/Y Demo", 800, 600)
    
    # Move camera to test position
    move_camera_to(150, 75)
    
    while not window_close_requested("Camera X/Y Demo"):
        process_events()
        
        # Get individual camera coordinates
        cam_x = camera_x()
        cam_y = camera_y()
        
        clear_screen(color_navy())
        
        # Show the individual coordinates
        draw_text(f"Camera X: {int(cam_x)}", color_white(), 10, 10)
        draw_text(f"Camera Y: {int(cam_y)}", color_white(), 10, 35)
        
        # Compare with camera_position()
        full_pos = camera_position()
        draw_text(f"Full position X: {int(full_pos.x)}", color_yellow(), 10, 70)
        draw_text(f"Full position Y: {int(full_pos.y)}", color_yellow(), 10, 95)
        
        # Show that they are the same
        if cam_x == full_pos.x and cam_y == full_pos.y:
            draw_text("✓ Individual coordinates match full position", color_green(), 10, 130)
        
        # Draw grid lines at camera boundaries
        draw_line(color_red(), cam_x, 0, cam_x, 600)  # Left edge
        draw_line(color_red(), cam_x + 800, 0, cam_x + 800, 600)  # Right edge
        draw_line(color_red(), 0, cam_y, 800, cam_y)  # Top edge
        draw_line(color_red(), 0, cam_y + 600, 800, cam_y + 600)  # Bottom edge
        
        # Interactive: click to move camera
        if mouse_clicked(mouse_button.left_button):
            click = mouse_position()
            move_camera_to(click.x + cam_x - 400, click.y + cam_y - 300)
        
        draw_text("Click to move camera", color_white(), 10, 550)
        
        refresh_screen(60)
    
    close_window("Camera X/Y Demo")

if __name__ == "__main__":
    main()
