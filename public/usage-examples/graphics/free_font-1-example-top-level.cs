using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Freeing Fonts", 800, 200);
Font bebasNeue = LoadFont("BebasNeue", "BebasNeue.ttf");

while (!QuitRequested())
{
    ProcessEvents();

    ClearScreen();
    if (HasFont(bebasNeue))
    {
        DrawText("Using BebasNeue Font: Press Space bar to free font", ColorBlack(), bebasNeue, 30, 20, 50);
    }
    else
    {
        DrawText("Using System Font: BebasNeue font has been freed", ColorBlack(), GetSystemFont(), 30, 20, 50);
        DrawText("Press Space bar to load BebasNeue font again", ColorBlack(), GetSystemFont(), 30, 20, 100);
    }
    RefreshScreen();

    if (KeyTyped(KeyCode.SpaceKey))
    {
        // If the font is loaded, it is freed
        // If the font has been free, it is loaded again
        if (HasFont(bebasNeue))
        {
            FreeFont(bebasNeue);
        }
        else
        {
            bebasNeue = LoadFont("BebasNeue", "BebasNeue.ttf");
        }
    }
}

// Clean up
if (HasFont(bebasNeue))
{
    FreeFont(bebasNeue);
}
CloseAllWindows();