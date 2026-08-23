using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Boring Screensaver", 800, 600);

Circle circle;
int circleSize = 30;
float rotationDegrees = 0;
Point2D circleCoordinates;
bool growing = true;
// SplashKitSDK.Timer needed to distinguish from System.Threading.Timer ↓
SplashKitSDK.Timer mainTimer = CreateTimer("mainTimer");
StartTimer(mainTimer);
SplashKitSDK.Timer reverseTimer = CreateTimer("reverseTimer");
StartTimer(reverseTimer);

while (!QuitRequested())
{
    rotationDegrees += 0.005f;
    circleCoordinates = PointAt(300 + 150 * Cosine(rotationDegrees), 300 + 150 * Sine(rotationDegrees));
    circle = CircleAt(circleCoordinates, circleSize);

    if (TimerTicks(mainTimer) >= 40 && growing == true)
    {
        circleSize += 1;
        ResetTimer(mainTimer);
    }
    else if (TimerTicks(reverseTimer) >= 3000)
    {
        growing = false;
    }

    if (TimerTicks(mainTimer) >= 40 && growing == false)
    {
        circleSize -= 1;
        ResetTimer(mainTimer);
    }
    else if (TimerTicks(reverseTimer) >= 6000)
    {
        growing = true;
        ResetTimer(reverseTimer);
    }

    ProcessEvents();

    ClearScreen(ColorWhite());
    // A rectangle is drawn which encompasses the circle. It shares the same height, width and position
    DrawRectangle(ColorBlack(), RectangleAround(circle));
    FillCircle(ColorRed(), circle);
    RefreshScreen();
}
CloseAllWindows();