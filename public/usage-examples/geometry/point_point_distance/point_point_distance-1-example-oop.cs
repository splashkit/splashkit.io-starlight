using SplashKitSDK;

namespace PointPointDistance
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Distance From Center", 600, 600);

            // Define the variables
            Point2D center_pt = SplashKit.ScreenCenter();
            Point2D mouse_pt;
            float pt_pt_distance;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Get "current" Mouse Position
                mouse_pt = SplashKit.MousePosition();

                // Calculate the distance between the center point and the current mouse position
                pt_pt_distance = SplashKit.PointPointDistance(center_pt, mouse_pt);

                // Draw line and distance between center of window (filled circle) and mouse point
                SplashKit.ClearScreen();
                SplashKit.FillCircle(Color.Red, center_pt.X, center_pt.Y, 5);
                SplashKit.DrawLine(Color.Blue, center_pt, mouse_pt);
                SplashKit.DrawText(pt_pt_distance.ToString(), Color.Black, mouse_pt.X + 10, mouse_pt.Y - 10);
                SplashKit.RefreshScreen();
            }

            // Close all opened windows
            SplashKit.CloseAllWindows();
        }
    }
}