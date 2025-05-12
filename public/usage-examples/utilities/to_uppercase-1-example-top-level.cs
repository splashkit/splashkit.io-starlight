using static SplashKitSDK.SplashKit;

Write("What is your favourite colour: ");
string input = ReadLine();

// Convert input to uppercase for comparison
if (ToUppercase(input) == "PURPLE")
{
    WriteLine("WOO HOO Purple club!");
}
else
{
    WriteLine("Great colour!");
}
WriteLine("---");