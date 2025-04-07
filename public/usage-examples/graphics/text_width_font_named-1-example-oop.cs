using SplashKitSDK;

namespace TextWidthExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Text Width", 680, 200);
            SplashKit.ClearScreen(Color.White);

            SplashKit.LoadFont("LOTR", "lotr.ttf");
            SplashKit.SetFontStyle("LOTR", FontStyle.BoldFont);
            SplashKit.DrawText("Ringbearer", Color.Black, "LOTR", 100, 30, 20);

            //Getting the width of the text to fill a rectange of that width
            int width = SplashKit.TextWidth("Ringbearer", "LOTR", 100);
            SplashKit.FillRectangle(Color.Black, 30, 130, width, 10);
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}