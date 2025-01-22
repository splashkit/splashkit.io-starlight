using SplashKitSDK;

namespace RefreshScreen
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("House Drawing", 800, 600);

            SplashKit.ClearScreen(Color.White);
            SplashKit.RefreshScreen();
            SplashKit.Delay(1000);

            SplashKit.FillEllipse(Color.BrightGreen, 0, 400, 800, 400);
            SplashKit.RefreshScreen();
            SplashKit.Delay(1000);

            SplashKit.FillRectangle(Color.Gray, 300, 300, 200, 200);
            SplashKit.RefreshScreen();
            SplashKit.Delay(1000);

            SplashKit.FillTriangle(Color.Red, 250, 300, 400, 150, 550, 300);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}