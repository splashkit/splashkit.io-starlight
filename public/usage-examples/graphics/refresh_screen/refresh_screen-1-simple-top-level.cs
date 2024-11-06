using static SplashKitSDK.SplashKit;

OpenWindow("House Drawing", 800, 600);

ClearScreen(ColorWhite());
RefreshScreen();
Delay(1000);

FillEllipse(ColorBrightGreen(), 0, 400, 800, 400);
RefreshScreen();
Delay(1000);

FillRectangle(ColorGray(), 300, 300, 200, 200);
RefreshScreen();
Delay(1000);

FillTriangle(ColorRed(), 250, 300, 400, 150, 550, 300);
RefreshScreen();
Delay(5000);

CloseAllWindows();