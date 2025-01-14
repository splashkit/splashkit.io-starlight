using SplashKitSDK;

namespace CloverDrawing
{
    public class CloverDrawing
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Clover Drawing with Fill Ellipse", 1000, 600);

            SplashKit.ClearScreen();
            SplashKit.FillEllipse(Color.Green, 150, 225, 400, 200);
            SplashKit.FillEllipse(Color.Green, 375, 0, 200, 400);
            SplashKit.FillEllipse(Color.Green, 400, 225, 400, 200);
            SplashKit.FillRectangle(Color.Brown, 470, 400, 10, 150);
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}
