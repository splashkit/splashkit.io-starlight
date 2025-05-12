using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Load font
Font myFont = LoadFont("MyFont", "RobotoSlab.ttf");

OpenWindow("Font Load Example", 800, 600);

// Draw text using loaded font
DrawText("Hello, SplashKit!", ColorBlack(), myFont, 40, 250, 270);
RefreshScreen();

Delay(5000);
CloseAllWindows();