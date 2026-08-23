#include "splashkit.h"

int main()
{
    open_window("Saturation Of", 800, 600);

    color color = random_rgb_color(255);
    // Function used here ↓
    double color_saturation = saturation_of(color);
    rectangle rectangle = rectangle_from(200, 100, 400, 300);

    clear_screen(color_white());
    fill_rectangle(color, rectangle);
    draw_text("This color's saturation is " + std::to_string(color_saturation), color_black(), 235, 450);
    draw_text("It's RGBA values are: R-" + std::to_string(red_of(color)) + ", G-" + std::to_string(green_of(color)) + ", B-" + std::to_string(blue_of(color))+ ", A-" + std::to_string(alpha_of(color)), color_black(), 235, 470);
    refresh_screen();

    delay(5000);

    close_all_windows();
    return 0;
}