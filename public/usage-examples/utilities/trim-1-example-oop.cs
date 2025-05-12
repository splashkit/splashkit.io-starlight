using SplashKitSDK;

namespace TrimExample
{
    public class Program
    {
        public static void Main()
        {
            string text = "   Whitespace is sneaky!   ";

            SplashKit.WriteLine("Original string with sneaky spaces: '" + text + "'");
            SplashKit.WriteLine("Let's get rid of those pesky spaces...");

            // Trim spaces from the start and end
            string trimmed = SplashKit.Trim(text);

            SplashKit.WriteLine("Trimmed string: '" + trimmed + "'");
            SplashKit.WriteLine("Aha! Much better without those sneaky spaces!");
        }
    }
}
