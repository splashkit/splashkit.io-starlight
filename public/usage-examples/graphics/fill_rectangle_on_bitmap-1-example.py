from splashkit import *

# Create a new window with title and dimensions 
open_window("Night Sky", 500, 533)

# Create and load new bitmap using the picture file and initialise new bitmap variable
night_sky = load_bitmap("night_sky", "sky.jpg")

# Create black rectangles for buildings, with x and y axis and dimensions  
fill_rectangle_on_bitmap(night_sky, color_black(), 40, 200, 100, 400) # Building 1
fill_rectangle_on_bitmap(night_sky, color_black(), 200, 400, 100, 400) # Building 2
fill_rectangle_on_bitmap(night_sky, color_black(), 350, 300, 100, 300) # Building 3

# Building 1
for j in range(220, 700, 50):
    for i in range(55, 135, 20):
        fill_rectangle_on_bitmap(night_sky, color_orange(), i, j, 10, 20)

# Building 2
for j in range(420, 570, 50):
    for i in range(215, 295, 20):
          fill_rectangle_on_bitmap(night_sky, color_yellow(), i, j, 10, 20)
    
# Building 3
for j in range(320, 700, 50):
    for i in range(365, 440, 20):
        fill_rectangle_on_bitmap(night_sky, color_orange(), i, j, 10, 20)

# Clear screen and draw bitmap
clear_screen_to_white()
draw_bitmap(night_sky, 0, 0)
refresh_screen()
delay(5000)

# Free resources and close windows 
free_all_bitmaps()
close_all_windows()