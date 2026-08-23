using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// open a window
Window wind = OpenWindow("DON'T CLICK THE BUTTON!", 400, 200);

bool countdownStarted = false;
int countdown = 5;
// SplashKitSDK.Timer needed to distinguish from System.Threading.Timer
SplashKitSDK.Timer countdownTimer = new SplashKitSDK.Timer("countdown");

// main loop
while (!QuitRequested())
{
    // get user events
    ProcessEvents();

    // clear screen
    ClearWindow(wind, ColorWhite());

    if (!countdownStarted)
    {
        // Show the button before countdown starts
        if (Button("Click Me!", RectangleFrom(150, 85, 100, 30)))
        {
            countdownStarted = true;
            StartTimer(countdownTimer);
        }
    }
    else
    {
        // Display countdown
        DrawText($"This window will self destruct in {countdown}", ColorBlack(), "arial", 18, 50, 85);

        // Check if 1 second has passed
        if (TimerTicks(countdownTimer) > 1000)
        {
            countdown--;
            ResetTimer(countdownTimer);

            if (countdown <= 0)
            {
                CloseWindow(wind);
                break;
            }
        }
    }

    // draw interface and refresh
    DrawInterface();
    RefreshWindow(wind);
}

// close all open windows
CloseAllWindows();