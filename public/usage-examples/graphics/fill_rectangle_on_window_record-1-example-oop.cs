using SplashKitSDK;

namespace FillRectangleOnWindowExample
{
    public class Program
    {
        public static void Main()
        {
            Window blueWindow = SplashKit.OpenWindow("Blue Rectangle", 200, 200);
            Window redWindow = SplashKit.OpenWindow("Red Rectangle", 200, 200);
            redWindow.MoveTo(blueWindow.X + blueWindow.Width, blueWindow.Y);

            // Define the rectangles to draw
            Rectangle blueRect = SplashKit.RectangleFrom(50, 50, 100, 50); // x, y, width, height
            Rectangle redRect = SplashKit.RectangleFrom(50, 50, 100, 50); // x, y, width, height

            // Fill a blue rectangle on the first window
            blueWindow.Clear(Color.White);
            SplashKit.FillRectangleOnWindow(blueWindow, Color.Blue, blueRect);
            blueWindow.Refresh();

            // Fill a red rectangle on the second window
            redWindow.Clear(Color.White);
            SplashKit.FillRectangleOnWindow(redWindow, Color.Red, redRect);
            redWindow.Refresh();

            SplashKit.Delay(5000);

            SplashKit.CloseWindow(blueWindow);
            SplashKit.CloseWindow(redWindow);
        }
    }
}