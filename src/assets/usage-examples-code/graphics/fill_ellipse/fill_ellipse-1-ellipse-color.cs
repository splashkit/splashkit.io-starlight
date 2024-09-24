using static SplashKitSDK.SplashKit;

OpenWindow("Fill Ellipse", 800, 600);
ClearScreen();

FillEllipse(ColorBlue(), 200, 200, 100, 200);
RefreshScreen(60);
Delay(4000);

CloseAllWindows();
