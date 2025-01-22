using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create a circle (with random x position value bewteen 200 - 600)
Circle circle = CircleAt(Rnd(400) + 200, 300, 200);

OpenWindow("Circle X", 800, 600);

// Draw the Circle and x coordinate on window
ClearScreen(ColorWhite());
DrawCircle(ColorRed(), circle);
DrawText($"Circle X: {CircleX(circle)}", ColorBlack(), 100, 100);
RefreshScreen();

Delay(4000);
CloseAllWindows();