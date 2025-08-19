using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Draw Circles", 800, 600);

// Create circles with different radii
Circle circle1 = CircleAt(ScreenCenter(), 50);
Circle circle2 = CircleAt(ScreenCenter(), 100);

ClearScreen();

// Draw the circles with different colors
DrawCircle(ColorRed(), circle1);
DrawCircle(ColorBlue(), circle2);
DrawCircle(ColorOrange(), CircleAt(ScreenCenter(), 150));
DrawCircle(ColorGreen(), CircleAt(ScreenCenter(), 200));

RefreshScreen();

Delay(4000);
CloseAllWindows();