using SplashKitSDK;

namespace LineToStringExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Line To String", 800, 600);

            // Define points for the line
            Point2D startPoint = new Point2D() { X = 100, Y = 150 };
            Point2D endPoint = new Point2D() { X = 500, Y = 550 };

            // Create a line from start and end points
            Line demoLine = SplashKit.LineFrom(startPoint, endPoint);
            SplashKit.DrawLine(Color.Red, demoLine);

            // Find the text description of the line
            string desc = SplashKit.LineToString(demoLine);
            SplashKit.DrawText(desc, Color.Black, 110, 130);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}