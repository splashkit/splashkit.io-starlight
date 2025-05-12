using SplashKitSDK;

namespace ConvertToIntegerExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Welcome to the Number Guessing Game!");
            SplashKit.WriteLine("I'm thinking of a number between 1 and 100...");

            string input; // User input
            int secretNumber = 42; // Set a secret number
            int guess = -1;  // Initialise with an invalid guess

            while (guess != secretNumber)
            {
                // Ask the user for their guess
                SplashKit.WriteLine("Please enter your guess:");
                input = SplashKit.ReadLine();

                // Validate if the input is a valid integer
                if (SplashKit.IsInteger(input))
                {
                    // Convert input string to integer
                    guess = SplashKit.ConvertToInteger(input);

                    // Check if the guess is correct
                    if (guess > secretNumber)
                    {
                        SplashKit.WriteLine("Too high! Try again.");
                    }
                    else if (guess < secretNumber)
                    {
                        SplashKit.WriteLine("Too low! Try again.");
                    }
                }
                else
                {
                    SplashKit.WriteLine("That's not a valid integer! Please enter a number.");
                }
            }

            SplashKit.WriteLine($"Congratulations! You've guessed the correct number: {guess}");
        }
    }
}