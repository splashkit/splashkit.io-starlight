using static SplashKitSDK.SplashKit;

OpenWindow("Fill Ellipse", 800, 600);

ClearScreen();
FillEllipse(ColorBlue(), 200, 200, 400, 200);
// Added rectangle with same arguments as above for x, y, width and height
DrawRectangle(ColorRed(), 200, 200, 400, 200);
RefreshScreen();

Delay(4000);

CloseAllWindows();
