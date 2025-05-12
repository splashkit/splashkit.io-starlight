using SplashKitSDK;

namespace Countdown
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Countdown:");
            for (int i = 10; i >= 0; i--)  // Countdown from 10 to 0
            {
                SplashKit.Write("T-minus ");
                SplashKit.Write(i);  // Writing an integer
                SplashKit.WriteLine(" seconds...");
            }
            SplashKit.WriteLine("Lift off!");
        }
    }
}