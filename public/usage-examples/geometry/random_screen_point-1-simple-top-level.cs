using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create Window
OpenWindow("Night Sky", 600, 600);

ClearScreen(ColorBlack());
for (int i = 0; i < 1000; i++)
{
    // Set random pixel location on screen
    Point2D pixel = RandomScreenPoint();

    // Draw the pixel
    DrawPixel(RandomRGBColor(255), pixel);
}
RefreshScreen();

Delay(5000);
CloseAllWindows();