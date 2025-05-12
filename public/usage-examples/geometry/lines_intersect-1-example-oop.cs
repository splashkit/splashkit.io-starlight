using SplashKitSDK;

namespace LinesIntersectExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Lines Intersect", 800, 600);

            // Define points for the lines
            Point2D startPointA = new Point2D() { X = 100, Y = 150 };
            Point2D endPointA = new Point2D() { X = 500, Y = 550 };

            Point2D startPointB = new Point2D() { X = 100, Y = 550 };
            Point2D endPointB = new Point2D() { X = 500, Y = 150 };

            Point2D startPointC = new Point2D() { X = 550, Y = 150 };
            Point2D endPointC = new Point2D() { X = 550, Y = 500 };

            // Draw the lines
            Line demoLineA = SplashKit.LineFrom(startPointA, endPointA);
            SplashKit.DrawLine(Color.Red, demoLineA);
            SplashKit.DrawText("A", Color.Black, startPointA.X - 20, startPointA.Y - 10);

            Line demoLineB = SplashKit.LineFrom(startPointB, endPointB);
            SplashKit.DrawLine(Color.Blue, demoLineB);
            SplashKit.DrawText("B", Color.Black, startPointB.X - 20, startPointB.Y - 10);

            Line demoLineC = SplashKit.LineFrom(startPointC, endPointC);
            SplashKit.DrawLine(Color.Green, demoLineC);
            SplashKit.DrawText("C", Color.Black, startPointC.X - 20, startPointC.Y - 10);

            // Check intersections
            if (SplashKit.LinesIntersect(demoLineA, demoLineB))
            {
                SplashKit.DrawText("A and B intersect: Yes", Color.Black, 150, 130);
            }
            else
            {
                SplashKit.DrawText("A and B intersect: No", Color.Black, 150, 130);
            }

            if (SplashKit.LinesIntersect(demoLineA, demoLineC))
            {
                SplashKit.DrawText("A and C intersect: Yes", Color.Black, 150, 150);
            }
            else
            {
                SplashKit.DrawText("A and C intersect: No", Color.Black, 150, 150);
            }

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}