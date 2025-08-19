using SplashKitSDK;

namespace FillCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Fill Circle", 800, 600);

            SplashKit.ClearScreen();
            SplashKit.FillCircle(Color.Blue, 300, 300, 200);
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}
