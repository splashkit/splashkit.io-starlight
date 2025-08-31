#include "splashkit.h"

int main(int argv, char** args)
{
    // Print instructions in terminal
    write_line("\n1. Press Spacebar for \"jump\" sound");
    write_line("2. Click anywhere in the window for \"explosion\" sound\n");

    double volume = 0.5;
    // Open Window and load sound effects
    open_window("test", 600,600);
    load_sound_effect("jump","jump.wav");
    load_sound_effect("explosion","explosion.wav");
    load_music("adventure", "time_for_adventure.mp3");
    play_music("adventure",1000);

    // Hang window until quit
    while (!quit_requested())
    {
        process_events();

        if(key_down(SPACE_KEY)) 
            play_sound_effect("jump");
        if(mouse_clicked(LEFT_BUTTON))
            play_sound_effect("explosion",volume);
    }
    // Cleanup and free memory
    close_all_windows();
    free_all_sound_effects();
    free_all_music();
    
    return 0;
}