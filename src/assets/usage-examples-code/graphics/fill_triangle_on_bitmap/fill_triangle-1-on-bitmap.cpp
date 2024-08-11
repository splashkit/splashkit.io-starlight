#include "splashkit.h"

int main()
{

    open_window("Underwater Adventure", 1000, 800);
    clear_screen();
    bitmap underwater_scene = load_bitmap("underwater_scene", "underwater_scene.png");
    draw_bitmap(underwater_scene, 0, 0);
    draw_text("Colourful Fish", COLOR_RED, "arial", 23, 140, 100);
    draw_line(COLOR_RED, 180, 120, 205, 155);
    fill_triangle(COLOR_RED, 185, 150, 210, 140, 210, 160);

    refresh_screen();
    delay(5000);
    
    close_all_windows();
    return 0;
}
