using static SplashKitSDK.SplashKit;
using SplashKitSDK;

// Create a Window and bitmap for the map
Window window = OpenWindow("Window", 400, 400);
Bitmap bitmap = CreateBitmap("planet", 400, 400);

// Fill background with dark color
ClearBitmap(bitmap, ColorBlack());
// Create color
Color red = ColorRed();

// Draw the main planet circle
FillCircleOnBitmap(bitmap, RGBAColor(180, 0, 0, 255), 200, 200, 150);
DrawCircleOnBitmap(bitmap, red, 200, 200, 150);

// Add some surface details with smaller circles
for (int i = 0; i < 15; i++)
{
    double x = Rnd(100, 300);  // Random between 100 and 300
    double y = Rnd(100, 300);   // Random between 100 and 300
    double size = Rnd(10, 30);  // Random between 10 and 30
    DrawCircleOnBitmap(bitmap, red, x, y, size);
}
while (!window.CloseRequested)
{
    ProcessEvents();
    // Draw the bitmap to the current window
    DrawBitmap(bitmap, 0, 0);
    RefreshScreen();
}
FreeBitmap(bitmap);
CloseAllWindows();