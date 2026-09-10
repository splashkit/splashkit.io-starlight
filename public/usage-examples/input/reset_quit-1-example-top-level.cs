// using static allows calling SplashKit methods directly (e.g. ResetQuit, QuitRequested)
// using SplashKitSDK is required for the KeyCode type
using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Quit Confirmation", 600, 300);

bool running = true;     // controls the main loop
bool confirming = false; // true while the "Really quit?" prompt is showing
int cancelled = 0;       // how many times the quit request was cancelled

while (running)
{
    ProcessEvents();

    // QuitRequested becomes true when the window's close button is clicked,
    // and stays true until the program exits or ResetQuit is called
    if (QuitRequested())
        confirming = true;

    if (confirming)
    {
        // Y confirms the quit and ends the loop
        if (KeyTyped(KeyCode.YKey))
            running = false;

        // N cancels it - ResetQuit makes QuitRequested return false again
        if (KeyTyped(KeyCode.NKey))
        {
            ResetQuit();
            confirming = false;
            cancelled++;
        }
    }

    ClearScreen(ColorWhite());

    if (confirming)
    {
        DrawText("Really quit?", ColorRed(), "Arial", 28, 220, 90);
        DrawText("[Y] Yes    [N] No", ColorBlack(), "Arial", 20, 215, 150);
    }
    else
    {
        DrawText("Running - click the X to quit", ColorGreen(), "Arial", 24, 150, 90);
        DrawText("Quit requests cancelled: " + cancelled, ColorBlack(), "Arial", 20, 175, 150);
    }

    DrawText("reset_quit cancels a pending quit request", ColorGray(), "Arial", 16, 145, 230);

    RefreshScreen(60);
}

CloseAllWindows();
