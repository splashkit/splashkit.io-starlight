#define _USE_MATH_DEFINES
#include "splashkit.h"
#include <vector>
#include <cmath>

const int SCREEN_WIDTH = 600;
const int SCREEN_HEIGHT = 600;
const int TILE_SIZE = 60; // Size of each grid tile in the map
const int MAP_SIZE = 10; // Number of tiles in the map grid
const double PLAYER_FOV = 60.0; // Player's field of view in degrees
const int NUM_RAYS = 600; 

// Map grid (1 = wall, 0 = empty space)
const std::vector<std::vector<int>> MAP = {
    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    {1, 0, 0, 1, 1, 0, 1, 0, 0, 1},
    {1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
    {1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
    {1, 0, 0, 1, 0, 1, 1, 0, 0, 1},
    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
};

// Player data
struct Player
{
    point_2d position = point_at(120.0, 120.0); // Player's starting position
    double angle = 90.0; // Player's initial direction in degrees
    double movementSpeed = 2.5; // Speed at which the player moves
    double rotationSpeed = 2.0; // Speed at which the player rotates
};

// Checks if a point is within the map bounds
bool is_within_map(int x, int y)
{
    return x >= 0 && x < MAP_SIZE && y >= 0 && y < MAP_SIZE; // Ensure the ray doesn't go out of bounds
}

// Calculates the maximum ray length to ensure it can reach any point
double calculate_max_ray_length()
{
    return sqrt(SCREEN_WIDTH * SCREEN_WIDTH + SCREEN_HEIGHT * SCREEN_HEIGHT);
}

// Casts a single ray and returns the point of intersection
point_2d cast_single_ray(const Player &player, double ray_angle)
{
    vector_2d ray_dir = vector_from_angle(ray_angle, 1.0); // Determine the ray's direction
    point_2d ray_position = player.position; // Start the ray at the player's position

    while (true)
    {
        ray_position = point_offset_by(ray_position, ray_dir); // Move the ray forward step by step

        int map_x = static_cast<int>(ray_position.x / TILE_SIZE); // Convert ray position to map coordinates
        int map_y = static_cast<int>(ray_position.y / TILE_SIZE);

        if (!is_within_map(map_x, map_y) || MAP[map_y][map_x] == 1)
        {
            return ray_position; // Stop and return intersection point when hitting a wall or boundary
        }

        vector_2d to_ray = vector_point_to_point(player.position, ray_position);
        if (vector_magnitude(to_ray) > calculate_max_ray_length())
        {
            return ray_position; // Cap the ray length to prevent unnecessary calculations
        }
    }
}

// Casts all rays for the player's field of view
std::vector<point_2d> cast_rays(const Player &player)
{
    std::vector<point_2d> hits; // Store the intersection points of all rays
    double ray_angle = player.angle - (PLAYER_FOV / 2.0); // Start at the left edge of the FOV
    double angle_step = PLAYER_FOV / NUM_RAYS; // Angle increment for each ray

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        hits.push_back(cast_single_ray(player, ray_angle)); // Cast each ray and store the intersection point
        ray_angle += angle_step; // Move to the next ray angle
    }

    return hits;
}

// Draws the 2D map, player, and rays
void draw_2D_map_and_fov(const Player &player, const std::vector<point_2d> &hits)
{
    // Draw the map grid
    for (int y = 0; y < MAP_SIZE; ++y)
    {
        for (int x = 0; x < MAP_SIZE; ++x)
        {
            color tile_color = MAP[y][x] == 1 ? COLOR_RED : COLOR_BLACK; // Walls are red, empty spaces are black
            fill_rectangle(tile_color, x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE); // Render each tile
        }
    }

    // Draw the rays extending from the player
    for (const auto &hit : hits)
    {
        draw_line(COLOR_YELLOW, player.position.x, player.position.y, hit.x, hit.y); // Rays are yellow lines
    }

    // Draw the player's position
    fill_circle(COLOR_RED, player.position.x, player.position.y, 5); // Represent the player as a small red circle
}

void handle_input(Player &player)
{
    point_2d new_position = player.position;

    if (key_down(W_KEY))
    {
        vector_2d movement = vector_from_angle(player.angle, player.movementSpeed);
        new_position = point_offset_by(player.position, movement); // Move forward
    }
    if (key_down(S_KEY))
    {
        vector_2d movement = vector_from_angle(player.angle, -player.movementSpeed);
        new_position = point_offset_by(player.position, movement); // Move backward
    }

    // Check collisions and update position if valid
    int map_x = static_cast<int>(new_position.x / TILE_SIZE);
    int map_y = static_cast<int>(new_position.y / TILE_SIZE);
    if (is_within_map(map_x, map_y) && MAP[map_y][map_x] == 0)
    {
        player.position = new_position; // Update position if no collision
    }

    if (key_down(A_KEY))
    {
        player.angle -= player.rotationSpeed; // Rotate left
    }
    if (key_down(D_KEY))
    {
        player.angle += player.rotationSpeed; // Rotate right
    }
}

int main()
{
    open_window("2D Raycasting with SplashKit", SCREEN_WIDTH, SCREEN_HEIGHT);

    Player player;

    while (!window_close_requested("2D Raycasting with SplashKit"))
    {
        process_events();
        clear_screen(COLOR_BLACK); 

        auto hits = cast_rays(player); // Cast rays for the current frame

        draw_2D_map_and_fov(player, hits);
        handle_input(player);

        refresh_screen(60);
    }

    return 0;
}
