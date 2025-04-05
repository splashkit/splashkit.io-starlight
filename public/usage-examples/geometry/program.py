from splashkit import *


def main():
    open_window("Circle At Example", 800, 600)
    my_circle = circle_at_from_points(300, 200, 50)

    while not window_close_requested("Circle At Example"):
        process_events()
        clear_screen(Color.White)

        # Draw the circle
        fill_circle(Color.Blue, my_circle)

        refresh_screen() 

if __name__ == "__main__":
    main()