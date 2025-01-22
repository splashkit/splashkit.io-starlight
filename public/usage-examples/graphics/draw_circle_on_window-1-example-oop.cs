using SplashKitSDK;

namespace DrawCircleOnWindowExample
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Bubbles", 800, 600);

            window.Clear(Color.White);
            for (int i = 0; i < 50; i++)
            {
                // Set random circle values
                double x = SplashKit.Rnd(800);
                double y = SplashKit.Rnd(600);
                double radius = SplashKit.Rnd(50);
                Color randomColor = SplashKit.RGBColor(SplashKit.Rnd(255), SplashKit.Rnd(255), SplashKit.Rnd(255));

                // Draw the circle base on the random data
                SplashKit.DrawCircleOnWindow(window, randomColor, x, y, radius);
            }
            window.Refresh();

            SplashKit.Delay(4000);
            window.Close();
        }
    }
}