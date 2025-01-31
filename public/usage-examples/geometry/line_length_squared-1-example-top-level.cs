using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Line Length Squared", 800, 600);

// Define points for the line
Point2D startPoint = new Point2D() { X = 100, Y = 150 };
Point2D endPoint = new Point2D() { X = 500, Y = 550 };

// Create a line from start and end points
Line demoLine = LineFrom(startPoint, endPoint);
DrawLine(ColorRed(), demoLine);

// Calculate the squared length and draw to window
float length = LineLengthSquared(demoLine);
DrawText("Line length squared: " + length.ToString(), ColorBlack(), 110, 130);

RefreshScreen();
Delay(5000);

CloseAllWindows();