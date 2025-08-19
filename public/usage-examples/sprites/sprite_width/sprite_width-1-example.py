from splashkit import *

open_window("Sprite Width Example", 800, 600)

# Load bitmap and create sprite
player_bitmap = load_bitmap("player", "player.png")
player_sprite = create_sprite(player_bitmap)

# Get sprite width
width = sprite_width(player_sprite)

# Main game loop
while not quit_requested():
    process_events()
    clear_screen(color_white())
    
    # Draw sprite and display width
    draw_sprite(player_sprite, 100, 100)
    draw_text(f"Sprite Width: {width}", color_black(), 50, 50)
    
    refresh_screen(60)

close_all_windows()
