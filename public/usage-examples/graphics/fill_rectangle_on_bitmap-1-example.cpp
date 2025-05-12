#include "splashkit.h"

int main()
{
    // Create a new window with title and dimensions 
    open_window("Night Sky", 500, 533);

    // Create and load new bitmap using the picture file and initialise new bitmap variable
    bitmap night_sky = load_bitmap("night_sky", "sky.jpg");

    // Create black rectangles for buildings, with x and y axis and dimensions  
    fill_rectangle_on_bitmap(night_sky, COLOR_BLACK, 40, 200, 100, 400); //Building 1
    fill_rectangle_on_bitmap(night_sky, COLOR_BLACK, 200, 400, 100, 400); //Building 2
    fill_rectangle_on_bitmap(night_sky, COLOR_BLACK, 350, 300, 100, 300); //Building 3

    // For loop to create the illumimated windows on each building with different numbers depending 
    // on the placement of the building
    // Building 1
    for (int j = 220; j < 700; j += 50)
    {
        for (int i = 55; i < 135; i += 20)
        {
            fill_rectangle_on_bitmap(night_sky, COLOR_ORANGE, i, j, 10, 20);
        }
    }

    // Building 2
    for (int j = 420; j < 570; j += 50)
    {
        for (int i = 215; i < 295; i += 20)
        {
            fill_rectangle_on_bitmap(night_sky, COLOR_YELLOW, i, j, 10, 20);
        }
    }

    // Building 3
    for (int j = 320; j < 700; j += 50)
    {
        for (int i = 365; i < 440; i += 20)
        {
            fill_rectangle_on_bitmap(night_sky, COLOR_ORANGE, i, j, 10, 20);
        }
    }
    
    // Clear screen and draw bitmap
    clear_screen();
    draw_bitmap(night_sky, 0, 0);
    refresh_screen();
    delay(5000);

    // Free resources and close windows 
    free_all_bitmaps();
    close_all_windows();
}