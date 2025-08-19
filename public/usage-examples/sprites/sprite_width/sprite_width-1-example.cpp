#include "splashkit.h"

int main()
{
    // Open a window for the sprite demo
    open_window("Sprite Width Demo", 800, 600);
    
    // Load a bitmap for the sprite
    bitmap player_bitmap = load_bitmap("player", "player.png");
    
    // Create a sprite using the bitmap
    sprite player = create_sprite(player_bitmap);
    
    // Position the sprite in the center
    sprite_set_x(player, 300);
    sprite_set_y(player, 200);
    
    // Get the width of the sprite
    int width = sprite_width(player);
    
    // Display the sprite and its width information
    while (!quit_requested())
    {
        process_events();
        
        // Clear screen
        clear_screen(COLOR_WHITE);
        
        // Draw the sprite
        draw_sprite(player);
        
        // Display sprite width information
        draw_text("Sprite width: " + std::to_string(width) + " pixels", COLOR_BLACK, 50, 50);
        draw_text("Sprite is positioned at x: " + std::to_string((int)sprite_x(player)), COLOR_BLACK, 50, 80);
        draw_text("Right edge is at x: " + std::to_string((int)sprite_x(player) + width), COLOR_BLACK, 50, 110);
        
        // Update display
        refresh_screen(60);
    }
    
    // Clean up
    free_sprite(player);
    close_all_windows();
    
    return 0;
}
