#include "splashkit.h"
#include <vector>
#include <cmath>
#include <utility>
#include <algorithm>

const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;
const int NUM_RAYS = 360; // Total number of rays for a full circle
const int RAY_LIMIT = 300;
int MAX_RAY_DISTANCE = 200; // Maximum distance a ray can travel

double calculate_brightness(double distance)
{
    // Brightness decreases linearly with distance; 1.0 at origin, 0.0 at max distance
    return 1.0 - (distance / RAY_LIMIT);
}

// Checks if the cursor collides with any rectangle
bool cursor_collides_with_rectangle(const point_2d &cursor_position, const std::vector<rectangle> &rectangles)
{
    // Returns true if the cursor is inside any rectangle
    return std::any_of(rectangles.begin(), rectangles.end(), [&](const rectangle &rect)
                       { return point_in_rectangle(cursor_position, rect); });
}

// Checks if the cursor collides with any circle
bool cursor_collides_with_circle(const point_2d &cursor_position, const std::vector<circle> &circles)
{
    // Returns true if the cursor is inside any circle
    return std::any_of(circles.begin(), circles.end(), [&](const circle &circ)
                       { return point_in_circle(cursor_position, circ); });
}

// Determines if a ray intersects with a circle within the allowed range
bool circle_ray_intersection(const point_2d &origin, const vector_2d &heading, const circle &circ, point_2d &hit_point, double &hit_distance)
{
    // Calculate the distance from the ray's origin to the circle's intersection point
    float distance = ray_circle_intersect_distance(origin, heading, circ);

    // If the intersection is behind the ray's origin or beyond the max distance, return false
    if (distance < 0.0f || distance > MAX_RAY_DISTANCE)
        return false;

    // Store the intersection distance and calculate the exact hit point on the circle
    hit_distance = static_cast<double>(distance);
    hit_point = point_offset_by(origin, vector_multiply(heading, hit_distance));
    return true;
}

// Determines if a ray intersects with a rectangle within the allowed range
bool ray_rectangle_intersection(const point_2d &origin, const vector_2d &direction, const rectangle &rect, point_2d &hit_point, double &hit_distance)
{
    // Calculate the inverse direction for efficient boundary checks
    vector_2d inv_dir = vector_to(1.0 / direction.x, 1.0 / direction.y);

    // Compute entry and exit distances for the rectangle's horizontal and vertical boundaries
    double entry_distance_x = (rect.x - origin.x) * inv_dir.x;
    double exit_distance_x = (rect.x + rect.width - origin.x) * inv_dir.x;
    double entry_distance_y = (rect.y - origin.y) * inv_dir.y;
    double exit_distance_y = (rect.y + rect.height - origin.y) * inv_dir.y;

    // Find the nearest entry point and farthest exit point
    double min_entry = std::max(std::min(entry_distance_x, exit_distance_x), std::min(entry_distance_y, exit_distance_y));
    double max_exit = std::min(std::max(entry_distance_x, exit_distance_x), std::max(entry_distance_y, exit_distance_y));

    // Check if the ray misses the rectangle or if the intersection is out of bounds
    if (min_entry > max_exit || max_exit < 0.0 || min_entry > MAX_RAY_DISTANCE)
        return false;

    // Store the intersection distance and calculate the exact hit point
    hit_distance = min_entry;
    hit_point = point_offset_by(origin, vector_multiply(direction, min_entry));
    return true;
}

// Cast rays from the cursor position to detect intersections and illuminated shapes
void cast_rays(
    const point_2d &cursor_position,                                   // The origin of the rays (mouse cursor position)
    const std::vector<rectangle> &rectangles,                          // List of rectangles to check for intersections
    const std::vector<circle> &circles,                                // List of circles to check for intersections
    std::vector<point_2d> &ray_intersections,                          // Output: closest intersection points for each ray
    std::vector<std::pair<rectangle, double>> &illuminated_rectangles, // Output: rectangles hit by rays and their distances
    std::vector<std::pair<circle, double>> &illuminated_circles        // Output: circles hit by rays and their distances
)
{
    // Angle increment per ray for uniform casting in a full circle
    double angle_increment = 360.0 / NUM_RAYS;

    // Clear previous intersection results and illuminated shapes
    ray_intersections.clear();
    illuminated_rectangles.clear();
    illuminated_circles.clear();

    // Iterate through all rays
    for (int i = 0; i < NUM_RAYS; ++i)
    {
        // Determine the ray's angle and direction vector
        double ray_angle = i * angle_increment;
        vector_2d ray_direction = vector_from_angle(ray_angle, 1.0);

        // Initialise the closest intersection as the maximum ray distance
        point_2d closest_intersection = point_offset_by(cursor_position, vector_multiply(ray_direction, MAX_RAY_DISTANCE));
        double closest_distance = MAX_RAY_DISTANCE;

        // Check intersections with rectangles
        for (const auto &rect : rectangles)
        {
            point_2d intersection_point;
            double intersection_distance;

            // If ray intersects with the rectangle and is the closest so far, update results
            if (ray_rectangle_intersection(cursor_position, ray_direction, rect, intersection_point, intersection_distance) &&
                intersection_distance < closest_distance)
            {
                closest_distance = intersection_distance;
                closest_intersection = intersection_point;
                illuminated_rectangles.emplace_back(rect, intersection_distance);
            }
        }

        // Check intersections with circles
        for (const auto &circ : circles)
        {
            point_2d intersection_point;
            double intersection_distance;

            // If ray intersects with the circle and is the closest so far, update results
            if (circle_ray_intersection(cursor_position, ray_direction, circ, intersection_point, intersection_distance) &&
                intersection_distance < closest_distance)
            {
                closest_distance = intersection_distance;
                closest_intersection = intersection_point;
                illuminated_circles.emplace_back(circ, intersection_distance);
            }
        }

        // Store the closest intersection point for the current ray
        ray_intersections.push_back(closest_intersection);
    }
}

