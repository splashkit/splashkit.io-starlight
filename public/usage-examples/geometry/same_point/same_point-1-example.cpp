#include "splashkit.h"

point_2d get_point(string prompt)
{
    // Get user input
    write(prompt);
    string guess_input = read_line();
    vector<string> coords = split(guess_input, ',');

    // Validate input
    while (!is_double(coords[0]) || !is_double(coords[1]))
    {
        write_line("Invalid input. Try again.");
        write(prompt);
        guess_input = read_line();
        coords = split(guess_input, ',');
    }

    // Convert input
    double guess_x = convert_to_double(coords[0]);
    double guess_y = convert_to_double(coords[1]);
    return point_at(guess_x, guess_y);
}

int main()
{
    //  Variable declarations
    point_2d target_point = point_at(50, 75);
    point_2d guess_point;

    write_line("Guess the coordinate inside (100,100)");

    // Get point input from user
    guess_point = get_point("Enter your coordinates as x,y: ");

    while (!same_point(target_point, guess_point))
    {
        // Clues
        if (target_point.x > guess_point.x)
            write_line("x is too low");
        else if (target_point.x < guess_point.x)
            write_line("x is too high");
        else
            write_line("x is correct !!!");

        if (target_point.y > guess_point.y)
            write_line("y is too low");
        else if (target_point.y < guess_point.y)
            write_line("y is too high");
        else
            write_line("y is correct !!!");

        write_line("Try Again!");
        guess_point = get_point("Enter your coordinates as x,y: ");
    }
    write_line("You Win!");

    return 0;
}