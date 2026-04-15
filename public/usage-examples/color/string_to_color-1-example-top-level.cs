using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("String To Color", 800, 600);

// Change this string to get different colors 
string colorHex = "#921e64d9";
Color color = StringToColor(colorHex);
Rectangle rectangle = RectangleFrom(200, 100, 400, 300);

ClearScreen(ColorWhite());
FillRectangle(color, rectangle);
DrawText("Current color's RGBA hex value is " + colorHex, ColorBlack(), 235, 450);
DrawText("It's RGB values are: R-" + RedOf(color) + ", G-" + GreenOf(color) + ", B-" + BlueOf(color), ColorBlack(), 235, 470);
RefreshScreen();

Delay(5000);

CloseAllWindows();