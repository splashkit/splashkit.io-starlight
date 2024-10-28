using static SplashKitSDK.SplashKit;

OpenWindow("Basic Bitmap Drawing", 315, 330);

LoadBitmap("skbox", "skbox.png"); // Load bitmap image

while (!QuitRequested())
{
    ProcessEvents();

    ClearScreen(RGBColor(67, 80, 175));
    DrawBitmap("skbox", 50, 50); // draw bitmap image
    RefreshScreen();
}
CloseAllWindows();