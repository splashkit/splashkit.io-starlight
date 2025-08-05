using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// open a window
Window window = new Window("Clear Window", 600, 200);

// main loop
while (!window.CloseRequested)
{
    // get user events
    ProcessEvents();

    // clear screen
    window.Clear(Color.White);

    if (Button("Red!", RectangleFrom(75, 85, 100, 30)))
    {
        ClearWindow(window, Color.Red);
        window.Refresh();
        Delay(1000);
        continue;
    }

    if (Button("Green!", RectangleFrom(250, 85, 100, 30)))
    {
        ClearWindow(window, Color.Green);
        window.Refresh();
        Delay(1000);
        continue;
    }

    if (Button("Blue!", RectangleFrom(425, 85, 100, 30)))
    {
        ClearWindow(window, Color.Blue);
        window.Refresh();
        Delay(1000);
        continue;
    }
    // finally draw interface, then refresh screen
    DrawInterface();
    window.Refresh();
}

// close all open windows
CloseAllWindows();