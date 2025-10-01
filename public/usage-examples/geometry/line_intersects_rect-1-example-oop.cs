using SplashKitSDK;

namespace LineIntersectsRectExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Avoid the Rectangle", 800, 600);

            // Define line's start point and a static rectangle
            Point2D startPt = SplashKit.PointAt(150, 100);
            Rectangle rectangle = SplashKit.RectangleFrom(250, 200, 300, 200);

            // Define a draggable line
            Point2D endPt = SplashKit.MousePosition();
            Line line = SplashKit.LineFrom(startPt, endPt);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Update draggable line
                endPt = SplashKit.MousePosition();
                line = SplashKit.LineFrom(startPt, endPt);

                // Draw the line and rectangle
                SplashKit.ClearScreen();
                SplashKit.DrawLine(Color.Black, line);
                SplashKit.DrawCircle(Color.Black, SplashKit.CircleAt(startPt, 5));
                SplashKit.DrawCircle(Color.Black, SplashKit.CircleAt(endPt, 5));
                SplashKit.DrawRectangle(Color.Black, rectangle);

                // Check for intersection and display results
                if (SplashKit.LineIntersectsRect(line, rectangle))
                {
                    SplashKit.DrawText("Line and Rectangle intersect", Color.Red, 250, 100);
                }
                else
                {
                    SplashKit.DrawText("Line and Rectangle do not intersect", Color.Green, 250, 100);
                }
                SplashKit.RefreshScreen();
            }

            SplashKit.CloseAllWindows();
        }
    }
}