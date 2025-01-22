using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Point At Origin", 800, 600);

// Create a point at origin
Point2D point = PointAtOrigin();

// Create "sun" at the origin point
ClearScreen();
for (int i = 200; i > 10; i--)
{
    FillCircle(RGBColor(255, i + 50, i % 30), point.X, point.Y, i);
}
RefreshScreen();

Delay(4000);
CloseAllWindows();