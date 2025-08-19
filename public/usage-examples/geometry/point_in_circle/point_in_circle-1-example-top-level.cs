using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window window = OpenWindow("Point In Circle", 800, 600);
Circle circle = CircleAt(400, 300, 100);
Point2D mousePt;
string text;
Color circleClr;

while (!QuitRequested())
{
    ProcessEvents();

    mousePt = MousePosition();

    // Update text and circle colour based on the mouse position in relation to the circle
    if (PointInCircle(mousePt, circle))
    {
        circleClr = ColorRed();
        text = "Point in the Circle!";
    }
    else
    {
        circleClr = ColorGreen();
        text = "Point not in the Circle!";
    }

    ClearScreen();
    DrawCircle(circleClr, circle);
    DrawText(text, ColorRed(), 100, 100);
    RefreshScreen();
}
CloseWindow(window);