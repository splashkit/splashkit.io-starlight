#include "splashkit.h"

int main()
{
  // Load font
  font my_font = load_font("MyFont", "RobotoSlab.ttf");
  
  open_window("Font Load Example", 800, 600);

  // Draw text using loaded font
  draw_text("Hello, SplashKit!", color_black(), my_font, 40, 250, 270);
  refresh_screen();

  delay(5000);
  close_all_windows();
}
