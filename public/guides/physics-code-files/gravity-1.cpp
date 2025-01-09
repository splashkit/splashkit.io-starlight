#include "splashkit.h"
#include <vector>
#include <cmath>

// Structure to represent the ball objects on the screen
struct ball
{
    circle ball_circle;     // Holds the ball position and radius properties
    vector_2d velocity;     // Speed of the ball
    vector_2d acceleration; // Acceleration of the ball

    float mass; // Mass of the ball, determined by the radius. Used in calculation of momentum
    int id;     // Unique ball identifier
};

// Structure to represent the wall objects on the screen
struct wall
{
    circle start_anchor;
    circle end_anchor;
    double radius; // Thickness of the wall (half-width of the capsule)
};

// Global variables to track selections
static wall *selected_wall = nullptr;
static bool start_anchor_selected = false;
static bool end_anchor_selected = false;
static color selected_anchor_color = COLOR_BLACK;

// Inline function to check if two balls overlap.
inline bool balls_overlap(const circle &c1, const circle &c2)
{
    double dx = c1.center.x - c2.center.x;     // Difference in x coordinates
    double dy = c1.center.y - c2.center.y;     // Difference in y coordinates
    double radius_sum = c1.radius + c2.radius; // Sum of both radii

    // Returns true if circles overlap. Uses Pythagorean theorem.
    return (dx * dx + dy * dy) <= (radius_sum * radius_sum);
}

// Function to find the closest point on a wall to a given point
// 'p' is the point we're trying to find the closest point on the line to.
// 'start' and 'end' represent the start and end points of the wall.
point_2d closest_point_on_line(const point_2d &point, const point_2d &start, const point_2d &end)
{
    // Vector from the start of the line to the given point
    vector_2d vector_to_point = vector_point_to_point(start, point);

    // Vector representing the direction and length of the wall
    vector_2d line_vector = vector_point_to_point(start, end);

    // Dot product of the two vectors
    double dot_product_result = dot_product(vector_to_point, line_vector);

    // Square of the length of the wall (for normalisation)
    double line_length_squared = line_vector.x * line_vector.x + line_vector.y * line_vector.y;

    // Calculate the normalised parameter 't', which determines how far along the line the closest point is
    double t = dot_product_result / line_length_squared;

    // Clamp 't' to the [0, 1] range to ensure the closest point lies within the wall
    t = fmax(0, fmin(1, t));

    // Return the coordinates of the closest point on the wall
    return {start.x + line_vector.x * t, start.y + line_vector.y * t};
}

// Function to check if a ball and a wall (capsule) overlap
bool ball_wall_overlap(const ball &b, const wall &w)
{
    // Find the closest point on the wall's wall to the ball's center
    point_2d closest = closest_point_on_line(b.ball_circle.center, w.start_anchor.center, w.end_anchor.center);

    // Calculate the distance between the ball's center and the closest point
    double dx = b.ball_circle.center.x - closest.x;
    double dy = b.ball_circle.center.y - closest.y;
    double distance_squared = dx * dx + dy * dy;

    // The effective radius is the sum of the ball's radius and the wall's radius (thickness)
    double radius_sum = b.ball_circle.radius + w.radius;

    return distance_squared <= radius_sum * radius_sum;
}

// Function to resolve collision between a ball and a wall
void resolve_ball_wall_collision(ball &b, const wall &w)
{
    const double damping_factor = 0.6; // To reduce the bounce energy

    // Find the closest point on the wall to the ball's center
    point_2d closest = closest_point_on_line(b.ball_circle.center, w.start_anchor.center, w.end_anchor.center);

    // Calculate the collision normal vector
    vector_2d collision_normal = vector_point_to_point(closest, b.ball_circle.center);
    collision_normal = unit_vector(collision_normal);

    // Calculate the penetration depth
    double dx = b.ball_circle.center.x - closest.x;
    double dy = b.ball_circle.center.y - closest.y;
    double distance = sqrt(dx * dx + dy * dy);
    double penetration = (b.ball_circle.radius + w.radius) - distance;

    if (penetration > 0)
    {
        // Push the ball out of the wall
        b.ball_circle.center.x += collision_normal.x * penetration;
        b.ball_circle.center.y += collision_normal.y * penetration;

        // Reflect the ball's velocity and apply damping
        double velocity_dot_normal = dot_product(b.velocity, collision_normal);
        vector_2d velocity_normal = vector_multiply(collision_normal, velocity_dot_normal);
        vector_2d velocity_tangent = vector_subtract(b.velocity, velocity_normal);

        // Reverse the normal component of the velocity (elastic collision) with damping
        b.velocity = vector_subtract(velocity_tangent, vector_multiply(velocity_normal, damping_factor));
    }
}

