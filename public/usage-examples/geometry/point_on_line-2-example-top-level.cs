using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Variable Declarations
double barX = 100;
Line slider = LineFrom(100, 300, 500, 300);
Line bar = LineFrom(barX, 310, barX, 290);
int percent = 0;
bool barSelected = false;

Window window = OpenWindow("Volume Slider", 600, 600);

while (!QuitRequested())
{
    ProcessEvents();

    // Check if user has clicked on the bar Line
    if (MouseDown(MouseButton.LeftButton) && PointOnLine(MousePosition(), bar))
    {
        barSelected = true;
    }

    // Check if user has released mouse button
    if (MouseUp(MouseButton.LeftButton))
    {
        barSelected = false;
    }

    // Update bar location
    if (barSelected && MouseX() >= 100 && MouseX() <= 500)
    {
        barX = MouseX(); // sets barX value to mouse X value
        percent = (int)((barX - 100) / (500 - 100) * 100); // convert barX position to percent value
        bar = LineFrom(barX, 310, barX, 290);
    }

    // Draw Lines and volume text
    ClearScreen(ColorWhite());
    DrawLine(ColorBlack(), bar);
    DrawLine(ColorBlack(), slider);
    DrawText($"Volume: {percent}", ColorBlack(), 200, 450);
    RefreshScreen();
}
CloseWindow(window);