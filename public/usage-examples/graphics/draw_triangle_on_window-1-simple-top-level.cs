using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window window = OpenWindow("Draw Triangle on Window", 800, 600);

ClearScreen(ColorWhite());
for (int i = 0; i < 20; i++)
{
    // Set the x position for triangles increase by 40 * i every round
    double x = 40 * i;

    // Draw the triangles by increasing x position
    DrawTriangleOnWindow(window, RandomRGBColor(255), 0 + x, 0, 20 + x, 40, 40 + x, 0);
}
RefreshScreen();

Delay(4000);
CloseAllWindows();