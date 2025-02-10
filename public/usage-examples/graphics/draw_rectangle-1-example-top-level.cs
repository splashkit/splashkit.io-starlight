using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Draw Rectangle", 800, 600);
ClearScreen(ColorWhite());

for (int i = 0; i < 21; i++)
{
    int x = i * 40 - 40;
    int y = 600 - i * 30;

    // Draw rectangle using x and y above with width 40 and height 30
    DrawRectangle(RandomRGBColor(255), x, y, 40, 30);
}

RefreshScreen();
Delay(4000);
CloseAllWindows();