// Draw rectangles with brightness based on ray intersection
void draw_rectangles(const std::vector<rectangle> &rectangles, const std::vector<std::pair<rectangle, double>> &illuminated_rectangles)
{
    for (const auto &rect : rectangles)
    {
        // Set default rectangle color to black (not illuminated)
        color rect_color = COLOR_BLACK;

        // Check if the rectangle is illuminated
        for (const auto &illuminated_pair : illuminated_rectangles)
        {
            const auto &illuminated_rect = illuminated_pair.first; // Illuminated rectangle
            const auto &distance = illuminated_pair.second;        // Distance of the ray intersection

            // Match the current rectangle with an illuminated rectangle
            if (illuminated_rect.x == rect.x && illuminated_rect.y == rect.y &&
                illuminated_rect.width == rect.width && illuminated_rect.height == rect.height)
            {
                // Calculate brightness based on the intersection distance
                double brightness = calculate_brightness(distance);
                // Adjust rectangle color based on calculated brightness
                rect_color = hsb_color(hue_of(COLOR_PURPLE), saturation_of(COLOR_PURPLE), brightness);
                break; // Stop checking once the rectangle is matched
            }
        }

        // Render the rectangle with the appropriate color
        fill_rectangle(rect_color, rect);
    }
}

// Draw circles with brightness based on ray intersection
void draw_circles(const std::vector<circle> &circles, const std::vector<std::pair<circle, double>> &illuminated_circles)
{
    for (const auto &circ : circles)
    {
        // Set default circle color to black (not illuminated)
        color circle_color = COLOR_BLACK;

        // Check if the circle is illuminated
        for (const auto &illuminated_pair : illuminated_circles)
        {
            const auto &illuminated_circ = illuminated_pair.first; // Illuminated circle
            const auto &distance = illuminated_pair.second;        // Distance of the ray intersection

            // Match the current circle with an illuminated circle
            if (same_point(illuminated_circ.center, circ.center) && illuminated_circ.radius == circ.radius)
            {
                // Calculate brightness based on the intersection distance
                double brightness = calculate_brightness(distance);
                // Adjust circle color based on calculated brightness
                circle_color = hsb_color(hue_of(COLOR_GREEN), saturation_of(COLOR_GREEN), brightness);
                break; // Stop checking once the circle is matched
            }
        }

        // Render the circle with the appropriate color
        fill_circle(circle_color, circ.center.x, circ.center.y, circ.radius);
    }
}

// Draw rays from the cursor position
void draw_rays(const std::vector<point_2d> &ray_intersections, const point_2d &origin)
{
    for (const auto &intersection : ray_intersections)
    {
        // Draw a straight line from the origin to the intersection point
        draw_line(COLOR_YELLOW, origin.x, origin.y, intersection.x, intersection.y);
    }
}

// Main function
int main()
{
    open_window("Raycasting and Illumination", SCREEN_WIDTH, SCREEN_HEIGHT);

    // Define scene objects
    std::vector<rectangle> rectangles = {
        rectangle_from(150, 100, 50, 150),
        rectangle_from(500, 50, 150, 75),
        rectangle_from(170, 400, 100, 100),
        rectangle_from(600, 300, 200, 50),
        rectangle_from(350, 200, 75, 75),
        rectangle_from(700, 450, 50, 100)};

    std::vector<circle> circles = {
        circle_at({100, 150}, 30),
        circle_at({400, 300}, 20),
        circle_at({700, 100}, 40),
        circle_at({300, 500}, 25),
        circle_at({600, 450}, 15)};

    std::vector<point_2d> ray_intersections;
    std::vector<std::pair<rectangle, double>> illuminated_rectangles;
    std::vector<std::pair<circle, double>> illuminated_circles;

    while (!window_close_requested("Raycasting and Illumination"))
    {
        process_events();
        clear_screen(COLOR_BLACK);

        point_2d cursor_position;
        point_2d new_cursor_position = mouse_position();

        // Prevent cursor from entering shapes
        if (!cursor_collides_with_rectangle(new_cursor_position, rectangles) && !cursor_collides_with_circle(new_cursor_position, circles))
        {
            cursor_position = new_cursor_position;
        }

        // Check if the left mouse button is clicked
        if (mouse_clicked(LEFT_BUTTON))
        {
            // Increment the maximum ray distance by 100
            MAX_RAY_DISTANCE += 100;

            // If the maximum ray distance exceeds the predefined limit, reset it to 100
            if (MAX_RAY_DISTANCE > RAY_LIMIT)
            {
                MAX_RAY_DISTANCE = 100;
            }
        }

        cast_rays(cursor_position, rectangles, circles, ray_intersections, illuminated_rectangles, illuminated_circles);

        // Draw objects and rays
        draw_rectangles(rectangles, illuminated_rectangles);
        draw_circles(circles, illuminated_circles);
        draw_rays(ray_intersections, cursor_position);

        refresh_screen(60);
    }

    return 0;
}
