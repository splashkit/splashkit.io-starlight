using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Check if audio is ready to use
if(! AudioReady())
{
    OpenAudio();
}

// Load music file
LoadMusic("adventure", "time_for_adventure.mp3");

// Start music playback
PlayMusic("adventure");

// Hold program for 10 seconds
Delay(10000);

// Free resources
FreeAllMusic();