using static SplashKitSDK.SplashKit;

// Variable Declarations
SplashKitSDK.Point2D mousePt;
SplashKitSDK.Rectangle boundary = RectangleFrom(150, 150, 300, 100);
string text;
SplashKitSDK.Color color1;
SplashKitSDK.Color color2;
SplashKitSDK.Timer flashingTimer = CreateTimer("flash time");

OpenWindow("Cursor Jail", 600, 600);
StartTimer(flashingTimer);

while (!QuitRequested())
{
    ProcessEvents();

    // Get mouse position
    mousePt = MousePosition();

    // Check if mouse is in the boundary
    if (PointInRectangle(mousePt, boundary))
    {
        text = "";
        color1 = ColorGreen();
        color2 = ColorGreen();
        ResetTimer(flashingTimer);
    }
    else
    {
        // Flash screen red and blue if mouse has escaped boundary
        text = "JAILBREAK";
        color1 = ColorRoyalBlue();
        color2 = ColorDarkRed();
    }

    // Draw UI using timer ticks
    if (TimerTicks(flashingTimer) < 500)
    {
        ClearScreen(color1);
        FillRectangle(ColorWhite(), boundary);
        RefreshScreen();
    }
    if (TimerTicks(flashingTimer) >= 500 && TimerTicks(flashingTimer) < 1000)
    {
        ClearScreen(color2);
        FillRectangle(ColorWhite(), boundary);
        DrawText(text, ColorBlack(), 250, 400);
        RefreshScreen();
    }
    if (TimerTicks(flashingTimer) >= 1000)
    {
        ResetTimer(flashingTimer);
    }
}
CloseAllWindows();