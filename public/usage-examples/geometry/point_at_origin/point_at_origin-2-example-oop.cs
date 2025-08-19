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

            // Create "sun" at the origin point
            SplashKit.ClearScreen();
            for (int i = 200; i > 10; i--)
            {
                SplashKit.FillCircle(SplashKit.RGBColor(255, i + 50, i % 30), point.X, point.Y, i);
            }
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}