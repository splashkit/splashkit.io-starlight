using SplashKitSDK;

namespace LoadFontExample
{
    public class Program
    {
        public static void Main()
        {
            // Load font
            Font myFont = SplashKit.LoadFont("MyFont", "RobotoSlab.ttf");

            SplashKit.OpenWindow("Font Load Example", 800, 600);

            // Draw text using loaded font
            SplashKit.DrawText("Hello, SplashKit!", SplashKit.ColorBlack(), myFont, 40, 250, 270);
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}