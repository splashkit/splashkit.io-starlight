using SplashKitSDK;

namespace PointAtOriginExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Point At Origin", 800, 600);

            // Create a point at origin
            Point2D point = SplashKit.PointAtOrigin();

            // Create red circle at the origin point
            SplashKit.ClearScreen();
            SplashKit.FillCircle(Color.Red, point.X, point.Y, 4);
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}