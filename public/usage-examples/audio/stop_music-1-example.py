from splashkit import *

# Check if audio is ready to use
if not audio_ready():
    open_audio()

# Load music file
music = load_music("adventure", "time_for_adventure.mp3")
play_music(music)

open_window("Stop/Start", 300, 200)

while not quit_requested():
    process_events()

    # Check for stop/play request
    if(mouse_clicked(MouseButton.left_button)):
        if (music_playing()):
            # Stop if playing
            stop_music()
        else:
            # Play if stopped
            play_music(music)

    # Display text showing if music is playing or not
    clear_screen(color_white())
    if (music_playing()):
        draw_text_no_font_no_size("Music Playing", color_black(), 100, 100)
    else:
        draw_text_no_font_no_size("Music Stopped", color_black(), 100, 100)
    refresh_screen()

# Cleanup
free_all_music()