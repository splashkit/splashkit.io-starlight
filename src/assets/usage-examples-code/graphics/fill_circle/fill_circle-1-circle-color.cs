using static SplashKitSDK.SplashKit;

OpenWindow("Fill Circle", 800, 600);

ClearScreen();
FillCircle(ColorBlue(), 300, 300, 200);
RefreshScreen();

Delay(4000);

CloseAllWindows();
