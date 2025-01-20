using static SplashKitSDK.SplashKit;

WriteLine("Welcome to the Number Guessing Game!");
WriteLine("I'm thinking of a number between 1 and 100...");

string input; // User input
int secretNumber = 42; // Set a secret number
int guess = -1;  // Initialise with an invalid guess

while (guess != secretNumber)
{
    // Ask the user for their guess
    WriteLine("Please enter your guess:");
    input = ReadLine();

    // Validate if the input is a valid integer
    if (IsInteger(input))
    {
        // Convert input string to integer
        guess = ConvertToInteger(input);

        // Check if the guess is correct
        if (guess > secretNumber)
        {
            WriteLine("Too high! Try again.");
        }
        else if (guess < secretNumber)
        {
            WriteLine("Too low! Try again.");
        }
    }
    else
    {
        WriteLine("That's not a valid integer! Please enter a number.");
    }
}

WriteLine($"Congratulations! You've guessed the correct number: {guess}");