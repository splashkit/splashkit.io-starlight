using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Declare variables
const int TrailLength = 50;
Point2D mousePoint;
Point2D[] mouseHistory = new Point2D[TrailLength];
Color[] colorList = { ColorBlue(), ColorRed(), ColorGreen(), ColorYellow(), ColorPink() };

OpenWindow("Cursor Trail", 600, 600);

while (!QuitRequested())
{
    mousePoint = MousePosition();
    ClearScreen(ColorBlack());

    // Set mouse position history
    for (int i = 0; i < TrailLength - 1; i++)
    {
        // Shuffle forward
        mouseHistory[i] = mouseHistory[i + 1];
    }

    mouseHistory[TrailLength - 1] = mousePoint;

    // Draw mouse trail
    for (int i = 0; i < TrailLength; i++)
    {
        DrawPixel(colorList[i % 5], mouseHistory[i]);
    }

    ProcessEvents();
    RefreshScreen(60);
}

CloseAllWindows();
