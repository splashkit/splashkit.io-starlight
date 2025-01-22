using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create a Window and bitmap for the map
Window window = OpenWindow("Window", 400, 300);
Bitmap bitmap = CreateBitmap("map", 400, 300);

// Fill background with white
ClearBitmap(bitmap, ColorWhite());

// Draw the route line and points
DrawLineOnBitmap(bitmap, ColorGreen(),
                100, 80,    // Starting point (x1, y1)
                300, 220);  // End point (x2, y2)
FillCircleOnBitmap(bitmap, ColorRed(), 100, 80, 5);    // Start point
FillCircleOnBitmap(bitmap, ColorRed(), 300, 220, 5);   // End point

while (!window.CloseRequested)
{
    ProcessEvents();
    // Draw the bitmap to the current window
    DrawBitmap(bitmap, 0, 0);
    RefreshScreen();
}

FreeBitmap(bitmap);
CloseAllWindows();