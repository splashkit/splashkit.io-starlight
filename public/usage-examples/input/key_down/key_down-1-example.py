from splashkit import *

def main():
    open_window("Key Down Demo", 800, 600)
    
    x, y = 400, 300
    speed = 5.0
    
    while not window_close_requested("Key Down Demo"):
        process_events()
        
        # Move the circle based on arrow keys being held down
        if key_down(key_code.up_key):
            y -= speed
        if key_down(key_code.down_key):
            y += speed
        if key_down(key_code.left_key):
            x -= speed
        if key_down(key_code.right_key):
            x += speed
        
        # Keep the circle within window bounds
        if x < 25: x = 25
        if x > 775: x = 775
        if y < 25: y = 25
        if y > 575: y = 575
        
        clear_screen(color_black())
        
        # Draw the controllable circle
        fill_circle(color_blue(), x, y, 25)
        
        # Show instructions and key states
        draw_text("Use arrow keys to move the circle", color_white(), 10, 10)
        draw_text("Hold keys for continuous movement", color_white(), 10, 30)
        
        # Show which keys are currently pressed
        status = "Keys pressed: "
        if key_down(key_code.up_key): status += "UP "
        if key_down(key_code.down_key): status += "DOWN "
        if key_down(key_code.left_key): status += "LEFT "
        if key_down(key_code.right_key): status += "RIGHT "
        if (not key_down(key_code.up_key) and not key_down(key_code.down_key) and 
            not key_down(key_code.left_key) and not key_down(key_code.right_key)):
            status += "None"
            
        draw_text(status, color_yellow(), 10, 50)
        
        # Show position
        draw_text(f"Position: ({int(x)}, {int(y)})", color_green(), 10, 70)
        
        refresh_screen(60)
    
    close_window("Key Down Demo")

if __name__ == "__main__":
    main()
