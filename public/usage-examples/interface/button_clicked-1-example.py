import splashkit


def main():
    # Open a window
    splashkit.open_window("Button Clicked Example", 800, 600)
    
    # Create buttons
    red_button = splashkit.button("Red Button")
    blue_button = splashkit.button("Blue Button")
    green_button = splashkit.button("Green Button")
    
    # Position buttons
    splashkit.button_set_position(red_button, 100, 200)
    splashkit.button_set_position(blue_button, 300, 200)
    splashkit.button_set_position(green_button, 500, 200)
    
    # Variables to track button states
    red_clicks = 0
    blue_clicks = 0
    green_clicks = 0
    
    splashkit.write_line("Button Clicked Example")
    splashkit.write_line("Click buttons to see click counts")
    splashkit.write_line("Press ESC to exit")
    
    while not splashkit.window_close_requested("Button Clicked Example"):
        # Clear the screen
        splashkit.clear_screen(splashkit.COLOR_WHITE)
        
        # Check if buttons were clicked
        if splashkit.button_clicked(red_button):
            red_clicks += 1
            splashkit.write_line("Red button clicked! Total: " + str(red_clicks))
        
        if splashkit.button_clicked(blue_button):
            blue_clicks += 1
            splashkit.write_line("Blue button clicked! Total: " + str(blue_clicks))
        
        if splashkit.button_clicked(green_button):
            green_clicks += 1
            splashkit.write_line("Green button clicked! Total: " + str(green_clicks))
        
        # Draw buttons
        splashkit.draw_button(red_button)
        splashkit.draw_button(blue_button)
        splashkit.draw_button(green_button)
        
        # Display click counts
        splashkit.draw_text("Red Button Clicks: " + str(red_clicks), splashkit.COLOR_RED, 100, 300)
        splashkit.draw_text("Blue Button Clicks: " + str(blue_clicks), splashkit.COLOR_BLUE, 300, 300)
        splashkit.draw_text("Green Button Clicks: " + str(green_clicks), splashkit.COLOR_GREEN, 500, 300)
        
        # Instructions
        splashkit.draw_text("Click the buttons above to see the click counts increase", splashkit.COLOR_BLACK, 100, 400)
        
        # Refresh the screen
        splashkit.refresh_screen()
        
        # Process events
        splashkit.process_events()
        
        # Small delay
        splashkit.delay(16)
    
    # Clean up
    splashkit.free_button(red_button)
    splashkit.free_button(blue_button)
    splashkit.free_button(green_button)
    
    return 0

if __name__ == "__main__":
    main() 