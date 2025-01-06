#define _USE_MATH_DEFINES
#include "splashkit.h"
#include <vector>
#include <cmath>

// Constants and settings
const int SCREEN_WIDTH = 1200; // Total width of the window (3D + 2D)
const int SCREEN_HEIGHT = 600; // Height of the window
const int TILE_SIZE = 60; // Size of each grid tile in the map
const int MAP_SIZE = 10; // Number of tiles in the map grid
const double PLAYER_FOV = 60.0; // Player's field of view in degrees
const int NUM_RAYS = 600; // Number of rays cast for 3D projection

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
    return x >= 0 && x < MAP_SIZE && y >= 0 && y < MAP_SIZE;
}

// Casts a single ray and returns the point of intersection and distance
double cast_single_ray_3D(const Player &player, double ray_angle)
{
    vector_2d ray_dir = vector_from_angle(ray_angle, 1.0);
    point_2d ray_position = player.position;

    while (true)
    {
        ray_position = point_offset_by(ray_position, ray_dir);

        int map_x = static_cast<int>(ray_position.x / TILE_SIZE);
        int map_y = static_cast<int>(ray_position.y / TILE_SIZE);

        vector_2d to_ray = vector_point_to_point(player.position, ray_position);
        double distance = vector_magnitude(to_ray);

        if (!is_within_map(map_x, map_y) || MAP[map_y][map_x] == 1)
        {
            return distance; // Return distance when a wall is hit or ray exits bounds
        }

        if (distance > calculate_max_ray_length())
        {
            return calculate_max_ray_length(); // Cap the distance for long rays
        }
    }
}

// Casts all rays for the 3D view and returns distances
std::vector<double> cast_rays_3D(const Player &player)
{
    std::vector<double> distances;
    double ray_angle = player.angle - (PLAYER_FOV / 2.0);
    double angle_step = PLAYER_FOV / NUM_RAYS;

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        distances.push_back(cast_single_ray_3D(player, ray_angle));
        ray_angle += angle_step;
    }

    return distances;
}

// Draws the 3D view on the left half of the screen
void draw_3D_view(const Player &player, const std::vector<double> &distances)
{
    int ray_width = (SCREEN_WIDTH / 2) / NUM_RAYS; // Adjust width for the left half of the screen
    double max_distance = std::min(SCREEN_WIDTH / 2, SCREEN_HEIGHT); // Adjust max distance scaling

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        double corrected_distance = distances[i] * cos(degree_to_radians(i * (PLAYER_FOV / NUM_RAYS) - (PLAYER_FOV / 2.0)));
        int wall_height = static_cast<int>((TILE_SIZE / corrected_distance) * SCREEN_HEIGHT);
        int wall_top = (SCREEN_HEIGHT / 2) - (wall_height / 2);
        int wall_bottom = (SCREEN_HEIGHT / 2) + (wall_height / 2);

        double brightness = 1.0 - (corrected_distance / max_distance);
        brightness = brightness > 1.0 ? 1.0 : (brightness < 0.0 ? 0.0 : brightness);

        color wall_color = hsb_color(hue_of(COLOR_RED), saturation_of(COLOR_RED), brightness);

        for (int j = 0; j < ray_width; ++j)
        {
            int screen_x = i * ray_width + j;
            if (screen_x < SCREEN_WIDTH / 2) // Render only in the left half
            {
                draw_line(wall_color, screen_x, wall_top, screen_x, wall_bottom);
            }
        }
    }
}

// Casts all rays for the 2D view
std::vector<point_2d> cast_rays_2D(const Player &player)
{
    std::vector<point_2d> hits;
    double ray_angle = player.angle - (PLAYER_FOV / 2.0);
    double angle_step = PLAYER_FOV / NUM_RAYS;

    for (int i = 0; i < NUM_RAYS; ++i)
    {
        vector_2d ray_dir = vector_from_angle(ray_angle, 1.0);
        point_2d ray_position = player.position;

        while (true)
        {
            ray_position = point_offset_by(ray_position, ray_dir);

            int map_x = static_cast<int>(ray_position.x / TILE_SIZE);
            int map_y = static_cast<int>(ray_position.y / TILE_SIZE);

            if (!is_within_map(map_x, map_y) || MAP[map_y][map_x] == 1)
            {
                hits.push_back(ray_position);
                break;
            }
        }
        ray_angle += angle_step;
    }
    return hits;
}

// Draws the 2D map and rays on the right half of the screen
void draw_2D_map_and_fov(const Player &player, const std::vector<point_2d> &hits)
{
    for (int y = 0; y < MAP_SIZE; ++y)
    {
        for (int x = 0; x < MAP_SIZE; ++x)
        {
            color tile_color = MAP[y][x] == 1 ? COLOR_RED : COLOR_BLACK;
            fill_rectangle(tile_color, SCREEN_WIDTH / 2 + x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
        }
    }

    for (const auto &hit : hits)
    {
        draw_line(COLOR_YELLOW, SCREEN_WIDTH / 2 + player.position.x, player.position.y, SCREEN_WIDTH / 2 + hit.x, hit.y);
    }

    fill_circle(COLOR_RED, SCREEN_WIDTH / 2 + player.position.x, player.position.y, 5);
}

// Handles player movement and rotation
void handle_input(Player &player)
{
    point_2d new_position = player.position;
    if (key_down(W_KEY))
    {
        vector_2d movement = vector_from_angle(player.angle, player.movementSpeed);
        new_position = point_offset_by(player.position, movement);
    }
    if (key_down(S_KEY))
    {
        vector_2d movement = vector_from_angle(player.angle, -player.movementSpeed);
        new_position = point_offset_by(player.position, movement);
    }

    int map_x = static_cast<int>(new_position.x / TILE_SIZE);
    int map_y = static_cast<int>(new_position.y / TILE_SIZE);
    if (is_within_map(map_x, map_y) && MAP[map_y][map_x] == 0)
    {
        player.position = new_position;
    }

    if (key_down(A_KEY))
    {
        player.angle -= player.rotationSpeed;
    }
    if (key_down(D_KEY))
    {
        player.angle += player.rotationSpeed;
    }
}

// Main function
int main()
{
    open_window("2D and 3D Raycasting with SplashKit", SCREEN_WIDTH, SCREEN_HEIGHT);

    Player player;

    while (!window_close_requested("2D and 3D Raycasting with SplashKit"))
    {
        process_events();
        clear_screen(COLOR_BLACK);

        auto distances = cast_rays_3D(player); // Cast rays for 3D view
        auto hits = cast_rays_2D(player); // Cast rays for 2D view

        draw_3D_view(player, distances); // Render 3D view
        draw_2D_map_and_fov(player, hits); // Render 2D view
        draw_line(COLOR_BLACK, SCREEN_WIDTH / 2, 0, SCREEN_WIDTH / 2, SCREEN_HEIGHT); // Separate views
        handle_input(player); // Handle player input

        refresh_screen(60);
    }

    return 0;
}
