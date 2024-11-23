#include "splashkit.h"

int main()
{
  // Open the window
  open_window("Bitmap Collisions", 315, 330);
  
  // Load the bitmap and set its position
  bitmap sk_bmp = load_bitmap("skbox", "skbox.png");
  point_2d bmp_loc = {50, 50};
  
  // Define the circles and their positions
  circle black_circle;
  circle red_circle;
  point_2d black_circle_loc = {20, 20};
  point_2d red_circle_loc = {150, 150};
  double circle_rad = 20;
  
  // Set circle centers and radii
  black_circle.center = black_circle_loc;
  black_circle.radius = circle_rad;
  red_circle.center = red_circle_loc;
  red_circle.radius = circle_rad;
  
  // Clear the screen and draw the elements
  clear_screen(rgb_color(67, 80, 175));
  draw_bitmap(sk_bmp, bmp_loc.x, bmp_loc.y);
  draw_circle(COLOR_BLACK, black_circle);
  draw_circle(COLOR_RED, red_circle);
  
  // Check for collisions and display messages
  if (bitmap_circle_collision(sk_bmp, bmp_loc, black_circle))
      write_line("Black Circle Collision!");
  if (bitmap_circle_collision(sk_bmp, bmp_loc, red_circle))
      write_line("Red Circle Collision!");
  
  // Refresh the screen, wait, and close the window
  refresh_screen();
  delay(4000);
  close_all_windows();

  return 0;
}