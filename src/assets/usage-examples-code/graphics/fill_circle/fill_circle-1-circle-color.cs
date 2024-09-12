using static SplashKitSDK.SplashKit;

OpenWindow("Fill Circle", 800, 600);
ClearScreen();

FillCircle(ColorBlue(), 400, 300, 200);
RefreshScreen(60);
Delay(4000);

CloseAllWindows();
