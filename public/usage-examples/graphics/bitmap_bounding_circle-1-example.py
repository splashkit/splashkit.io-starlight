from splashkit import *

open_window("Bitmap Bounding Circle", 800, 600)

vertical_bitmap = load_bitmap("vertical_bitmap", "image1.png")
horizontal_bitmap = load_bitmap("horizontal_bitmap", "image2.png")

vert_bitmap_circle = bitmap_bounding_circle(vertical_bitmap, point_at(210, 210))
hori_bitmap_circle = bitmap_bounding_circle(horizontal_bitmap, point_at(580, 400))

while not quit_requested():
    process_events()
    clear_screen_to_white()
    
    draw_bitmap(vertical_bitmap, 141, 60)
    draw_bitmap(horizontal_bitmap, 480, 344)

    draw_circle_record(color_black(), vert_bitmap_circle)
    draw_circle_record(color_black(), hori_bitmap_circle)
        
    refresh_screen()

close_all_windows()