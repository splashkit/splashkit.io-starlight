using SplashKitSDK;

namespace WriteLineEmptyExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Header Text");
            SplashKit.WriteLine(); // Add a blank line
            SplashKit.WriteLine("Body Content:");
            SplashKit.WriteLine("This is the first line of body content.");
            SplashKit.WriteLine(); // Add another blank line
            SplashKit.WriteLine("This is the second line of body content.");
            SplashKit.WriteLine(); // Add more spacing
            SplashKit.WriteLine("Footer Text");
        }
    }
}