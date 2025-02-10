using SplashKitSDK;

namespace FillRectangleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Fill rectangle", 800, 600);

            SplashKit.ClearScreen();
            SplashKit.FillRectangle(Color.Blue, 200, 200, 200, 100);
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}