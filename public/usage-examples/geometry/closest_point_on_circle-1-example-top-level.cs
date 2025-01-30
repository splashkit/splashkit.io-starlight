using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Closest point", 600, 600);

// Declare variables
Point2D circle_pt = ScreenCenter();
Circle circle = CircleAt(circle_pt, 100);
Point2D mouse_pt = MousePosition();
Point2D closest_point;

while (!QuitRequested())
{
    ProcessEvents();

    // Get "current" Mouse Position
    mouse_pt = MousePosition();

    // Calculate the closest distance between the current mouse position and the circle
    closest_point = ClosestPointOnCircle(mouse_pt, circle);

    // Draw circle and indicated points
    ClearScreen();
    DrawCircle(ColorBlack(), circle);
    FillCircle(ColorRed(), closest_point.X, closest_point.Y, 5);
    FillCircle(ColorBlue(), mouse_pt.X, mouse_pt.Y, 5);
    RefreshScreen();
}

CloseAllWindows();