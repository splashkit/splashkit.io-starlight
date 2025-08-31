using SplashKitSDK;
using static SplashKitSDK.SplashKit;

static Point2D GetPoint(string prompt)
{
    // Get user input
    Write(prompt);
    string guessInput = ReadLine();
    List<string> coords = Split(guessInput, ',');

    // Validate input
    while (!IsDouble(coords[0]) || !IsDouble(coords[1]))
    {
        WriteLine("Invalid input. Try again.");
        Write(prompt);
        guessInput = ReadLine();
        coords = Split(guessInput, ',');
    }

    // Convert input
    double guessX = ConvertToDouble(coords[0]);
    double guessY = ConvertToDouble(coords[1]);
    return PointAt(guessX, guessY);
}

// Variable Declarations
Point2D targetPoint = PointAt(50, 75);
Point2D guessPoint;

WriteLine("Guess the coordinate inside (100,100) ");

// Get user input
guessPoint = GetPoint("Enter your coordinates as x,y: ");

while (!SamePoint(targetPoint, guessPoint))
{
    // Clues
    if (targetPoint.X > guessPoint.X)
        WriteLine("x is too low");
    else if (targetPoint.X < guessPoint.X)
        WriteLine("x is too high");
    else
        WriteLine("x is correct !!!");

    if (targetPoint.Y > guessPoint.Y)
        WriteLine("y is too low");
    else if (targetPoint.Y < guessPoint.Y)
        WriteLine("y is too high");
    else
        WriteLine("y is correct !!!");

    WriteLine("Try Again!");
    guessPoint = GetPoint("Enter your coordinates as x,y: ");
}
WriteLine("You Win!");