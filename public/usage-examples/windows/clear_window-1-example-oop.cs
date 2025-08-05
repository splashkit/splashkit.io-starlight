using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        // open a window
        Window window = new Window("Clear Window", 600, 200);

        // main loop
        while (!window.CloseRequested)
        {
            // get user events
            SplashKit.ProcessEvents();

            // clear screen
            window.Clear(Color.White);

            if (SplashKit.Button("Red!", SplashKit.RectangleFrom(75, 85, 100, 30)))
            {
                SplashKit.ClearWindow(window, Color.Red);
                window.Refresh();
                SplashKit.Delay(1000);
                continue;
            }

            if (SplashKit.Button("Green!", SplashKit.RectangleFrom(250, 85, 100, 30)))
            {
                SplashKit.ClearWindow(window, Color.Green);
                window.Refresh();
                SplashKit.Delay(1000);
                continue;
            }

            if (SplashKit.Button("Blue!", SplashKit.RectangleFrom(425, 85, 100, 30)))
            {
                SplashKit.ClearWindow(window, Color.Blue);
                window.Refresh();
                SplashKit.Delay(1000);
                continue;
            }
            // finally draw interface, then refresh screen
            SplashKit.DrawInterface();
            window.Refresh();
        }

        // close all open windows
        SplashKit.CloseAllWindows();
    }
}