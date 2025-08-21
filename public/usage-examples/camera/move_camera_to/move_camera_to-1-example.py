from splashkit import *

def main():
    open_window("Move Camera Demo", 800, 600)
    
    target_x, target_y = 0, 0
    
    while not window_close_requested("Move Camera Demo"):
        process_events()
        
        # Use arrow keys to move the camera
        if key_down(key_code.right_key):
            target_x += 5
        if key_down(key_code.left_key):
            target_x -= 5
        if key_down(key_code.down_key):
            target_y += 5
        if key_down(key_code.up_key):
            target_y -= 5
        
        # Move camera to the new position
        move_camera_to(target_x, target_y)
        
        clear_screen(color_dark_green())
        
        # Draw a large world with objects
        for x in range(-500, 1500, 100):
            for y in range(-500, 1200, 100):
                fill_circle(color_red(), x, y, 20)
                draw_text(f"{x},{y}", color_white(), x - 15, y + 25)
        
        # Draw camera boundaries
        cam_pos = camera_position()
        draw_rectangle(color_yellow(), cam_pos.x, cam_pos.y, 800, 600)
        
        # Show instructions
        draw_text("Use arrow keys to move camera", color_white(), 10, 10)
        draw_text(f"Camera at: ({int(cam_pos.x)}, {int(cam_pos.y)})", 
                  color_white(), 10, 30)
        
        refresh_screen(60)
    
    close_window("Move Camera Demo")

if __name__ == "__main__":
    main()
