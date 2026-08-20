using SplashKitSDK;

namespace ToDoubleExample
{
    public class Program
    {
        public static void Main()
        {
            string userInput;
            double principal, rate, time, interest;

            SplashKit.WriteLine("Welcome to the Simple Interest Calculator!");

            // Get principal amount from the user (without input validation for simplicity)
            SplashKit.Write("Please enter the principal amount (in dollars): ");
            userInput = SplashKit.ReadLine();
            principal = SplashKit.ToDouble(userInput);

            // Get the interest rate from the user
            SplashKit.Write("Please enter the interest rate (as a percentage, e.g., 5 for 5%): ");
            userInput = SplashKit.ReadLine();
            rate = SplashKit.ToDouble(userInput);

            // Get the time period from the user
            SplashKit.Write("Please enter the time period (in years): ");
            userInput = SplashKit.ReadLine();
            time = SplashKit.ToDouble(userInput);

            // Calculate simple interest: Interest = Principal * Rate * Time / 100
            interest = (principal * rate * time) / 100;

            // Output the result
            SplashKit.WriteLine();
            SplashKit.WriteLine("Calculating interest...");
            SplashKit.WriteLine();
            SplashKit.Delay(1000);

            SplashKit.WriteLine("For a principal of $" + SplashKit.ToString(principal, 2) + " at an interest rate of " + SplashKit.ToString(rate, 2) + "% over " + SplashKit.ToString(time, 2) + " years:");
            SplashKit.WriteLine("\tThe simple interest is: $" + SplashKit.ToString(interest, 2));
        }
    }
}