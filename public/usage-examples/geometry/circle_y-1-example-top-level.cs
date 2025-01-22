using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create a circle (with random y position value between 200 - 400)
Circle circle = CircleAt(400, Rnd(200) + 200, 200);

OpenWindow("Circle Y", 800, 600);

// Draw the Circle and y coordinate on window
ClearScreen(ColorWhite());
DrawCircle(ColorRed(), circle);
DrawText("Circle Y: " + CircleY(circle), ColorBlack(), 100, 100);

// Draw a line to show the circle Y coordinate
DrawLine(ColorBlack(), 0, CircleY(circle), ScreenWidth(), CircleY(circle));

// Draw 10 circles with radius of 50 and the same circle y coordinate
for (int i = 0; i < 10; i++)
{
    DrawCircle(ColorBlue(), i * 60 + 100, CircleY(circle), 50);
}
RefreshScreen();

Delay(4000);
CloseAllWindows();