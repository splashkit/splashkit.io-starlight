using SplashKitSDK;

namespace RndExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Let's simulate a Coin Flip!");
            SplashKit.WriteLine("");
            SplashKit.WriteLine("Flipping coin ...");
            SplashKit.Delay(1500);
            SplashKit.WriteLine("");

            float random = 0.5F;

            // Add extra "randomness"
            for (int i = 0; i < 100; i++)
            {
                random = SplashKit.Rnd();
            }

            // 50% chance of heads or tails
            if (random < 0.5)
            {
                SplashKit.WriteLine("Heads!");
            }
            else
            {
                SplashKit.WriteLine("Tails!");
            }
            SplashKit.WriteLine("");
        }
    }
}