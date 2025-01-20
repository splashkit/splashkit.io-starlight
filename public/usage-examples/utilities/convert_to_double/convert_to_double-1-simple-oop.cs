using SplashKitSDK;

namespace ConvertToDoubleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Welcome to the Simple Interest Calculator!");

            // Get principal amount from the user
            SplashKit.WriteLine("Please enter the principal amount (in dollars):");
            string principalInput = SplashKit.ReadLine();

            // Get the interest rate from the user
            SplashKit.WriteLine("Please enter the interest rate (as a percentage, e.g., 5 for 5%):");
            string rateInput = SplashKit.ReadLine();

            // Get the time period from the user
            SplashKit.WriteLine("Please enter the time period (in years):");
            string timeInput = SplashKit.ReadLine();

            // Convert inputs to double
            double principal = SplashKit.ConvertToDouble(principalInput);
            double rate = SplashKit.ConvertToDouble(rateInput);
            double time = SplashKit.ConvertToDouble(timeInput);

            // Calculate simple interest: Interest = Principal * Rate * Time / 100
            double interest = (principal * rate * time) / 100;

            // Output the result
            SplashKit.WriteLine("Calculating interest...");
            SplashKit.Delay(1000);

            SplashKit.WriteLine($"For a principal of ${principal} at an interest rate of {rate}% over {time} years:");
            SplashKit.WriteLine($"The simple interest is: ${interest}");
        }
    }
}