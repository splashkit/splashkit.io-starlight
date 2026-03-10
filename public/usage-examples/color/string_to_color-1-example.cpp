#include "splashkit.h"

int main()
{
    open_window("String To Color", 800, 600);
    // Change this string's value to produce different colors ↓
    string color_hex = "#921e64d9";
    color color = string_to_color(color_hex);
    rectangle rectangle = rectangle_from(200, 100, 400, 300);

    clear_screen(color_white());
    fill_rectangle(color, rectangle);
    draw_text("Current color's RGBA hex value is " + color_hex, color_black(), 235, 450);
    draw_text("It's RGB values are: R-" + std::to_string(red_of(color)) + ", G-" + std::to_string(green_of(color)) + ", B-" + std::to_string(blue_of(color)), color_black(), 235, 470);
    refresh_screen();

    delay(5000);

    close_all_windows();
    return 0;
}