using SplashKitSDK;

namespace IsIntegerExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Welcome to the Integer Validation Checker!");

            // Get the user input as a string
            SplashKit.WriteLine("Please enter a valid integer:");
            string input = SplashKit.ReadLine();

            // Check if the input is a valid integer
            // Loop while the user input is NOT valid (aka check for the wrong answers here)
            while (!SplashKit.IsInteger(input))
            {
                SplashKit.WriteLine("Oops! That's not a valid integer. Please try again.");
                // Allow the user to enter their input again
                SplashKit.WriteLine("Please enter a valid integer:");
                input = SplashKit.ReadLine();
            }

            // Convert input to integer
            int number = SplashKit.ConvertToInteger(input);
            SplashKit.WriteLine($"Great! You've entered a valid integer: {number}");

            SplashKit.WriteLine("Thank you for using the Integer Validation Checker!");
        }
    }
}