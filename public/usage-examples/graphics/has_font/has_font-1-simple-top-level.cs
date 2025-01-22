using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Check if program has font
Write("Font available before loading: ");
if (HasFont(FontNamed("MyFont")))
    WriteLine("True");
else
    WriteLine("False");

// Load font
Font myFont = LoadFont("MyFont", "arial.ttf");

// Check if program has font again
Write("Font available after loading: ");
if (HasFont(myFont))
    WriteLine("True");
else
    WriteLine("False");
