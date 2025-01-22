using SplashKitSDK;

namespace FillTriangleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Fill Triangle Example", 800, 600);

            SplashKit.ClearScreen();
            SplashKit.FillTriangle(Color.Red, 100, 100, 200, 200, 300, 100);
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}