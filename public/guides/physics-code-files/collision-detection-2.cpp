#include "splashkit.h"
#include <vector>
#include <cmath>

using std::to_string;

// Structure to represent the ball objects on the screen
struct ball
{
    circle ball_circle;     // Holds the ball position and radius properties
    vector_2d velocity;     // Speed of the ball
    vector_2d acceleration; // Acceleration of the ball

    float mass; // Mass of the ball, determined by the radius. Used in calculation of momentum
    int id;     // Unique ball identifier
};

// Inline function to check if two balls overlap.
inline bool balls_overlap(const circle &c1, const circle &c2)
{
    double dx = c1.center.x - c2.center.x;     // Difference in x coordinates
    double dy = c1.center.y - c2.center.y;     // Difference in y coordinates
    double radius_sum = c1.radius + c2.radius; // Sum of both radii

    // Returns true if circles overlap. Uses pythagorean theorum.
    return (dx * dx + dy * dy) <= (radius_sum * radius_sum);
}

// Function to create and return a new ball with a unique ID and a position that does not overlap with existing balls.
ball add_ball(int ball_id, const vector<ball> &existing_balls)
{
    ball new_ball;
    bool position_found = false;

    // Initialise ball velocity and acceleration to 0
    new_ball.velocity = {0, 0};
    new_ball.acceleration = {0, 0};
    new_ball.id = ball_id;
    new_ball.ball_circle.radius = rnd(10, 50);           // Radius of the ball
    new_ball.mass = new_ball.ball_circle.radius * 10.0f; // Calculate mass proportional to radius

    // Find a position for the new ball that doesn't overlap with any existing balls
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
    }

    return new_ball;
}

// Function to resolve collisions between two balls
void resolve_collision(ball &ball_1, ball &ball_2)
{
    // Calculate the difference in positions between the two balls
    float dx = ball_1.ball_circle.center.x - ball_2.ball_circle.center.x;
    float dy = ball_1.ball_circle.center.y - ball_2.ball_circle.center.y;
    float distance_squared = dx * dx + dy * dy; // Square of the distance between the centers
    float distance = sqrt(distance_squared);    // Actual distance between the centers
    float radius_sum = ball_1.ball_circle.radius + ball_2.ball_circle.radius;
    float overlap = 0.5f * (radius_sum - distance); // Amount of overlap between the balls

    // Normalise the direction vector (unit vector in the direction of the collision)
    vector_2d normalised_collision = {dx / distance, dy / distance};

    // Displace balls to resolve overlap, ensuring they no longer overlap
    ball_1.ball_circle.center.x += overlap * normalised_collision.x;
    ball_1.ball_circle.center.y += overlap * normalised_collision.y;
    ball_2.ball_circle.center.x -= overlap * normalised_collision.x;
    ball_2.ball_circle.center.y -= overlap * normalised_collision.y;

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

    // Set the new velocities after collision
    ball_1.velocity = vector_add(vector_multiply(collision_normal, ball_1_normal_dot_product), vector_multiply(normalised_collision, ball_1_momentum));
    ball_2.velocity = vector_add(vector_multiply(collision_normal, ball_2_normal_dot_product), vector_multiply(normalised_collision, ball_2_momentum));
}

// Function to resolve and draw collisions between all balls
void resolve_and_draw_collisions(vector<ball> &balls)
{
    // Loop through each pair of balls to check for collisions
    for (size_t i = 0; i < balls.size(); ++i)
    {
        for (size_t j = i + 1; j < balls.size(); ++j)
        {
            if (balls_overlap(balls[i].ball_circle, balls[j].ball_circle))
            {
                resolve_collision(balls[i], balls[j]);
                // Draw a red line between the centers of the colliding balls
                draw_line(COLOR_RED, balls[i].ball_circle.center, balls[j].ball_circle.center);
            }
        }
    }
}

// Function to draw all balls on the screen.
void draw_balls(const vector<ball> &balls)
{
    for (const ball &b : balls)
    {
        draw_circle(COLOR_BLACK, b.ball_circle);
    }
}

