using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Fill Triangle Example", 800, 600);
ClearScreen();

FillTriangle(ColorRed(), 100, 100, 200, 200, 300, 100);
RefreshScreen();

Delay(5000);
CloseAllWindows();