using static SplashKitSDK.SplashKit;

OpenWindow("Clover Drawing with Fill Ellipse", 1000, 600);

ClearScreen();
FillEllipse(ColorGreen(), 150, 225, 400, 200);
FillEllipse(ColorGreen(), 375, 0, 200, 400);
FillEllipse(ColorGreen(), 400, 225, 400, 200);
FillRectangle(ColorBrown(), 470, 400, 10, 150);
RefreshScreen();

Delay(4000);

CloseAllWindows();