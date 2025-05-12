using SplashKitSDK;

namespace RndExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Get ready to generate a random number up to 1000...");
            SplashKit.WriteLine("Drum roll please...");
            SplashKit.Delay(2000); // Delay for 2 seconds

            // Generate a random number up to the ubound
            int randomNumber = SplashKit.Rnd(1000);

            SplashKit.WriteLine($"Your lucky number is: {randomNumber}!!");
            SplashKit.WriteLine("Feeling lucky? Maybe it's time to play the lottery!");
        }
    }
}