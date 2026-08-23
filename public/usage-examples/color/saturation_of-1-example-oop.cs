using SplashKitSDK;

namespace SaturationOfExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Saturation Of", 800, 600);

            Color color = SplashKit.RandomRGBColor(255);
            // Function used here ↓
            double colorSaturation = Math.Round(SplashKit.SaturationOf(color), 6);
            Rectangle rectangle = SplashKit.RectangleFrom(200, 100, 400, 300);

            SplashKit.ClearScreen(Color.White);
            SplashKit.FillRectangle(color, rectangle);
            SplashKit.DrawText("This color's saturation is " + colorSaturation.ToString(), Color.Black, 235, 450);
            SplashKit.DrawText("It's RGBA values are: R-" + SplashKit.RedOf(color) + ", G-" + SplashKit.GreenOf(color) + ", B-" + SplashKit.BlueOf(color) + ", A-" + SplashKit.AlphaOf(color), Color.Black, 235, 470);
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}