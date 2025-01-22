#include "splashkit.h"

int main()
{
    // Create Window and empty bitmap
    open_window("Random Bitmap Points with Triangles", 600, 600);
    bitmap bmp = create_bitmap("Random Triangles", 600, 600);

    for (int i = 0; i < 10; i++)
    {
        // Create triangle using random points on bitmap
        triangle triangle = triangle_from(
            random_bitmap_point(bmp),
            random_bitmap_point(bmp),
            random_bitmap_point(bmp));

        fill_triangle_on_bitmap(bmp, random_color(), triangle);
    }

    // Draw the bitmap
    clear_screen(color_white_smoke());
    draw_bitmap(bmp, 0, 0);
    refresh_screen();

    delay(5000);
    close_all_windows();

    return 0;
}