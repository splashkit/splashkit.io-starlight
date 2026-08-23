using static SplashKitSDK.SplashKit;

OpenWindow("Draw Circle Example", 800, 600);

ClearScreen(ColorWhite());

// Draw a large red filled circle in the center
FillCircle(ColorRed(), 400, 300, 100);

// Draw circles with different colors, sizes, and positions
DrawCircle(ColorBlue(), 200, 150, 80);
DrawCircle(ColorGreen(), 600, 150, 60);
DrawCircle(ColorOrange(), 200, 450, 70);
DrawCircle(ColorPurple(), 600, 450, 65);

// Draw smaller circles with varying colors
for (int i = 0; i < 8; i++)
{
    int radius = 20 + i * 5;
    int x = 400 + (i - 4) * 80;
    int y = 100;
    DrawCircle(RandomRGBColor(255), x, y, radius);
}

RefreshScreen();

Delay(5000);
CloseAllWindows();
