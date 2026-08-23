#include "splashkit.h"

int main()
{
    open_window("Get Font Style", 800, 600);

    int style_number = -1;
    font font = font_named("Century.ttf");

    while (!quit_requested())
    {
        process_events();

        if (style_number < 3)
        {
            style_number += 1;
        }
        else
        {
            style_number = 0;
        }

        if (style_number == 0)
        {
            set_font_style(font, NORMAL_FONT);
        }
        else if (style_number == 1)
        {
            set_font_style(font, BOLD_FONT);
        }
        else if (style_number == 2)
        {
            set_font_style(font, ITALIC_FONT);
        }
        else if (style_number == 3)
        {
            set_font_style(font, UNDERLINE_FONT);
        }

        clear_screen(color_white());
        // Function is used here ↓
        draw_text("The assigned numerical font style is currently set to " + std::to_string(get_font_style(font)), color_black(), 40, 60);
        draw_text("The quick brown fox jumps over the lazy dog", color_black(), font, 30, 40, 110);
        refresh_screen();

        delay(2000);
    }
    close_all_windows();
    return 0;
}