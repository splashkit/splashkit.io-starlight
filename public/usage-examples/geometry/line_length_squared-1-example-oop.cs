using SplashKitSDK;

namespace LineLengthSquaredExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Line Length Squared", 800, 600);

            // Define points for the line
            Point2D startPoint = new Point2D() { X = 100, Y = 150 };
            Point2D endPoint = new Point2D() { X = 500, Y = 550 };

            // Create a line from start and end points
            Line demoLine = SplashKit.LineFrom(startPoint, endPoint);
            SplashKit.DrawLine(Color.Red, demoLine);

            // Calculate the squared length and draw to window
            float length = SplashKit.LineLengthSquared(demoLine);
            SplashKit.DrawText("Line length squared: " + length.ToString(), Color.Black, 110, 130);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}