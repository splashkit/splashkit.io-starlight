using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window blueWindow = OpenWindow("Blue Triangle", 200, 200);
Window redWindow = OpenWindow("Red Triangle", 200, 200);
MoveWindowTo(redWindow, WindowX(blueWindow) + WindowWidth(blueWindow), WindowY(blueWindow));

// Define the triangles to draw
Triangle blueTriangle = TriangleFrom(PointAt(50, 100), PointAt(100, 50), PointAt(150, 100));
Triangle redTriangle = TriangleFrom(PointAt(50, 50), PointAt(100, 100), PointAt(150, 50));

// Fill a blue triangle on the first window
ClearWindow(blueWindow, ColorWhite());
FillTriangleOnWindow(blueWindow, ColorBlue(), blueTriangle);
RefreshWindow(blueWindow);

// Fill a red triangle on the second window
ClearWindow(redWindow, ColorWhite());
FillTriangleOnWindow(redWindow, ColorRed(), redTriangle);
RefreshWindow(redWindow);

Delay(10000);

CloseWindow(blueWindow);
CloseWindow(redWindow);