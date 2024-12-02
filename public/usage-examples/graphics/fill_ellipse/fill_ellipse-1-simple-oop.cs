using SplashKitSDK;

namespace FillEllipseExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Fill Ellipse", 800, 600);

            SplashKit.ClearScreen();
            SplashKit.FillEllipse(Color.Blue, 200, 200, 400, 200);
            // Added a rectangle with the same arguments as above for x, y, width, and height 
            SplashKit.DrawRectangle(Color.Red, 200, 200, 400, 200);
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}
