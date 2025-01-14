using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create a window and bitmap for the mountain scene
Window window = OpenWindow("Window", 400, 300);
Bitmap bitmap = CreateBitmap("mountain", 400, 300);

// Fill background with light blue color
ClearBitmap(bitmap, ColorLightBlue());

// Draw right peak (smallest)
DrawTriangleOnBitmap(bitmap, ColorGray(),
                     175, 250,   // Left base
                     275, 175,   // Peak
                     375, 250);  // Right base

// Draw left peak (medium)
DrawTriangleOnBitmap(bitmap, ColorGray(),
                     25, 250,    // Left base
                     125, 125,   // Peak
                     225, 250);  // Right base

// Draw center peak (tallest)
DrawTriangleOnBitmap(bitmap, ColorGray(),
                     100, 250,   // Left base
                     200, 100,   // Peak
                     300, 250);  // Right base

while (!WindowCloseRequested(window))
{
    ProcessEvents();
    // Draw the bitmap to the window
    DrawBitmap(bitmap, 0, 0);
    RefreshScreen();
}

FreeBitmap(bitmap);
CloseAllWindows();