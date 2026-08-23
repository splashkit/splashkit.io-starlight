#include "splashkit.h"

int main()
{
    open_window("Bitmap Center", 800, 600);

    bitmap image_bitmap = load_bitmap("image_bitmap", "image1.jpg");
    point_2d center_point = bitmap_center(image_bitmap);

    clear_screen(color_white());
    draw_bitmap(image_bitmap, 0, 0);
    fill_circle(color_red(), circle_at(center_point, 5));
    refresh_screen();

    delay(5000);

    close_all_windows();
    return 0;
}