// Function to resolve collision between two balls
void resolve_collision(ball &ball_1, ball &ball_2)
{
    const double damping_factor = 0.95; // Damping to reduce kinetic energy after collision

    // Calculate the difference in positions between the two balls
    float dx = ball_1.ball_circle.center.x - ball_2.ball_circle.center.x;
    float dy = ball_1.ball_circle.center.y - ball_2.ball_circle.center.y;
    float distance_squared = dx * dx + dy * dy; // Square of the distance between the centers
    float distance = sqrt(distance_squared);    // Actual distance between the centers
    float radius_sum = ball_1.ball_circle.radius + ball_2.ball_circle.radius;
    float overlap = (radius_sum - distance); // Amount of overlap between the balls

    if (overlap > 0)
    {
        // Normalise the direction vector (unit vector in the direction of the collision)
        vector_2d normalised_collision = {dx / distance, dy / distance};

        // Displace balls to resolve overlap, ensuring they no longer overlap
        ball_1.ball_circle.center.x += overlap * 0.5 * normalised_collision.x;
        ball_1.ball_circle.center.y += overlap * 0.5 * normalised_collision.y;
        ball_2.ball_circle.center.x -= overlap * 0.5 * normalised_collision.x;
        ball_2.ball_circle.center.y -= overlap * 0.5 * normalised_collision.y;

        // Calculate the normal vector (tangent) using SplashKit's vector_normal function
        vector_2d collision_normal = vector_normal(normalised_collision);

        // Project the velocities onto the collision axes
        double ball_1_normal_dot_product = dot_product(ball_1.velocity, collision_normal);
        double ball_2_normal_dot_product = dot_product(ball_2.velocity, collision_normal);

        double ball_1_collision_dot_product = dot_product(ball_1.velocity, normalised_collision);
        double ball_2_collision_dot_product = dot_product(ball_2.velocity, normalised_collision);

        // Use conservation of momentum to calculate new velocities along the normal direction
        float ball_1_momentum = (ball_1_collision_dot_product * (ball_1.mass - ball_2.mass) + 2.0f * ball_2.mass * ball_2_collision_dot_product) / (ball_1.mass + ball_2.mass);
        float ball_2_momentum = (ball_2_collision_dot_product * (ball_2.mass - ball_1.mass) + 2.0f * ball_1.mass * ball_1_collision_dot_product) / (ball_1.mass + ball_2.mass);

        // Set the new velocities after collision with damping
        ball_1.velocity = vector_add(vector_multiply(collision_normal, ball_1_normal_dot_product), vector_multiply(normalised_collision, ball_1_momentum * damping_factor));
        ball_2.velocity = vector_add(vector_multiply(collision_normal, ball_2_normal_dot_product), vector_multiply(normalised_collision, ball_2_momentum * damping_factor));
    }
}

// Function to create and return a new ball with a unique ID and a position that does not overlap with existing balls and walls.
ball add_ball(int ball_id, const vector<ball> &existing_balls, const vector<wall> &existing_walls)
{
    ball new_ball;
    bool position_found = false;

    // Initialise ball velocity and acceleration to 0
    new_ball.velocity = {0, 0};
    new_ball.acceleration = {0, 0};
    new_ball.id = ball_id;
    new_ball.ball_circle.radius = 15;                    // Set radius to a fixed value
    new_ball.mass = new_ball.ball_circle.radius * 10.0f; // Calculate mass proportional to radius

    // Find a position for the new ball that doesn't overlap with any existing balls or walls
    while (!position_found)
    {
        // Generate a random position within screen bounds, considering the ball's radius
        point_2d random_pos = {
            double(rnd(2 * new_ball.ball_circle.radius, screen_width() - 2 * new_ball.ball_circle.radius)),
            double(rnd(2 * new_ball.ball_circle.radius, screen_height() - 2 * new_ball.ball_circle.radius))};
        new_ball.ball_circle = circle_at(random_pos, new_ball.ball_circle.radius);

        // Check if the new position is valid (i.e., no overlap with other balls)
        position_found = true;
        for (const ball &b : existing_balls)
        {
            if (balls_overlap(new_ball.ball_circle, b.ball_circle))
            {
                position_found = false;
                break;
            }
        }

        // Check if the new position overlaps with any walls
        if (position_found)
        {
            for (const wall &w : existing_walls)
            {
                if (ball_wall_overlap(new_ball, w))
                {
                    position_found = false;
                    break;
                }
            }
        }
    }

    return new_ball;
}

