using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Distance From Center", 600, 600);

// Define the variables
Point2D center_pt = ScreenCenter();
Point2D mouse_pt;
float pt_pt_distance;

while (!QuitRequested())
{
    ProcessEvents();

    // Get "current" Mouse Position
    mouse_pt = MousePosition();

    // Calculate the distance between the center point and the current mouse position
    pt_pt_distance = PointPointDistance(center_pt, mouse_pt);

    // Draw line and distance between center of window (filled circle) and mouse point
    ClearScreen();
    FillCircle(ColorRed(), center_pt.X, center_pt.Y, 5);
    DrawLine(ColorBlue(), center_pt, mouse_pt);
    DrawText(pt_pt_distance.ToString(), ColorBlack(), mouse_pt.X + 10, mouse_pt.Y - 10);
    RefreshScreen();
}

// Close all opened windows
CloseAllWindows();