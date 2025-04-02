#include "splashkit.h"

//choice of direction
enum fill_direction
{
    TOP_TO_BOTTOM,
    BOTTOM_TO_TOP,
    LEFT_TO_RIGHT,
    RIGHT_TO_LEFT
};

void draw_circle_and_fill(double x, double y, double width, double height, float fill_amount, fill_direction direction)
{
    //From 0.0 to 1.0

    draw_ellipse(COLOR_WHITE, x, y, width, height);

    //Uses a rectangle for the fill calculation
    rectangle fill_rect;

    switch (direction)
    {
        case TOP_TO_BOTTOM:
            fill_rect = rectangle_from(x, y, width, height * fill_amount);
            break;
        case BOTTOM_TO_TOP:
            fill_rect = rectangle_from(x, y + (1 - fill_amount) * height, width, height * fill_amount);
            break;
        case LEFT_TO_RIGHT:
            fill_rect = rectangle_from(x, y, width * fill_amount, height);
            break;
        case RIGHT_TO_LEFT:
            fill_rect = rectangle_from(x + (1 - fill_amount) * width, y, width * fill_amount, height);
            break;
    }

    // Now fill the ellipse
    fill_ellipse(COLOR_BLUE, fill_rect);
}

int main()
{
    open_window("Circle and Fill", 600, 600);
    clear_screen(COLOR_WHITE);

    //Fill 0.6 from top to bottom
    draw_circle_and_fill(100, 100, 200, 200, 0.6, TOP_TO_BOTTOM);

    refresh_screen();

    return 0;
}
