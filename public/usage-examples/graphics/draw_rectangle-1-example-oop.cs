using SplashKitSDK;

namespace DrawRectangleExample
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Draw Rectangle", 800, 600);
            window.Clear(Color.White);

            for (int i = 0; i < 21; i++)
            {
                int x = i * 40 - 40;
                int y = 600 - i * 30;

                // Draw rectangle using x and y above with width 40 and height 30
                SplashKit.DrawRectangle(SplashKit.RandomRGBColor(255), x, y, 40, 30);
            }

            window.Refresh();
            SplashKit.Delay(4000);
            window.Close();
        }
    }
}