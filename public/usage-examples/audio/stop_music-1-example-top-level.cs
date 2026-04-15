using static SplashKitSDK.SplashKit;

// Check if audio is ready to use
if (!AudioReady())
{
    OpenAudio();
}

// Load music file
LoadMusic("adventure", "time_for_adventure.mp3");
PlayMusic("adventure");

OpenWindow("Stop/Start", 300, 200);

while (!QuitRequested())
{
    ProcessEvents();

    // Check for stop/play request
    if (MouseClicked(SplashKitSDK.MouseButton.LeftButton))
    {
        if (MusicPlaying())
        {
            // Stop if playing
            StopMusic();
        }
        else
        {
            // Play if stopped
            PlayMusic("adventure");
        }
    }

    // Display text showing if music is playing or not
    ClearScreen(ColorWhite());
    if (MusicPlaying())
    {
        DrawText("Music Playing", ColorBlack(), 100, 100);
    }
    else
    {
        DrawText("Music Stopped", ColorBlack(), 100, 100);
    }
    RefreshScreen();
}

// Cleanup
FreeAllMusic();