using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Line Mid Point", 800, 600);

// Define points for the line
Point2D startPoint = new Point2D() { X = 100, Y = 150 };
Point2D endPoint = new Point2D() { X = 500, Y = 550 };

// Create a line from start and end points
Line demoLine = LineFrom(startPoint, endPoint);
DrawLine(ColorRed(), demoLine);

// Find the mid point and mark it
Point2D midPoint = LineMidPoint(demoLine);
DrawCircle(ColorBlack(), midPoint.X, midPoint.Y, 2);

// Display the midpoint coordinates
DrawText("Midpoint Coordinates: " + midPoint.X.ToString() + ", " + midPoint.Y.ToString(), ColorBlack(), midPoint.X + 10, midPoint.Y - 10);

RefreshScreen();
Delay(5000);

CloseAllWindows();