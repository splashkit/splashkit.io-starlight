from splashkit import *

# Check if audio is ready to use
if (not audio_ready()):
    open_audio()

# Load music file and start playing
music = load_music("adventure", "time_for_adventure.mp3")
play_music(music)

window = open_window("Pause/Resume", 300, 200)

while (not quit_requested()):
    process_events()

    # Check for pause/play request
    if (key_typed(KeyCode.space_key)):
        # Check if music is paused or not
        if (music_playing()):
            # Pause if playing
            pause_music()
        else:
            # Play if paused
            resume_music()

    # Display text showing if music is playing or not
    clear_window(window, color_white())
    if (music_paused()):
        draw_text_on_window_no_font_no_size(window, "Paused...", color_black(), 100, 100)
    else:
        draw_text_on_window_no_font_no_size(window, "Playing", color_black(), 100, 100)
    refresh_window(window)

# Cleanup
free_all_music()
close_all_windows()