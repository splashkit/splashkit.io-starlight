using SplashKitSDK;

namespace GetFontStyleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Get Font Style", 800, 600);

            int style_number = -1;
            Font font = SplashKit.FontNamed("Century.ttf");

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                if (style_number < 3)
                {
                    style_number += 1;
                }
                else
                {
                    style_number = 0;
                }

                if (style_number == 0)
                {
                    SplashKit.SetFontStyle(font, FontStyle.NormalFont);
                }
                else if (style_number == 1)
                {
                    SplashKit.SetFontStyle(font, FontStyle.BoldFont);
                }
                else if (style_number == 2)
                {
                    SplashKit.SetFontStyle(font, FontStyle.ItalicFont);
                }
                else if (style_number == 3)
                {
                    SplashKit.SetFontStyle(font, FontStyle.UnderlineFont);
                }

                SplashKit.ClearScreen(Color.White);
                // Function is used here ↓
                SplashKit.DrawText("The assigned font style is currently set to " + SplashKit.GetFontStyle(font), Color.Black, 40, 60);
                SplashKit.DrawText("The quick brown fox jumps over the lazy dog", Color.Black, font, 30, 40, 110);
                SplashKit.RefreshScreen();

                SplashKit.Delay(2000);
            }
            SplashKit.CloseAllWindows();
        }
    }
}