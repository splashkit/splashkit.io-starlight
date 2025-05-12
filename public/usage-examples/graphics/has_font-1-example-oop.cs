using SplashKitSDK;

namespace HasFontExample
{
    public class Program
    {
        public static void Main()
        {
            // Check if program has font
            SplashKit.Write("Font available before loading: ");
            if (SplashKit.HasFont(SplashKit.FontNamed("MyFont")))
                SplashKit.WriteLine("True");
            else
                SplashKit.WriteLine("False");

            // Load font
            Font myFont = SplashKit.LoadFont("MyFont", "arial.ttf");

            // Check if program has font again
            SplashKit.Write("Font available after loading: ");
            if (SplashKit.HasFont(myFont))
                SplashKit.WriteLine("True");
            else
                SplashKit.WriteLine("False");
        }
    }
}