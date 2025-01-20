from splashkit import *

# Create a window and bitmap for our caterpillar
window = open_window("Window", 400, 200)
bitmap = create_bitmap("caterpillar", 400, 200)

# Fill background with light color
clear_bitmap(bitmap, color_white())

# Create rainbow colors
colors = [
    color_red(),
    color_orange(),
    color_yellow(),
    color_green(),
    color_blue(),
    color_violet()
]

# Draw circles for caterpillar segments with alternating y positions
x = 50
for i, color in enumerate(colors):
    y = 100 + (20 if i % 2 == 0 else -20)  # Alternate up and down
    fill_circle_on_bitmap(bitmap, color, x, y, 40)
    x += 60

# Draw eyes (adjusted to match first segment position)
fill_circle_on_bitmap(bitmap, color_black(), 60, 100, 8)
fill_circle_on_bitmap(bitmap, color_black(), 60, 130, 8)

while not window_close_requested(window):
    process_events()
    # Draw the bitmap to the window
    draw_bitmap(bitmap, 0, 0)
    # Refresh the window
    refresh_screen()

free_bitmap(bitmap)
close_window(window)