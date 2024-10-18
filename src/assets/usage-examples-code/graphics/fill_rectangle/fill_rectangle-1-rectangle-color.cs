using static SplashKitSDK.SplashKit;

OpenWindow("Fill rectangle", 800, 600);

ClearScreen();
FillRectangle(ColorBlue(), 200, 200, 200, 100);
RefreshScreen();

Delay(4000);

CloseAllWindows();

