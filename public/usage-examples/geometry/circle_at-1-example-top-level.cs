using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Open a window and draw the circle
OpenWindow("Circle Example", 800, 600);
Circle myCircle = CircleAt(400, 300, 100);

while (!WindowCloseRequested("Circle Example"))
{
    ProcessEvents();
    ClearScreen(Color.White);

    // Draw the circle
    FillCircle(Color.Blue, myCircle);

    RefreshScreen(60);
}

CloseAllWindows();
