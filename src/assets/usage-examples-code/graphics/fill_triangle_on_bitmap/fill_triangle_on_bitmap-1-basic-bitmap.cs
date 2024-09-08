using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Underwater Adventure", 1000, 500);

// Load the bitmap
Bitmap underwaterScene = LoadBitmap("underwater_scene", "underwater_scene.png");

// Fill the triangle on the bitmap
double x1 = 285, y1 = 250;
double x2 = 310, y2 = 240;
double x3 = 310, y3 = 260;

FillTriangleOnBitmap(underwaterScene, ColorRed(), x1, y1, x2, y2, x3, y3);

// Draw the bitmap and other graphics
DrawBitmap(underwaterScene, 0, 0);
DrawText("Colourful Fish", ColorRed(), "arial", 123, 240, 200);
DrawLine(ColorRed(), 280, 220, 305, 255);

// Refresh the screen and wait
RefreshScreen();
Delay(5000);

// Close all windows
CloseAllWindows();
