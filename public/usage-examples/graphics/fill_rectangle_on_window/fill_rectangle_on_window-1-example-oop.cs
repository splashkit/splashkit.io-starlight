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

            // Fill a blue rectangle on the first window
            blueWindow.Clear(Color.White);
            SplashKit.FillRectangleOnWindow(blueWindow, Color.Blue, 50, 50, 100, 50);
            blueWindow.Refresh();

            // Fill a red rectangle on the second window
            redWindow.Clear(Color.White);
            SplashKit.FillRectangleOnWindow(redWindow, Color.Red, 50, 50, 100, 50);
            redWindow.Refresh();

            SplashKit.Delay(5000);

            SplashKit.CloseWindow(blueWindow);
            SplashKit.CloseWindow(redWindow);
        }
    }
}