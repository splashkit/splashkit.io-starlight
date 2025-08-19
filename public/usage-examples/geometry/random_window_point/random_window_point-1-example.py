from splashkit import *

# Create Window
window = open_window("Portal", 600, 600)

# Load portal sprites
load_bitmap("blue_portal", "bluePortal.png")
load_bitmap("orange_portal", "orangePortal.png")
blue_portal = create_sprite(bitmap_named("blue_portal"))
orange_portal = create_sprite(bitmap_named("orange_portal"))

# Set random portal location
sprite_set_position(blue_portal, random_window_point(window))
sprite_set_position(orange_portal, random_window_point(window))

clear_window(window, color_black())

# Draw the sprite
draw_sprite(blue_portal)
draw_sprite(orange_portal)

refresh_screen()
delay(5000)
close_window(window)