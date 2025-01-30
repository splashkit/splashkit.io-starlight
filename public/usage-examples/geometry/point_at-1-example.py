from splashkit import *

# Draw a flower at specific point
def draw_flower(petal_color, location):
    fill_circle(petal_color, location.x, location.y - 30, 20)
    fill_circle(petal_color, location.x + 28, location.y - 10, 20)
    fill_circle(petal_color, location.x - 28, location.y - 10, 20)
    fill_circle(petal_color, location.x + 18, location.y + 25, 20)
    fill_circle(petal_color, location.x - 18, location.y + 25, 20)
    fill_circle(color_gold(), location.x, location.y, 20)


open_window("Grid of Flowers", 600, 600)

# Declare constants and variables
GRID_SIZE = 5
temp_x = 0
temp_y = 0
points = [[None for x in range(GRID_SIZE)] for y in range(GRID_SIZE)] 
flower_colors = [[None for x in range(GRID_SIZE)] for y in range(GRID_SIZE)] 

# Generate flower points in 5x5 grid pattern
for x in range(GRID_SIZE):
    for y in range(GRID_SIZE):
        # Create a point using temp_x and temp_y
        temp_x = 100 + (x * 100)
        temp_y = 100 + (y * 100)
        temp_point = point_at(temp_x, temp_y)

        # Assign data to 2D arrays
        points[x][y] = temp_point
        flower_colors[x][y] = rgb_color(x * 50, 100, y * 50)

while (not quit_requested()):
    process_events()

    # Draw grid of flowers with random colors
    clear_screen_to_white()
    for x in range(GRID_SIZE):
        for y in range(GRID_SIZE):
            draw_flower(flower_colors[x][y], points[x][y])
    refresh_screen()

close_all_windows()