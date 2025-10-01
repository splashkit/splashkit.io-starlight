using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Avoid the Rectangle", 800, 600);

// Define line's start point and a static rectangle
Point2D startPt = PointAt(150, 100);
Rectangle rectangle = RectangleFrom(250, 200, 300, 200);

// Define a draggable line
Point2D endPt = MousePosition();
Line line = LineFrom(startPt, endPt);

while (!QuitRequested())
{
    ProcessEvents();

    // Update draggable line
    endPt = MousePosition();
    line = LineFrom(startPt, endPt);

    // Draw the line and rectangle
    ClearScreen();
    DrawLine(ColorBlack(), line);
    DrawCircle(ColorBlack(), CircleAt(startPt, 5));
    DrawCircle(ColorBlack(), CircleAt(endPt, 5));
    DrawRectangle(ColorBlack(), rectangle);

    // Check for intersection and display results
    if (LineIntersectsRect(line, rectangle))
    {
        DrawText("Line and Rectangle intersect", ColorRed(), 250, 100);
    }
    else
    {
        DrawText("Line and Rectangle do not intersect", ColorGreen(), 250, 100);
    }
    RefreshScreen();
}

CloseAllWindows();