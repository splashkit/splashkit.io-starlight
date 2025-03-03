using SplashKitSDK;

namespace RndExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Let's make this more interesting!");

            int minValue = 1;
            int maxValue = 0;

            // Loop until a valid range is provided
            while (minValue >= maxValue)
            {
                // Get user input for the range
                SplashKit.WriteLine("Please enter the minimum number:");
                minValue = Convert.ToInt32(SplashKit.ReadLine());

                SplashKit.WriteLine("Please enter the maximum number:");
                maxValue = Convert.ToInt32(SplashKit.ReadLine());

                // Check if min is smaller than max
                if (minValue >= maxValue)
                {
                    SplashKit.WriteLine("Oops! The minimum value should be less than the maximum value. Let's re-enter both values.");
                }
            }

            SplashKit.WriteLine($"Get ready to generate a random number between {minValue} and {maxValue}...");
            SplashKit.WriteLine("Drum roll please...");

            // Generate a random number in the specified range
            int randomNumber = SplashKit.Rnd(minValue, maxValue);

            SplashKit.WriteLine($"Your lucky number is: {randomNumber}!");
            SplashKit.WriteLine("How does it feel? Want to try again?");
        }
    }
}