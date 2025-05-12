using static SplashKitSDK.SplashKit;

SplashKitSDK.Triangle triangle = TriangleFrom(700, 200, 500, 1, 200, 500);
SplashKitSDK.Point2D mousePt;
string text;
SplashKitSDK.Color triangleClr;

OpenWindow("Point In Triangle", 800, 600);

while (!QuitRequested())
{
    ProcessEvents();

    mousePt = MousePosition();

    // Update text and triangle colour based on the mouse position in relation to the triangle
    if (PointInTriangle(mousePt, triangle))
    {
        triangleClr = ColorRed();
        text = "Point in the triangle!";
    }
    else
    {
        triangleClr = ColorGreen();
        text = "Point not in the triangle!";
    }

    ClearScreen();
    DrawTriangle(triangleClr, triangle);
    DrawText(text, ColorRed(), 100, 100);
    RefreshScreen();
}
CloseAllWindows();