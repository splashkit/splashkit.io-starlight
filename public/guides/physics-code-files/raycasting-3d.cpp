#define _USE_MATH_DEFINES
#include "splashkit.h"
#include <vector>
#include <cmath>

// Constants and settings
const int SCREEN_WIDTH = 600;
const int SCREEN_HEIGHT = 600;
const int MAP_SIZE = 10; // Number of tiles in the map grid
const int TILE_SIZE = 60; // Size of each grid tile in the map
const double PLAYER_FOV = 60.0; // Player's field of view in degrees
const int NUM_RAYS = 600; // Number of rays cast, corresponds to screen columns

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
    point_2d position = point_at(120.0, 120.0); // Starting position of the player
    double angle = 90.0; // Player's initial facing direction in degrees
    double movementSpeed = 2.5; // Speed of player movement
    double rotationSpeed = 2.0; // Speed of player rotation
};

// Calculates the maximum ray length
// The diagonal of the screen ensures the ray can reach any point
double calculate_max_ray_length()
{
    return sqrt(SCREEN_WIDTH * SCREEN_WIDTH + SCREEN_HEIGHT * SCREEN_HEIGHT);
}

double degree_to_radians(double degrees)
{
    return degrees * (M_PI / 180.0);
}

// Checks if a point is within the map bounds
bool is_within_map(int x, int y)
{
    return x >= 0 && x < MAP_SIZE && y >= 0 && y < MAP_SIZE; // Ensures the ray doesn't go out of bounds
}

// Casts a single ray and returns the point of intersection and distance
double cast_single_ray(const Player &player, double ray_angle)
{
    vector_2d ray_dir = vector_from_angle(ray_angle, 1.0); // Calculate the ray's direction
    point_2d ray_position = player.position; // Start the ray at the player's position

    while (true)
    {
        // Move the ray forward step by step
        ray_position = point_offset_by(ray_position, ray_dir); 

        // Convert ray position to map grid coordinates
        int map_x = static_cast<int>(ray_position.x / TILE_SIZE); 
        int map_y = static_cast<int>(ray_position.y / TILE_SIZE);

        vector_2d to_ray = vector_point_to_point(player.position, ray_position);
        double distance = vector_magnitude(to_ray); // Calculate distance from player to current ray position

        if (!is_within_map(map_x, map_y) || MAP[map_y][map_x] == 1)
        {
            return distance; // Stop and return distance when a wall is hit or ray goes out of bounds
        }

        if (distance > calculate_max_ray_length())
        {
            return calculate_max_ray_length(); // Cap the distance to prevent unnecessarily long rays
        }
    }
}

// Casts all rays for the player's field of view and returns distances
std::vector<double> cast_rays(const Player &player)
{
    std::vector<double> distances;
    double ray_angle = player.angle - (PLAYER_FOV / 2.0); // Start at the left edge of the FOV
    double angle_step = PLAYER_FOV / NUM_RAYS; // Increment angle for each ray

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        distances.push_back(cast_single_ray(player, ray_angle)); // Cast each ray and store its distance
        ray_angle += angle_step; // Move to the next ray angle
    }

    return distances;
}

void draw_3D_view(const Player &player, const std::vector<double> &distances)
{
    int ray_width = SCREEN_WIDTH / NUM_RAYS; // Width of each vertical slice (1 ray per slice)
    double max_distance = std::min(SCREEN_WIDTH, SCREEN_HEIGHT); // Max distance for brightness scaling

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        // Fix fish-eye effect
        double corrected_distance = distances[i] * cos(degree_to_radians(i * (PLAYER_FOV / NUM_RAYS) - (PLAYER_FOV / 2.0)));

        int wall_height = static_cast<int>((TILE_SIZE / corrected_distance) * SCREEN_HEIGHT); // Inverse distance for height
        int wall_top = (SCREEN_HEIGHT / 2) - (wall_height / 2);
        int wall_bottom = (SCREEN_HEIGHT / 2) + (wall_height / 2);

        double brightness = 1.0 - (corrected_distance / max_distance); // Adjust brightness based on distance
        brightness = brightness > 1.0 ? 1.0 : (brightness < 0.0 ? 0.0 : brightness); // Clamp brightness

        color wall_color = hsb_color(hue_of(COLOR_RED), saturation_of(COLOR_RED), brightness); // Dynamic wall brightness

        for (int j = 0; j < ray_width; ++j)
        {
            int screen_x = i * ray_width + j;
            if (screen_x < SCREEN_WIDTH) // Avoid out-of-bounds drawing
            {
                draw_line(wall_color, screen_x, wall_top, screen_x, wall_bottom); // Render the wall slice
            }
        }
    }
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
    open_window("3D Raycasting with SplashKit", SCREEN_WIDTH, SCREEN_HEIGHT);

    Player player;

    while (!window_close_requested("3D Raycasting with SplashKit"))
    {
        process_events();
        clear_screen(COLOR_BLACK);

        auto distances = cast_rays(player);

        draw_3D_view(player, distances);
        handle_input(player);

        refresh_screen(60);
    }

    return 0;
}