// Function to create and return a new wall with a unique ID and a position that does not overlap with existing balls.
wall add_wall(int wall_id, const vector<wall> &existing_walls, const vector<ball> &existing_balls)
{
    wall new_wall;
    new_wall.radius = 12.5; // Wall thickness (half-width of the capsule) - Reduced by half

    bool position_found = false;

    while (!position_found)
    {
        // Set start and end anchors at random positions
        double x_start = rnd(100, screen_width() - 100);
        double y_start = rnd(100, screen_height() - 100);
        double x_end = rnd(100, screen_width() - 100);
        double y_end = rnd(100, screen_height() - 100);

        new_wall.start_anchor = circle_at({x_start, y_start}, new_wall.radius);
        new_wall.end_anchor = circle_at({x_end, y_end}, new_wall.radius);

        // Check for overlap with existing walls (optional)
        position_found = true;
        for (const wall &w : existing_walls)
        {
            // Check if the walls are too close (this can be adjusted as needed)
            if (balls_overlap(new_wall.start_anchor, w.start_anchor) || balls_overlap(new_wall.end_anchor, w.end_anchor))
            {
                position_found = false;
                break;
            }
        }

        // Check for overlap with existing balls
        if (position_found)
        {
            for (const ball &b : existing_balls)
            {
                if (ball_wall_overlap(b, new_wall))
                {
                    position_found = false;
                    break;
                }
            }
        }
    }

    return new_wall;
}

// Function to resolve and draw collisions between all balls and walls
void resolve_and_draw_collisions(vector<ball> &balls, const vector<wall> &walls)
{
    // Loop through each pair of balls to check for collisions
    for (size_t i = 0; i < balls.size(); ++i)
    {
        for (size_t j = i + 1; j < balls.size(); ++j)
        {
            if (balls_overlap(balls[i].ball_circle, balls[j].ball_circle))
            {
                resolve_collision(balls[i], balls[j]);
            }
        }

        // Check collision with walls
        for (const wall &w : walls)
        {
            if (ball_wall_overlap(balls[i], w))
            {
                resolve_ball_wall_collision(balls[i], w);
            }
        }
    }
}

// Function to draw a wall
void draw_wall(const wall &w)
{
    // Determine the colors for the anchors
    color start_anchor_color = COLOR_BLACK;
    color end_anchor_color = COLOR_BLACK;

    if (&w == selected_wall)
    {
        if (start_anchor_selected)
        {
            start_anchor_color = COLOR_BLUE; // Selected anchor turns blue
        }
        if (end_anchor_selected)
        {
            end_anchor_color = COLOR_BLUE; // Selected anchor turns blue
        }
    }

    // Draw the start and end circles for the capsule
    fill_circle(start_anchor_color, w.start_anchor);
    fill_circle(end_anchor_color, w.end_anchor);

    // Calculate the vector from start to end anchor
    vector_2d wall_vector = vector_point_to_point(w.start_anchor.center, w.end_anchor.center);

    // Get the normal vector for the wall vector, which will be used to offset the lines for the capsule's thickness
    vector_2d wall_normal = unit_vector(vector_normal(wall_vector));

    // Calculate the wall's half thickness using the radius (capsule's half-width)
    double half_thickness = w.radius;

    // Offset points for the upper and lower lines of the capsule's body
    point_2d upper_start = point_offset_by(w.start_anchor.center, vector_multiply(wall_normal, half_thickness));
    point_2d upper_end = point_offset_by(w.end_anchor.center, vector_multiply(wall_normal, half_thickness));

    point_2d lower_start = point_offset_by(w.start_anchor.center, vector_multiply(wall_normal, -half_thickness));
    point_2d lower_end = point_offset_by(w.end_anchor.center, vector_multiply(wall_normal, -half_thickness));

    // Draw the lines that form the capsule's body
    draw_line(COLOR_BLACK, upper_start, upper_end);
    draw_line(COLOR_BLACK, lower_start, lower_end);
}

// Function to draw all balls and walls on the screen.
void draw_objects(const vector<ball> &balls, const vector<wall> &walls)
{
    for (const ball &b : balls)
    {
        fill_circle(COLOR_RED, b.ball_circle);
        draw_circle(COLOR_BLACK, b.ball_circle);
    }

    for (const wall &w : walls)
    {
        draw_wall(w);
    }
}

