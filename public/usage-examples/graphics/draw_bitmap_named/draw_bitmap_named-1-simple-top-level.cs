using static SplashKitSDK.SplashKit;

// Open Window
OpenWindow("Basic Bitmap Drawing", 315, 330);

// Load bitmap image
LoadBitmap("skbox", "skbox.png"); 

while (!QuitRequested())
{
    ProcessEvents();

    ClearScreen(RGBColor(67, 80, 175));
    DrawBitmap("skbox", 50, 50); // draw bitmap image
    RefreshScreen();
}
CloseAllWindows();