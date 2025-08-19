using SplashKitSDK;

namespace DrawPixelExample
{
    public class Program
    {
        public static void Main()
        {
            // Declare variables
            const int TrailLength = 50;
            Point2D mousePoint;
            Point2D[] mouseHistory = new Point2D[TrailLength];
            Color[] colorList = { Color.Blue, Color.Red, Color.Green, Color.Yellow, Color.Pink };

            Window window = new Window("Cursor Trail", 600, 600);

            while (!SplashKit.QuitRequested())
            {
                mousePoint = SplashKit.MousePosition();
                window.Clear(Color.Black);
                // Set mouse position history
                for (int i = 0; i < TrailLength - 1; i++)
                {
                    // Shuffle forward
                    mouseHistory[i] = mouseHistory[i + 1];
                }

                mouseHistory[TrailLength - 1] = mousePoint;

                // Draw mouse trail
                for (int i = 0; i < TrailLength; i++)
                {
                    SplashKit.DrawPixel(colorList[i % 5], mouseHistory[i]);
                }

                SplashKit.ProcessEvents();
                window.Refresh(60);
            }
            window.Close();
        }
    }
}