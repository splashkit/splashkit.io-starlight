using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Point At Origin", 800, 600);

// Create a point at origin
Point2D point = PointAtOrigin();

// Create red circle at the origin point
ClearScreen();
FillCircle(ColorRed(), point.X, point.Y, 4);
RefreshScreen();

Delay(4000);
CloseAllWindows();