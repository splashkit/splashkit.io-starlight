using SplashKitSDK;

namespace RandomScreenPointExample
{
    public class Program
    {
        public static void Main()
        {
            // Create Window
            Window window = new Window("Night Sky", 600, 600);

            window.Clear(Color.Black);
            for (int i = 0; i < 1000; i++)
            {
                // Set random pixel location on screen
                Point2D pixel = SplashKit.RandomScreenPoint();

                // Draw the pixel
                SplashKit.DrawPixel(Color.RandomRGB(255), pixel);
            }
            window.Refresh();

            SplashKit.Delay(5000);
            window.Close();
        }
    }
}