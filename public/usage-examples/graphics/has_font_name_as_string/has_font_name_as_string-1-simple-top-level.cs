using static SplashKitSDK.SplashKit;
 
// Load a font
LoadFont("my_font", "arial.ttf");

// Display the result
if (HasFont("my_font"))
{
    WriteLine("Font found!");
}
else
{
    WriteLine("Font not found!");
}