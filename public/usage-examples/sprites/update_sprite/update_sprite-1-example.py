from splashkit import *

open_window("Update Sprite Example", 800, 600)

# Load bitmap and animation script
player_bitmap = load_bitmap("player", "player.png")
load_animation_script("player_anim", "player.txt")

# Create sprite with animation
player_sprite = create_sprite(player_bitmap)
sprite_start_animation(player_sprite, "WalkRight")
sprite_set_velocity(player_sprite, vector_to(2, 0))

# Main game loop
while not quit_requested():
    process_events()
    clear_screen(color_white())
    
    # Update sprite (animation and position)
    update_sprite(player_sprite)
    
    # Wrap sprite around screen
    if sprite_x(player_sprite) > screen_width():
        sprite_set_x(player_sprite, 0 - sprite_width(player_sprite))
    
    draw_sprite(player_sprite, sprite_x(player_sprite), sprite_y(player_sprite))
    
    refresh_screen(60)

close_all_windows()