// Function to handle user input, specifically selecting and applying forces to balls and walls.
void handle_inputs(vector<ball> &balls, vector<wall> &walls)
{
    // If left mouse button clicked
    if (mouse_clicked(LEFT_BUTTON))
    {
        // If nothing is selected, try to select an anchor
        if (!start_anchor_selected && !end_anchor_selected)
        {
            // Try to select an anchor
            for (wall &w : walls)
            {
                // Check if the click is on the start anchor
                if (point_in_circle(mouse_position(), w.start_anchor))
                {
                    selected_wall = &w;
                    start_anchor_selected = true;
                    end_anchor_selected = false;
                    selected_anchor_color = COLOR_BLUE; // Selected anchor turns blue
                    return;
                }
                // Check if the click is on the end anchor
                else if (point_in_circle(mouse_position(), w.end_anchor))
                {
                    selected_wall = &w;
                    end_anchor_selected = true;
                    start_anchor_selected = false;
                    selected_anchor_color = COLOR_BLUE; // Selected anchor turns blue
                    return;
                }
            }
        }

        // If an anchor is selected, deselect it
        else if (start_anchor_selected || end_anchor_selected)
        {
            start_anchor_selected = false;
            end_anchor_selected = false;
            selected_wall = nullptr;
            selected_anchor_color = COLOR_BLACK;
        }
    }

    // If an anchor is selected, move it with the mouse
    if (start_anchor_selected && selected_wall)
    {
        selected_wall->start_anchor.center = mouse_position();
    }
    else if (end_anchor_selected && selected_wall)
    {
        selected_wall->end_anchor.center = mouse_position();
    }

    // Handle static collision: push balls away if they overlap with moved walls
    if ((start_anchor_selected || end_anchor_selected) && selected_wall)
    {
        for (ball &b : balls)
        {
            if (ball_wall_overlap(b, *selected_wall))
            {
                resolve_ball_wall_collision(b, *selected_wall);
            }
        }
    }
}

// Function to update ball positions and velocities
void update_balls(vector<ball> &balls)
{
    const double gravity = 0.3;                  // Constant downward acceleration due to gravity
    const double terminal_velocity_factor = 0.8; // Adjust this factor to tune the terminal velocity
    const double min_velocity = 0.01;            // Minimum velocity threshold to limit jittering

    for (ball &b : balls)
    {
        // Apply gravity to the acceleration (downward)
        b.acceleration.y = gravity;

        // Update velocity based on acceleration
        b.velocity = vector_add(b.velocity, b.acceleration);

        // Calculate terminal velocity based on the radius of the ball
        double terminal_velocity = terminal_velocity_factor * b.ball_circle.radius;

        // Cap velocity to simulate terminal velocity
        if (vector_magnitude(b.velocity) > terminal_velocity)
        {
            b.velocity = vector_multiply(unit_vector(b.velocity), terminal_velocity);
        }

        // Set velocity to 0 if it is below the minimum threshold
        if (vector_magnitude(b.velocity) < min_velocity)
        {
            b.velocity = {0, 0}; // Stop the ball from jittering when the velocity is too small
        }

        // Update ball position based on velocity
        b.ball_circle.center.x += b.velocity.x;
        b.ball_circle.center.y += b.velocity.y;

        // Handle screen wrapping
        if (b.ball_circle.center.y - b.ball_circle.radius > screen_height())
        {
            // Ball falls off the bottom of the screen, wrap it to the top
            b.ball_circle.center.y = -5 * b.ball_circle.radius;
        }

        // Check the left boundary
        if (b.ball_circle.center.x - b.ball_circle.radius < 0)
        {
            b.ball_circle.center.x = b.ball_circle.radius; // Reposition ball inside the left boundary
            b.velocity.x *= -1;                            // Reverse the x-velocity (bounce off the wall)
        }

        // Check the right boundary
        if (b.ball_circle.center.x + b.ball_circle.radius > screen_width())
        {
            b.ball_circle.center.x = screen_width() - b.ball_circle.radius; // Reposition ball inside the right boundary
            b.velocity.x *= -1;                                             // Reverse the x-velocity (bounce off the wall)
        }
    }
}

int main()
{
    open_window("Ball Vectors", 1400, 800);

    int num_balls = 40;
    int num_walls = 4;

    // Vectors to store all balls and walls
    vector<ball> balls;
    vector<wall> walls;

    for (int i = 1; i <= num_walls; ++i)
    {
        walls.push_back(add_wall(i, walls, balls));
    }

    for (int i = 1; i <= num_balls; ++i)
    {
        balls.push_back(add_ball(i, balls, walls));
    }

    while (!window_close_requested("Ball Vectors"))
    {
        process_events();

        clear_screen(COLOR_WHITE);

        resolve_and_draw_collisions(balls, walls);

        handle_inputs(balls, walls);

        update_balls(balls);

        draw_objects(balls, walls);

        refresh_screen(60);
    }

    return 0;
}