using SplashKitSDK;

namespace DrawEllipseExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Draw Ellipse", 800, 600);

            SplashKit.ClearScreen(Color.White);
            // Draw 30 ellipses
            for (int i = 0; i < 30; i++)
            {
                int width = 600 - i * 20;   // Decrease width by 20 every loop
                int height = 400 - i * 10;  // Decrease height by 10 every loop
                int x = 100 + i * 10;       // Increase x position by 10 every loop
                int y = 100 + i * 5;        // Increase y position by 5 every loop

                // Draw ellipse based on the given data
                SplashKit.DrawEllipse(Color.RandomRGB(255), x, y, width, height);
            }
            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}