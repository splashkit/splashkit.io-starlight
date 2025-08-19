using SplashKitSDK;

namespace ToUppercaseExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.Write("What is your favourite colour: ");
            string input = SplashKit.ReadLine();

            // Convert input to uppercase for comparison
            if (SplashKit.ToUppercase(input) == "PURPLE")
            {
                SplashKit.WriteLine("WOO HOO Purple club!");
            }
            else
            {
                SplashKit.WriteLine("Great colour!");
            }
            SplashKit.WriteLine("---");
        }
    }
}