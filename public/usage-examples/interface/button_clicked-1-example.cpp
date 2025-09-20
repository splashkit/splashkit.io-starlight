#include "splashkit.h"

int main()
{
    // Open a window
    open_window("Button Clicked Example", 800, 600);
    
    // Create buttons
    button red_button = button("Red Button");
    button blue_button = button("Blue Button");
    button green_button = button("Green Button");
    
    // Position buttons
    button_set_position(red_button, 100, 200);
    button_set_position(blue_button, 300, 200);
    button_set_position(green_button, 500, 200);
    
    // Variables to track button states
    int red_clicks = 0;
    int blue_clicks = 0;
    int green_clicks = 0;
    
    write_line("Button Clicked Example");
    write_line("Click buttons to see click counts");
    write_line("Press ESC to exit");
    
    while (!window_close_requested("Button Clicked Example"))
    {
        // Clear the screen
        clear_screen(COLOR_WHITE);
        
        // Check if buttons were clicked
        if (button_clicked(red_button))
        {
            red_clicks++;
            write_line("Red button clicked! Total: " + to_string(red_clicks));
        }
        
        if (button_clicked(blue_button))
        {
            blue_clicks++;
            write_line("Blue button clicked! Total: " + to_string(blue_clicks));
        }
        
        if (button_clicked(green_button))
        {
            green_clicks++;
            write_line("Green button clicked! Total: " + to_string(green_clicks));
        }
        
        // Draw buttons
        draw_button(red_button);
        draw_button(blue_button);
        draw_button(green_button);
        
        // Display click counts
        draw_text("Red Button Clicks: " + to_string(red_clicks), COLOR_RED, 100, 300);
        draw_text("Blue Button Clicks: " + to_string(blue_clicks), COLOR_BLUE, 300, 300);
        draw_text("Green Button Clicks: " + to_string(green_clicks), COLOR_GREEN, 500, 300);
        
        // Instructions
        draw_text("Click the buttons above to see the click counts increase", COLOR_BLACK, 100, 400);
        
        // Refresh the screen
        refresh_screen();
        
        // Process events
        process_events();
        
        // Small delay
        delay(16);
    }
    
    // Clean up
    free_button(red_button);
    free_button(blue_button);
    free_button(green_button);
    
    return 0;
} 