using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Variable Declarations
Line line = LineFrom(100, 300, 500, 300);

// Create window
Window window = OpenWindow("Select Point", 600, 600);

while (!QuitRequested())
{
    // Display line
    ClearScreen(ColorWhite());
    DrawLine(ColorBlack(), line);

    // Draw text if cursor is on line
    if (PointOnLine(MousePosition(), line))
    {
        DrawText("Point on line: " + PointToString(MousePosition()), ColorBlack(), 200, 450);
    }

    RefreshScreen();
    ProcessEvents();
}
CloseWindow(window);