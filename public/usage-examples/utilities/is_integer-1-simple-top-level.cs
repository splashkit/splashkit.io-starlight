using static SplashKitSDK.SplashKit;

WriteLine("Welcome to the Integer Validation Checker!");

// Get the user input as a string
WriteLine("Please enter a valid integer:");
string input = ReadLine();

// Check if the input is a valid integer
// Loop while the user input is NOT valid (aka check for the wrong answers here)
while (!IsInteger(input))
{
    WriteLine("Oops! That's not a valid integer. Please try again.");
    // Allow the user to enter their input again
    WriteLine("Please enter a valid integer:");
    input = ReadLine();
}

// Convert input to integer
int number = ConvertToInteger(input);
WriteLine($"Great! You've entered a valid integer: {number}");

WriteLine("Thank you for using the Integer Validation Checker!");
