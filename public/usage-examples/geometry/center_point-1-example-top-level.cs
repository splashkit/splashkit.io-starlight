using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Glowing Blue Circle", 600, 600);

int outer_circle_radius = 255;

// Create a circle in center of window
Circle outer_circle = CircleAt(ScreenCenter(), outer_circle_radius);

// Get center point of circle
Point2D circle_centre = CenterPoint(outer_circle);

while (!QuitRequested())
{
    ProcessEvents();

    // Draw glowing circle
    ClearScreen(ColorBlack());
    for (int i = outer_circle_radius; i > 5; i--)
    {
        FillCircle(RGBColor(0, 0, 255 - i), CircleAt(circle_centre, i));
    }
    RefreshScreen();
}
CloseAllWindows();