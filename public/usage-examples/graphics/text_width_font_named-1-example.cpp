#include "splashkit.h"

int main()
{
    open_window("Text Width", 680, 200);
    clear_screen(COLOR_WHITE);

    load_font("LOTR", "lotr.ttf");
    set_font_style("LOTR", BOLD_FONT);
    draw_text("Ringbearer", COLOR_BLACK, "LOTR", 100, 30, 20);

    //Getting the width of the text to fill a rectange of that width
    int width = text_width("Ringbearer", "LOTR", 100);
    fill_rectangle(COLOR_BLACK, 30, 130, width, 10);
    refresh_screen();

    delay(5000);
    close_all_windows();

    return 0;
}