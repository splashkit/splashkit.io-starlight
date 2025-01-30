using SplashKitSDK;

namespace ClosestPointOnCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Closest point", 600, 600);

            // Declare variables
            Point2D circle_pt = ScreenCenter();
            Circle circle = SplashKit.CircleAt(circle_pt, 100);
            Point2D mouse_pt = SplashKit.MousePosition();
            Point2D closest_point;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Get "current" Mouse Position
                mouse_pt = SplashKit.MousePosition();

                // Calculate the closest distance between the current mouse position and the circle
                closest_point = SplashKit.ClosestPointOnCircle(mouse_pt, circle);

                // Draw circle and indicated points
                SplashKit.ClearScreen();
                SplashKit.DrawCircle(Color.Black, circle);
                SplashKit.FillCircle(Color.Red, closest_point.X, closest_point.Y, 5);
                SplashKit.FillCircle(Color.Blue, mouse_pt.X, mouse_pt.Y, 5);
                SplashKit.RefreshScreen();
            }

            SplashKit.CloseAllWindows();
        }
    }
}