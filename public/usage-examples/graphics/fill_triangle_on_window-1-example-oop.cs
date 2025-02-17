using SplashKitSDK;

namespace FillTriangleOnWindowExample
{
    public class Program
    {
        public static void Main()
        {

            Window blueWindow = SplashKit.OpenWindow("Blue Triangle", 200, 200);
            Window redWindow = SplashKit.OpenWindow("Red Triangle", 200, 200);
            redWindow.MoveTo(blueWindow.X + blueWindow.Width, blueWindow.Y);

            // Fill a blue triangle on the first window
            blueWindow.Clear(Color.White);
            SplashKit.FillTriangleOnWindow(blueWindow, Color.Blue, 50, 100, 100, 50, 150, 100);
            blueWindow.Refresh();

            // Fill a red triangle on the second window
            redWindow.Clear(Color.White);
            SplashKit.FillTriangleOnWindow(redWindow, Color.Red, 50, 50, 100, 100, 150, 50);
            redWindow.Refresh();

            SplashKit.Delay(10000);

            SplashKit.CloseWindow(blueWindow);
            SplashKit.CloseWindow(redWindow);
        }
    }
}