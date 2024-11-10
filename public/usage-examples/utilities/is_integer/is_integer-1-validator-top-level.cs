using SplashKitSDK;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Welcome to the Integer Validation Checker!");

            bool validInput = false;

            // Loop until the user enters a valid integer
            while (!validInput)
            {
                SplashKit.WriteLine("Please enter a valid integer:");
                string input = SplashKit.ReadLine();

                // Check if the input is a valid integer
                if (SplashKit.IsInteger(input))
                {
                    int number = SplashKit.ConvertToInteger(input);  // Convert input to integer
                    SplashKit.WriteLine($"Great! You've entered a valid integer: {number}");
                    validInput = true;  // Exit loop on valid input
                }
                else
                {
                    SplashKit.WriteLine("Oops! That's not a valid integer. Please try again.");
                }
            }

            SplashKit.WriteLine("Thank you for using the Integer Validation Checker!");

        }
    }
}