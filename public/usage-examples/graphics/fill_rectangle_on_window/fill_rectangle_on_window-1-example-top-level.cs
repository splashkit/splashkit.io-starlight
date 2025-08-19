using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window blueWindow = OpenWindow("Blue Rectangle", 200, 200);
Window redWindow = OpenWindow("Red Rectangle", 200, 200);
MoveWindowTo(redWindow, WindowX(blueWindow) + WindowWidth(blueWindow), WindowY(blueWindow));

// Fill a blue rectangle on the first window
ClearWindow(blueWindow, ColorWhite());
FillRectangleOnWindow(blueWindow, ColorBlue(), 50, 50, 100, 50);
RefreshWindow(blueWindow);

// Fill a red rectangle on the second window
ClearWindow(redWindow, ColorWhite());
FillRectangleOnWindow(redWindow, ColorRed(), 50, 50, 100, 50);
RefreshWindow(redWindow);

Delay(5000);

CloseWindow(blueWindow);
CloseWindow(redWindow);