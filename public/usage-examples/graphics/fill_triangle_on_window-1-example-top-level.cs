using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window blueWindow = OpenWindow("Blue Triangle", 200, 200);
Window redWindow = OpenWindow("Red Triangle", 200, 200);
MoveWindowTo(redWindow, WindowX(blueWindow) + WindowWidth(blueWindow), WindowY(blueWindow));

// Fill a blue triangle on the first window
ClearWindow(blueWindow, ColorWhite());
FillTriangleOnWindow(blueWindow, ColorBlue(), 50, 100, 100, 50, 150, 100);
RefreshWindow(blueWindow);

// Fill a red triangle on the second window
ClearWindow(redWindow, ColorWhite());
FillTriangleOnWindow(redWindow, ColorRed(), 50, 50, 100, 100, 150, 50);
RefreshWindow(redWindow);

Delay(10000);

CloseWindow(blueWindow);
CloseWindow(redWindow);