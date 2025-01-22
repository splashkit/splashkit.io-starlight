using SplashKitSDK;
 
namespace HasFontExample
{
    public class Program
    {
        public static void Main()
        {
            // Load a font
            SplashKit.LoadFont("my_font", "arial.ttf");
 
            // Check if the font exists
            if (SplashKit.HasFont("my_font"))
            {
                SplashKit.WriteLine("Font found!");
            }
            else
            {
                SplashKit.WriteLine("Font not found!");
            }
        }
    }
}