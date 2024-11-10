using static SplashKitSDK.SplashKit;

WriteLine("Welcome to the Integer Validation Checker!");

bool validInput = false;

// Loop until the user enters a valid integer
while (!validInput)
{
    WriteLine("Please enter a valid integer:");
    string input = ReadLine();

    // Check if the input is a valid integer
    if (IsInteger(input))
    {
        int number = ConvertToInteger(input);  // Convert input to integer
        WriteLine($"Great! You've entered a valid integer: {number}");
        validInput = true;  // Exit loop on valid input
    }
    else
    {
        WriteLine("Oops! That's not a valid integer. Please try again.");
    }
}

WriteLine("Thank you for using the Integer Validation Checker!");
