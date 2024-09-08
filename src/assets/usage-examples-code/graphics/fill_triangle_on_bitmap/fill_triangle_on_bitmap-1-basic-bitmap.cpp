#include "splashkit.h"

int main()
{
    // Open a window
    open_window("Underwater Adventure", 1000, 500);

    // Load the bitmap
    bitmap underwater_scene = load_bitmap("underwater_scene", "underwater_scene.png");

    // Fill the triangle on the bitmap
    double x1 = 285, y1 = 250;
    double x2 = 310, y2 = 240;
    double x3 = 310, y3 = 260;
    color triangle_color = COLOR_RED;

    fill_triangle_on_bitmap(underwater_scene, triangle_color, x1, y1, x2, y2, x3, y3);

    // Draw the bitmap and other graphics
    draw_bitmap(underwater_scene, 0, 0);
    draw_text("Colourful Fish", COLOR_RED, "arial", 123, 240, 200);
    draw_line(COLOR_RED, 280, 220, 305, 255);

    // Refresh the screen and wait
    refresh_screen();
    delay(5000);

    // Close all windows
    close_all_windows();

    return 0;
}
 