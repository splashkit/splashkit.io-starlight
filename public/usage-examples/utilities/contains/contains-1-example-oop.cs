using SplashKitSDK;

namespace ContainsExample
{
    public class Program
    {
        public static void Main()
        {
            string text = "Hello World, hello world";
            string subtext = "World";

            SplashKit.WriteLine("Text: " + text);
            SplashKit.WriteLine("Subtext: " + subtext);

           // Check if "Hello World" contains "World"
            if (SplashKit.Contains(text, subtext))
            {
                SplashKit.WriteLine("Text contains 'World'.");
            }
            else
            {
                SplashKit.WriteLine("Text does not contain 'World'.");
            }
        }
    }
}