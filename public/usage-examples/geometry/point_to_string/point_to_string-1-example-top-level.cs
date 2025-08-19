using SplashKitSDK;
using static SplashKitSDK.SplashKit;

string mousePositionText = "Click to see coordinates...";

OpenWindow("Mouse Clicked Location", 600, 600);

while (!QuitRequested())
{
    ProcessEvents();

    // Check for mouse click
    if (MouseClicked(MouseButton.LeftButton))
    {
        mousePositionText = "Mouse clicked at " + PointToString(MousePosition());
    }

    // Print mouse position to screen
    ClearScreen(ColorGhostWhite());
    DrawText(mousePositionText, ColorBlack(), 100, 300);
    RefreshScreen();
}

CloseAllWindows();