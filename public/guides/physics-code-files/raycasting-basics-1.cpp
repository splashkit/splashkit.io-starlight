#include "splashkit.h"
#include <cmath>
#include <vector>

// Constants for screen dimensions
const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;

// Player structure
struct Player
{
    point_2d position = point_at(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2); // Player starts at screen center
    double angle = 270.0;  // Viewing direction (in degrees)
    const double radius = 10.0; // Radius for rendering the player
};

// Calculate the maximum ray length (screen diagonal)
double calculate_max_ray_length()
{
    return sqrt(SCREEN_WIDTH * SCREEN_WIDTH + SCREEN_HEIGHT * SCREEN_HEIGHT);
}

// Function to detect if a ray intersects a rectangle
bool ray_rectangle_intersection(const point_2d &origin, const vector_2d &direction, const rectangle &rect, point_2d &hit_point, double &hit_distance)
{
    double min_intersection_distance = -calculate_max_ray_length();
    double max_intersection_distance = calculate_max_ray_length();

    // Compute the inverse of the ray direction (for faster calculations)
    vector_2d inv_dir = vector_to(1.0 / direction.x, 1.0 / direction.y);

    // Calculate entry and exit distances for the rectangle's x and y boundaries
    double entry_distance_x = (rect.x - origin.x) * inv_dir.x;
    double exit_distance_x = (rect.x + rect.width - origin.x) * inv_dir.x;

    double entry_distance_y = (rect.y - origin.y) * inv_dir.y;
    double exit_distance_y = (rect.y + rect.height - origin.y) * inv_dir.y;

    // Determine the nearest entry point and the farthest exit point
    min_intersection_distance = std::max(std::min(entry_distance_x, exit_distance_x), std::min(entry_distance_y, exit_distance_y));
    max_intersection_distance = std::min(std::max(entry_distance_x, exit_distance_x), std::max(entry_distance_y, exit_distance_y));

    // If the ray misses the rectangle or the intersection is behind the ray's origin
    if (min_intersection_distance > max_intersection_distance || max_intersection_distance < 0)
    {
        return false;
    }

    // Compute the point of intersection
    hit_distance = min_intersection_distance;
    vector_2d hit_vector = vector_multiply(direction, min_intersection_distance);
    hit_point = point_at(origin.x + hit_vector.x, origin.y + hit_vector.y);

    return true;
}

// Draw the player (origin)
void draw_player(const Player &player)
{
    fill_circle(COLOR_BLUE, player.position.x, player.position.y, player.radius); // Origin as a blue circle
    draw_text("Player", COLOR_WHITE, "arial", 14, player.position.x + 10, player.position.y - 10);
}

// Draw the ray and handle labels for direction, ray, and intersection
void draw_ray_and_check_collisions(const Player &player, const std::vector<rectangle> &rectangles, std::vector<int> &numbers, std::vector<bool> &collision_flags)
{
    vector_2d ray_direction = vector_from_angle(player.angle, 1.0);
    point_2d ray_end = point_offset_by(player.position, vector_multiply(ray_direction, calculate_max_ray_length()));
    point_2d intersection;
    double distance;

    bool any_collision = false;

    for (size_t i = 0; i < rectangles.size(); ++i)
    {
        if (ray_rectangle_intersection(player.position, ray_direction, rectangles[i], intersection, distance))
        {
            any_collision = true;

            if (!collision_flags[i])
            {
                collision_flags[i] = true;
                write_line("Ray is colliding with Square " + std::to_string(numbers[i]));
            }

            // Draw ray up to the intersection
            draw_line(COLOR_YELLOW, player.position.x, player.position.y, intersection.x, intersection.y);

            // Highlight intersection point
            fill_circle(COLOR_GREEN, intersection.x, intersection.y, 5);
            draw_text("Intersection", COLOR_GREEN, "arial", 14, intersection.x + 10, intersection.y - 10);
            break;
        }
        else
        {
            if (collision_flags[i])
            {
                collision_flags[i] = false;
                write_line("Ray is no longer colliding with Square " + std::to_string(numbers[i]));
            }
        }
    }

    // If no collisions, draw full ray
    if (!any_collision)
    {
        draw_line(COLOR_YELLOW, player.position.x, player.position.y, ray_end.x, ray_end.y);
    }

    // Draw direction vector
    draw_line(COLOR_CYAN, player.position.x, player.position.y, player.position.x + ray_direction.x * 50, player.position.y + ray_direction.y * 50);
    draw_text("Direction", COLOR_CYAN, "arial", 14, player.position.x + ray_direction.x * 60, player.position.y + ray_direction.y * 60);

    // Always draw "Ray" label at twice the distance of "Direction"
    point_2d ray_label_position = point_at(player.position.x + ray_direction.x * 120, player.position.y + ray_direction.y * 120);
    draw_text("Ray", COLOR_YELLOW, "arial", 14, ray_label_position.x, ray_label_position.y - 10);
}

// Draw rectangles with labels
void draw_rectangle_with_number(const rectangle &rect, int number, bool is_colliding)
{
    color rect_color = is_colliding ? COLOR_RED : COLOR_PURPLE;
    fill_rectangle(rect_color, rect);

    point_2d center = point_at(rect.x + rect.width / 2, rect.y + rect.height / 2);
    draw_text(std::to_string(number), COLOR_WHITE, "arial", 30, center.x - 10, center.y - 15);
}

// Handle player input
void handle_input(Player &player)
{
    if (key_down(A_KEY))
    {
        player.angle -= 0.5; // Rotate left
    }
    if (key_down(D_KEY))
    {
        player.angle += 0.5; // Rotate right
    }
}

// Main function
int main()
{
    open_window("Raycasting Basics", SCREEN_WIDTH, SCREEN_HEIGHT);

    Player player;

    std::vector<rectangle> rectangles = {
        rectangle_from(SCREEN_WIDTH - 150, 50, 100, 100),
        rectangle_from(SCREEN_WIDTH - 150, SCREEN_HEIGHT - 150, 100, 100),
        rectangle_from(50, SCREEN_HEIGHT - 150, 100, 100),
        rectangle_from(50, 50, 100, 100)
    };

    std::vector<int> numbers = {0, 1, 2, 3};
    std::vector<bool> collision_flags(rectangles.size(), false);

    while (!window_close_requested("Raycasting Basics"))
    {
        process_events();
        clear_screen(COLOR_BLACK);

        for (size_t i = 0; i < rectangles.size(); ++i)
        {
            draw_rectangle_with_number(rectangles[i], numbers[i], collision_flags[i]);
        }

        draw_player(player);
        draw_ray_and_check_collisions(player, rectangles, numbers, collision_flags);
        handle_input(player);

        refresh_screen(60);
    }

    return 0;
}
