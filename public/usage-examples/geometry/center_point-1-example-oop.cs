using SplashKitSDK;

namespace CenterPointExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Glowing Blue Circle", 600, 600);

            int outer_circle_radius = 255;

            // Create a circle in center of window
            Circle outer_circle = SplashKit.CircleAt(SplashKit.ScreenCenter(), outer_circle_radius);

            // Get center point of circle
            Point2D circle_centre = SplashKit.CenterPoint(outer_circle);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Draw glowing circle
                SplashKit.ClearScreen(Color.Black);
                for (int i = outer_circle_radius; i > 5; i--)
                {
                    SplashKit.FillCircle(Color.RGBColor(0, 0, 255 - i), SplashKit.CircleAt(circle_centre, i));
                }
                SplashKit.RefreshScreen();
            }
            SplashKit.CloseAllWindows();
        }
    }
}