using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Check if audio is ready to use
if (!AudioReady())
{
    OpenAudio();
}

// Load music file and start playing
Music music = LoadMusic("Adventure", "time_for_adventure.mp3");
PlayMusic(music);
bool musicPlaying = true;

Window window = OpenWindow("Pause/Resume", 300, 200);

while (!QuitRequested())
{
    ProcessEvents();

    // Check for pause/play request
    if (KeyTyped(KeyCode.SpaceKey))
    {
        // Check if music is paused or not
        if (musicPlaying)
        {
            // Pause if playing
            PauseMusic();
            musicPlaying = false;
        }
        else
        {
            // Play if paused
            ResumeMusic();
            musicPlaying = true;
        }
    }

    // Display text showing if music is playing or not
    ClearWindow(window, ColorWhite());
    if (musicPlaying)
    {
        DrawTextOnWindow(window, "Playing", ColorBlack(), 100, 100);
    }
    else
    {
        DrawTextOnWindow(window, "Paused...", ColorBlack(), 100, 100);
    }
    RefreshWindow(window);
}

// Cleanup
FreeAllMusic();
CloseAllWindows();