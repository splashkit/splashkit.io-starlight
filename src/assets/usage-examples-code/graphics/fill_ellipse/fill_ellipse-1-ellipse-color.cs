using static SplashKitSDK.SplashKit;

OpenWindow("Fill Ellipse", 800, 600);
ClearScreen();

FillEllipse(ColorBlue(), 200, 200, 400, 200);
RefreshScreen(60);
DrawRectangle(ColorRed(), 200, 200, 400, 200);
RefreshScreen(60);
Delay(4000);

CloseAllWindows();
