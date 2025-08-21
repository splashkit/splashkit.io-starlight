from splashkit import *

def main():
    open_window("Camera Position Demo", 800, 600)
    
    # Get the initial camera position
    current_pos = camera_position()
    write_line(f"Initial camera position: ({current_pos.x}, {current_pos.y})")
    
    # Move camera to a new position
    move_camera_to(100, 50)
    
    # Check the new position
    current_pos = camera_position()
    write_line(f"New camera position: ({current_pos.x}, {current_pos.y})")
    
    # Draw something to visualize the camera position
    while not window_close_requested("Camera Position Demo"):
        process_events()
        clear_screen(color_black())
        
        # Draw a reference grid to show camera movement
        for x in range(0, 1000, 100):
            draw_line(color_gray(), x, 0, x, 800)
        for y in range(0, 800, 100):
            draw_line(color_gray(), 0, y, 1000, y)
        
        # Show current camera position on screen
        current_pos = camera_position()
        draw_text(f"Camera: ({int(current_pos.x)}, {int(current_pos.y)})", 
                  color_white(), 10, 10)
        
        refresh_screen(60)
    
    close_window("Camera Position Demo")

if __name__ == "__main__":
    main()
