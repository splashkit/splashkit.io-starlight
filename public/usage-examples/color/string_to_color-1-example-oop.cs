using SplashKitSDK;

namespace StringToColorExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("String To Color", 800, 600);

            // Change this string to get different colors 
            string colorHex = "#921e64d9";
            Color color = SplashKit.StringToColor(colorHex);
            Rectangle rectangle = SplashKit.RectangleFrom(200, 100, 400, 300);

            SplashKit.ClearScreen(Color.White);
            SplashKit.FillRectangle(color, rectangle);
            SplashKit.DrawText("Current color's RGBA hex value is " + colorHex, Color.Black, 235, 450);
            SplashKit.DrawText("It's RGB values are: R-" + SplashKit.RedOf(color) + ", G-" + SplashKit.GreenOf(color) + ", B-" + SplashKit.BlueOf(color), Color.Black, 235, 470);
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}