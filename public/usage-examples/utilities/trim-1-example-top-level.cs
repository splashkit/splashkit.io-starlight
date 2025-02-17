using static SplashKitSDK.SplashKit;

string text = "   Whitespace is sneaky!   ";

WriteLine("Original string with sneaky spaces: '" + text + "'");
WriteLine("Let's get rid of those pesky spaces...");

// Trim spaces from the start and end
string trimmed = Trim(text);

WriteLine("Trimmed string: '" + trimmed + "'");
WriteLine("Aha! Much better without those sneaky spaces!");
