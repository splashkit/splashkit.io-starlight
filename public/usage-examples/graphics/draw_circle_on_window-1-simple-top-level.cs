using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window window = OpenWindow("Bubbles", 800, 600);

ClearScreen(ColorWhite());
for (int i = 0; i < 50; i++)
{
    // Set random circle values
    double x = Rnd(800);
    double y = Rnd(600);
    double radius = Rnd(50);
    Color randomColor = RGBColor(Rnd(255), Rnd(255), Rnd(255));

    // Draw the circle base on the random data
    DrawCircleOnWindow(window, randomColor, x, y, radius);
}
RefreshScreen();

Delay(4000);
CloseAllWindows();