#include "splashkit.h"

int main()
{
    // Open a window
    open_window("Happy Hat", 618, 618);

    // Load the bitmaps for sad and smiling emojis (https://openmoji.org/library/#group=smileys-emotion)
    bitmap sad_emoji = load_bitmap("sad_emoji", "sad_emoji.png");
    bitmap smiling_emoji = load_bitmap("smiling_emoji", "smiling_emoji.png");

    // Draw the sad emoji and add a hat
    clear_screen(COLOR_BLACK);
    draw_bitmap(sad_emoji, 0, 0);
    refresh_screen();
    delay(1000);

    // Draw a triangle hat on the smiling emoji
    fill_triangle_on_bitmap(smiling_emoji, COLOR_RED, 100, 200, 309, 20, 520, 200);

    // Clear screen and switch to the smiling emoji
    clear_screen(COLOR_BLACK);
    draw_bitmap(smiling_emoji, 0, 0);
    refresh_screen();
    delay(1000);

    // Spin the smiling emoji with the hat
    for (int i = 0; i < 360; i++)
    {
        clear_screen(COLOR_BLACK);
        draw_bitmap(smiling_emoji, 0, 0, option_rotate_bmp(i));
        refresh_screen();
        delay(10);
    }

    // Free the bitmap resource
    free_all_bitmaps();
    // Close all windows
    close_all_windows();

    return 0;
}
 