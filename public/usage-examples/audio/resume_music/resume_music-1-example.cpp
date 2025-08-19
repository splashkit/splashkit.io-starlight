#include "splashkit.h"

int main()
{
    //  Check if audio is ready to use
    if (!audio_ready())
    {
        open_audio();
    }

    // Load music file and start playing
    music music = load_music("adventure", "time_for_adventure.mp3");
    play_music(music);
    bool music_playing = true;

    window window = open_window("Pause/Resume", 300, 200);

    while (!quit_requested())
    {
        process_events();

        // Check for pause/play request
        if (key_typed(SPACE_KEY))
        {
            // Check if music is paused or not
            if (music_playing)
            {
                // Pause if playing
                pause_music();
                music_playing = false;
            }
            else
            {
                // Play if paused
                resume_music();
                music_playing = true;
            }
        }

        // Display text showing if music is playing or not
        clear_window(window, COLOR_WHITE);
        if (music_playing)
        {
            draw_text_on_window(window, "Playing", COLOR_BLACK, 100, 100);
        }
        else
        {
            draw_text_on_window(window, "Paused...", COLOR_BLACK, 100, 100);
        }
        refresh_window(window);
    }

    // Cleanup
    free_all_music();
    close_all_windows();
}