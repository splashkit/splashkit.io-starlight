from splashkit import *

open_window("sprite-set-velocity", 600, 600)

load_bitmap("player", "player-run.png")
player_sprite = create_sprite(bitmap_named("player"))
sprite_set_x(player_sprite, 300)
sprite_set_y(player_sprite, 300)

# Create vector for sprite's velocity
vel = vector_to(0.01,0)

while(not quit_requested()):
    process_events()
    
    # Set sprite velocity and update sprite
    sprite_set_velocity(player_sprite, vel)
    update_sprite(player_sprite)

    clear_screen(color_black())
    draw_sprite(player_sprite)
    refresh_screen()

close_all_windows()