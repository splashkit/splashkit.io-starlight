using static SplashKitSDK.SplashKit;

OpenWindow("Fill Rectangle", 800, 600);
ClearScreen();

FillRectangle(ColorBlue(), 200, 200, 200, 200);
RefreshScreen(60);
Delay(4000);

CloseAllWindows();

