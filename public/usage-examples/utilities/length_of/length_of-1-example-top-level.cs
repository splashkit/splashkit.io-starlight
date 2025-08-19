using static SplashKitSDK.SplashKit;

// Array of strings to analyse
string[] texts = { "SplashKit", "Hello", "12345", "A quick brown fox leaps high", "3.141592653589793", "hi", "" };

// Loop through each string and print its length
foreach (string text in texts)
{
    int length = LengthOf(text);  // Get the length of the string
    WriteLine($"The length of '{text}' is: {length} characters.");
}