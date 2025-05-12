#include "splashkit.h"

// Draw a flower at specific point
void draw_flower(color petal_color, point_2d location)
{
    fill_circle(petal_color, location.x, location.y - 30, 20);
    fill_circle(petal_color, location.x + 28, location.y - 10, 20);
    fill_circle(petal_color, location.x - 28, location.y - 10, 20);
    fill_circle(petal_color, location.x + 18, location.y + 25, 20);
    fill_circle(petal_color, location.x - 18, location.y + 25, 20);
    fill_circle(COLOR_GOLD, location.x, location.y, 20);
}

int main()
{
    open_window("Grid of Flowers", 600, 600);

    // Declare constants and variables
    const int GRID_SIZE = 5;
    int temp_x = 0;
    int temp_y = 0;
    point_2d points[GRID_SIZE][GRID_SIZE];
    color flower_colors[GRID_SIZE][GRID_SIZE];

    // Generate flower points in 5x5 grid pattern
    for (int x = 0; x < GRID_SIZE; x++)
    {
        for (int y = 0; y < GRID_SIZE; y++)
        {
            // Create a point using temp_x and temp_y
            temp_x = 100 + (x * 100);
            temp_y = 100 + (y * 100);
            point_2d temp_point = point_at(temp_x, temp_y);

            // Assign data to 2D arrays
            points[x][y] = temp_point;
            flower_colors[x][y] = rgb_color(x * 50, 100, y * 50);
        }
    }

    while (!quit_requested())
    {
        process_events();

        // Draw grid of flowers with random colors
        clear_screen();
        for (int x = 0; x < GRID_SIZE; x++)
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                draw_flower(flower_colors[x][y], points[x][y]);
            }
        }
        refresh_screen();
    }

    close_all_windows();

    return 0;
}