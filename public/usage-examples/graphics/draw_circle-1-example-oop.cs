using SplashKitSDK;

namespace DrawCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Draw Circle Example", 800, 600);

            SplashKit.ClearScreen(Color.White);
            
            // Draw a large red filled circle in the center
            SplashKit.FillCircle(Color.Red, 400, 300, 100);
            
            // Draw circles with different colors, sizes, and positions
            SplashKit.DrawCircle(Color.Blue, 200, 150, 80);
            SplashKit.DrawCircle(Color.Green, 600, 150, 60);
            SplashKit.DrawCircle(Color.Orange, 200, 450, 70);
            SplashKit.DrawCircle(Color.Purple, 600, 450, 65);
            
            // Draw smaller circles with varying colors
            for (int i = 0; i < 8; i++)
            {
                int radius = 20 + i * 5;
                int x = 400 + (i - 4) * 80;
                int y = 100;
                SplashKit.DrawCircle(Color.RandomRGB(255), x, y, radius);
            }
            
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}
