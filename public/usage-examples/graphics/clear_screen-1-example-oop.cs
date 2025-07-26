using SplashKitSDK;

namespace ClearScreenExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Blue Background", 800, 600);

            //Use Clear Screen to change the background color to blue
            SplashKit.ClearScreen(Color.Blue);

            SplashKit.RefreshScreen(60);
            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}