// Function to handle user input, specifically selecting and applying forces to balls.
void handle_inputs(vector<ball> &balls)
{
    static ball *selected_ball = nullptr;

    const double SCALING_FACTOR = 0.05; // Factor to scale the applied force

    // If left mouse button clicked and no ball selected, loop through all balls to check if the mouse has clicked a valid ball, then select that ball
    if (mouse_clicked(LEFT_BUTTON))
    {
        if (!selected_ball)
        {
            for (ball &b : balls)
            {
                if (point_in_circle(mouse_position(), b.ball_circle))
                {
                    selected_ball = &b;
                    return;
                }
            }
        }

        // If ball is already selected, apply force to the ball proportional to the magnitude of the vector drawn by the mouse
        else
        {
            vector_2d force = vector_point_to_point(mouse_position(), selected_ball->ball_circle.center);
            selected_ball->velocity = vector_multiply(vector_add(selected_ball->velocity, force), SCALING_FACTOR);
            fill_circle(color_transparent(), selected_ball->ball_circle);
            selected_ball = nullptr;
        }
    }

    // If a ball is selected, draw the vector that will be applied to the ball if the mouse is clicked again.
    if (selected_ball)
    {
        fill_circle(random_color(), selected_ball->ball_circle);
        draw_line(random_color(), selected_ball->ball_circle.center, mouse_position());
    }
}

void update_balls(vector<ball> &balls)
{
    for (ball &b : balls)
    {
        double deceleration_factor = -0.015;

        b.acceleration = vector_multiply(b.velocity, deceleration_factor);
        b.velocity = vector_add(b.velocity, b.acceleration);

        // Set velocity to 0 if the overall scale of the velocity gets very small
        if (abs(b.velocity.x*b.velocity.x + b.velocity.y * b.velocity.y) < 0.001f)
        {
            b.velocity = vector_multiply(b.velocity, 0);
        }

        b.ball_circle.center.x += b.velocity.x;
        b.ball_circle.center.y += b.velocity.y;

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

        // Check the top boundary
        if (b.ball_circle.center.y - b.ball_circle.radius < 0)
        {
            b.ball_circle.center.y = b.ball_circle.radius; // Reposition ball inside the top boundary
            b.velocity.y *= -1;                            // Reverse the y-velocity (bounce off the wall)
        }

        // Check the bottom boundary
        if (b.ball_circle.center.y + b.ball_circle.radius > screen_height())
        {
            b.ball_circle.center.y = screen_height() - b.ball_circle.radius; // Reposition ball inside the bottom boundary
            b.velocity.y *= -1;                                              // Reverse the y-velocity (bounce off the wall)
        }
    }
}

// Function to draw a Cartesian grid
void draw_cartesian_grid()
{
    const int GRID_SPACING = 50;
    int half_width = screen_width() / 2;
    int half_height = screen_height() / 2;

    // Draw vertical grid lines
    for (int x = GRID_SPACING; x < screen_width(); x += GRID_SPACING)
    {
        draw_line(COLOR_LIGHT_GRAY, x, 0, x, screen_height());
        if (x != half_width)
        {
            draw_text(to_string(x - half_width), COLOR_BLACK, x, half_height + 5);
        }
    }

    // Draw horizontal grid lines
    for (int y = GRID_SPACING; y < screen_height(); y += GRID_SPACING)
    {
        draw_line(COLOR_LIGHT_GRAY, 0, y, screen_width(), y);
        if (y != half_height)
        {
            draw_text(to_string(half_height - y), COLOR_BLACK, half_width + 5, y);
        }
    }

    // Draw axes
    draw_line(COLOR_BLACK, 0, half_height, screen_width(), half_height); // x-axis
    draw_line(COLOR_BLACK, half_width, 0, half_width, screen_height());  // y-axis
    draw_text("0", COLOR_BLACK, half_width + 5, half_height + 5);
}

int main()
{
    open_window("Ball Vectors", 800, 600);

    int num_balls = 2;

    // Vector to store all balls
    vector<ball> balls;

    for (int i = 1; i <= num_balls; ++i)
    {
        balls.push_back(add_ball(i, balls));
    }

    while (!window_close_requested("Ball Vectors"))
    {
        process_events();

        clear_screen(COLOR_WHITE);

        draw_cartesian_grid();

        resolve_and_draw_collisions(balls);

        draw_balls(balls);

        handle_inputs(balls);

        update_balls(balls);

        refresh_screen(60);
    }

    return 0;
}