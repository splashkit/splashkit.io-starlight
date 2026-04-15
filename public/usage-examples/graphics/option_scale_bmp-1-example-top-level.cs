using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Declare constants and variables
const int FPS = 60; // Set frame rate to 60 frames per second
double time = 0;
double scaleFactor = 1;

// Create a 600 x 600 bitmap with a white "ring" on black background
Bitmap bmp = CreateBitmap("ring", 600, 600);
ClearBitmap(bmp, Color.Black);
FillCircleOnBitmap(bmp, Color.White, 300, 300, 300);
FillCircleOnBitmap(bmp, Color.Black, 300, 300, 200);

OpenWindow("Mesmerising Bitmap Scaling", 800, 600);

while (!QuitRequested())
{
    ProcessEvents();

    // Increment the time and calculate the scale factor
    time += 1.0 / FPS;
    scaleFactor = time * time;

    // Reset time if the bitmap is over 2.5 times its initial size
    if (scaleFactor > 2.5)
    {
        time = 0;
    }

    // Create the draw options that will scale the bitmap
    DrawingOptions opts = OptionScaleBmp(scaleFactor, scaleFactor);

    // Draw the scaled bitmap onto the window and refresh
    ClearScreen(Color.Black);
    DrawBitmap(bmp, 100, 0, opts);
    RefreshScreen(FPS);
}

// Clean up
CloseAllWindows();