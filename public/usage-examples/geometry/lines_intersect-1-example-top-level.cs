using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Lines Intersect", 800, 600);

// Define points for the lines
Point2D startPointA = new Point2D() { X = 100, Y = 150 };
Point2D endPointA = new Point2D() { X = 500, Y = 550 };

Point2D startPointB = new Point2D() { X = 100, Y = 550 };
Point2D endPointB = new Point2D() { X = 500, Y = 150 };

Point2D startPointC = new Point2D() { X = 550, Y = 150 };
Point2D endPointC = new Point2D() { X = 550, Y = 500 };

// Draw the lines
Line demoLineA = LineFrom(startPointA, endPointA);
DrawLine(ColorRed(), demoLineA);
DrawText("A", ColorBlack(), startPointA.X - 20, startPointA.Y - 10);

Line demoLineB = LineFrom(startPointB, endPointB);
DrawLine(ColorBlue(), demoLineB);
DrawText("B", ColorBlack(), startPointB.X - 20, startPointB.Y - 10);

Line demoLineC = LineFrom(startPointC, endPointC);
DrawLine(ColorGreen(), demoLineC);
DrawText("C", ColorBlack(), startPointC.X - 20, startPointC.Y - 10);

// Check intersections
if (LinesIntersect(demoLineA, demoLineB))
{
    DrawText("A and B intersect: Yes", ColorBlack(), 150, 130);
}
else
{
    DrawText("A and B intersect: No", ColorBlack(), 150, 130);
}

if (LinesIntersect(demoLineA, demoLineC))
{
    DrawText("A and C intersect: Yes", ColorBlack(), 150, 150);
}
else
{
    DrawText("A and C intersect: No", ColorBlack(), 150, 150);
}

RefreshScreen();
Delay(5000);

CloseAllWindows();