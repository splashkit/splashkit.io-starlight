#include "splashkit.h"

int main()
{
    // Download resources
    download_sound_effect("Hello World", "https://programmers.guide/resources/code-examples/part-0/hello-world-snippet-saddle-club.ogg", 443);
    download_font("main", "https://programmers.guide/resources/code-examples/part-0/Roboto-Italic.ttf", 443);
    download_bitmap("Earth", "https://programmers.guide/resources/code-examples/part-0/earth.png", 443);
    download_bitmap("SmallEarth", "https://programmers.guide/resources/code-examples/part-0/earth-small.png", 443);
    download_bitmap("SplashKitBox", "https://programmers.guide/resources/code-examples/part-0/skbox.png", 443);

    open_window("Hello World: Using Resources with SplashKit", 800, 600);
    play_sound_effect("Hello World");

    clear_screen(COLOR_WHITE);
    draw_text("Anyone remember the \"Hello World\" Saddle Club song?", COLOR_BLACK, "main", 30, 40, 200);
    refresh_screen();
    delay(2500);

    clear_screen(COLOR_WHITE);

    // H
    draw_bitmap("SmallEarth", 20, 100);
    draw_bitmap("SmallEarth", 20, 130);
    draw_bitmap("SmallEarth", 20, 160);
    draw_bitmap("SmallEarth", 20, 190);
    draw_bitmap("SmallEarth", 20, 220);
    draw_bitmap("SmallEarth", 52, 160);
    draw_bitmap("SmallEarth", 84, 100);
    draw_bitmap("SmallEarth", 84, 130);
    draw_bitmap("SmallEarth", 84, 160);
    draw_bitmap("SmallEarth", 84, 190);
    draw_bitmap("SmallEarth", 84, 220);
    refresh_screen();
    delay(200);

    // E
    draw_bitmap("SmallEarth", 148, 100);
    draw_bitmap("SmallEarth", 148, 130);
    draw_bitmap("SmallEarth", 148, 160);
    draw_bitmap("SmallEarth", 148, 190);
    draw_bitmap("SmallEarth", 148, 220);
    draw_bitmap("SmallEarth", 180, 100);
    draw_bitmap("SmallEarth", 212, 100);
    draw_bitmap("SmallEarth", 180, 160);
    draw_bitmap("SmallEarth", 180, 220);
    draw_bitmap("SmallEarth", 212, 220);
    refresh_screen();
    delay(200);

    // L
    draw_bitmap("SmallEarth", 276, 100);
    draw_bitmap("SmallEarth", 276, 130);
    draw_bitmap("SmallEarth", 276, 160);
    draw_bitmap("SmallEarth", 276, 190);
    draw_bitmap("SmallEarth", 276, 220);
    draw_bitmap("SmallEarth", 308, 220);
    draw_bitmap("SmallEarth", 340, 220);
    refresh_screen();
    delay(200);

    // L
    draw_bitmap("SmallEarth", 404, 100);
    draw_bitmap("SmallEarth", 404, 130);
    draw_bitmap("SmallEarth", 404, 160);
    draw_bitmap("SmallEarth", 404, 190);
    draw_bitmap("SmallEarth", 404, 220);
    draw_bitmap("SmallEarth", 436, 220);
    draw_bitmap("SmallEarth", 468, 220);
    refresh_screen();
    delay(200);

    // O
    draw_bitmap("SmallEarth", 530, 160);
    draw_bitmap("SmallEarth", 622, 160);
    draw_bitmap("SmallEarth", 540, 128);
    draw_bitmap("SmallEarth", 560, 100);
    draw_bitmap("SmallEarth", 592, 100);
    draw_bitmap("SmallEarth", 612, 128);
    draw_bitmap("SmallEarth", 540, 192);
    draw_bitmap("SmallEarth", 560, 220);
    draw_bitmap("SmallEarth", 592, 220);
    draw_bitmap("SmallEarth", 612, 192);
    refresh_screen();
    delay(500);

    // World
    draw_bitmap("Earth", 100, 350);
    refresh_screen();
    delay(2000);

    // SplashKit ("Me")
    draw_bitmap("SplashKitBox", 450, 300);
    draw_text("SplashKit!", COLOR_BLACK, "main", 50, 450, 530);
    refresh_screen();
    delay(2000);

    close_all_windows();

    return 0;
}