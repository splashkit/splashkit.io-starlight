from splashkit import *

# Create a window and bitmap to draw on
window = open_window("Cube", 800, 600)
bitmap = create_bitmap("cube", 800, 600)

# Fill background with light color
clear_bitmap(bitmap, color_white())

# Define the color for the cube
cube_color = color_blue()

# Define the coordinates of the front and back faces of the cube
front_face = quad_from(
    300, 200,    # Top-left
    500, 200,    # Top-right
    300, 400,    # Bottom-left
    500, 400     # Bottom-right
)

back_face = quad_from(
    350, 150,    # Top-left
    550, 150,    # Top-right
    350, 350,    # Bottom-left
    550, 350     # Bottom-right
)

# Draw the faces of the cube
draw_quad_on_bitmap(bitmap, cube_color, front_face)
draw_quad_on_bitmap(bitmap, cube_color, back_face)

# Connect the front and back faces for the 3D effect
draw_line_on_bitmap(bitmap, cube_color, 300, 200, 350, 150)
draw_line_on_bitmap(bitmap, cube_color, 500, 200, 550, 150)
draw_line_on_bitmap(bitmap, cube_color, 300, 400, 350, 350)
draw_line_on_bitmap(bitmap, cube_color, 500, 400, 550, 350)

while not window_close_requested(window):
    process_events()
    # Draw the bitmap to the window
    draw_bitmap(bitmap, 0, 0)
    # Refresh the window
    refresh_screen()

free_bitmap(bitmap)
close_window(window)