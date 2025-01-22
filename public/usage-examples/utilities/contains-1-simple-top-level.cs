using static SplashKitSDK.SplashKit;

string text = "Hello World, hello world";
string subtext = "World";

WriteLine("Text: " + text);
WriteLine("Subtext: " + subtext);

// Check if "Hello World" contains "World"
if (Contains(text, subtext))
{
    WriteLine("Text contains 'World'.");
}
else
{
    WriteLine("Text does not contain 'World'.");
}