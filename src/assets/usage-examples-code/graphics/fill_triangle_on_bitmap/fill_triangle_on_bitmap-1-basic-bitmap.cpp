#include "splashkit.h"

int main()
{
    open_window("Underwater Adventure", 1000, 500);
    clear_screen();
    
    bitmap underwater_scene = load_bitmap("underwater_scene", "underwater_scene.png");
    draw_bitmap(underwater_scene, 0, 0);
    draw_text("Colourful Fish", COLOR_RED, "arial", 123, 240, 200);
    draw_line(COLOR_RED, 280, 220, 305, 255);
    fill_triangle(COLOR_RED, 285, 250, 310, 240, 310, 260);
    
    refresh_screen();
    delay(5000);
    
    close_all_windows();
    return 0;
}
