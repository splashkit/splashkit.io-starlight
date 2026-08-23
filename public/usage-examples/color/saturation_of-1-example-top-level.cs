using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Saturation Of", 800, 600);

Color color = RandomRGBColor(255);
// Function used here ↓
double colorSaturation = Math.Round(SaturationOf(color), 6);
Rectangle rectangle = RectangleFrom(200, 100, 400, 300);

ClearScreen(ColorWhite());
FillRectangle(color, rectangle);
DrawText("This color's saturation is " + colorSaturation.ToString(), ColorBlack(), 235, 450);
DrawText("It's RGBA values are: R-" + RedOf(color) + ", G-" + GreenOf(color) + ", B-" + BlueOf(color) + ", A-" + AlphaOf(color), ColorBlack(), 235, 470);
RefreshScreen();

Delay(5000);

CloseAllWindows();