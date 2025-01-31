using SplashKitSDK;

namespace LineMidPointExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Line Mid Point", 800, 600);

            // Define points for the line
            Point2D startPoint = new Point2D() { X = 100, Y = 150 };
            Point2D endPoint = new Point2D() { X = 500, Y = 550 };

            // Create a line from start and end points
            Line demoLine = SplashKit.LineFrom(startPoint, endPoint);
            SplashKit.DrawLine(Color.Red, demoLine);

            // Find the mid point and mark it
            Point2D midPoint = SplashKit.LineMidPoint(demoLine);
            SplashKit.DrawCircle(Color.Black, midPoint.X, midPoint.Y, 2);

            // Display the midpoint coordinates
            SplashKit.DrawText("Midpoint Coordinates: " + midPoint.X.ToString() + ", " + midPoint.Y.ToString(), SplashKit.Color.Black, midPoint.X + 10, midPoint.Y - 10);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}