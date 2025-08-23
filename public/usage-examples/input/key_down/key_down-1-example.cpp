#include "splashkit.h"

int main()
{
    open_window("Key Down Demo", 800, 600);
    
    double x = 400, y = 300;
    double speed = 5.0;
    
    while (!window_close_requested("Key Down Demo"))
    {
        process_events();
        
        // Move the circle based on arrow keys being held down
        if (key_down(UP_KEY))
            y -= speed;
        if (key_down(DOWN_KEY))
            y += speed;
        if (key_down(LEFT_KEY))
            x -= speed;
        if (key_down(RIGHT_KEY))
            x += speed;
        
        // Keep the circle within window bounds
        if (x < 25) x = 25;
        if (x > 775) x = 775;
        if (y < 25) y = 25;
        if (y > 575) y = 575;
        
        clear_screen(COLOR_BLACK);
        
        // Draw the controllable circle
        fill_circle(COLOR_BLUE, x, y, 25);
        
        // Show instructions and key states
        draw_text("Use arrow keys to move the circle", COLOR_WHITE, 10, 10);
        draw_text("Hold keys for continuous movement", COLOR_WHITE, 10, 30);
        
        // Show which keys are currently pressed
        string status = "Keys pressed: ";
        if (key_down(UP_KEY)) status += "UP ";
        if (key_down(DOWN_KEY)) status += "DOWN ";
        if (key_down(LEFT_KEY)) status += "LEFT ";
        if (key_down(RIGHT_KEY)) status += "RIGHT ";
        if (!key_down(UP_KEY) && !key_down(DOWN_KEY) && 
            !key_down(LEFT_KEY) && !key_down(RIGHT_KEY))
            status += "None";
            
        draw_text(status, COLOR_YELLOW, 10, 50);
        
        // Show position
        draw_text("Position: (" + std::to_string((int)x) + ", " + std::to_string((int)y) + ")", 
                  COLOR_GREEN, 10, 70);
        
        refresh_screen(60);
    }
    
    close_window("Key Down Demo");
    return 0;
}
