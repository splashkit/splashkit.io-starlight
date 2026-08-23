using SplashKitSDK;

namespace CloseWindowExample
{
    public class Program
    {
        public static void Main()
        {
            // open a window
            Window wind = SplashKit.OpenWindow("DON'T CLICK THE BUTTON!", 400, 200);

            bool countdownStarted = false;
            int countdown = 5;
            SplashKitSDK.Timer countdownTimer = new SplashKitSDK.Timer("countdown");

            // main loop
            while (!SplashKit.QuitRequested())
            {
                // get user events
                SplashKit.ProcessEvents();

                // clear screen
                SplashKit.ClearWindow(wind, Color.White);

                if (!countdownStarted)
                {
                    // Show the button before countdown starts
                    if (SplashKit.Button("Click Me!", SplashKit.RectangleFrom(150, 85, 100, 30)))
                    {
                        countdownStarted = true;
                        SplashKit.StartTimer(countdownTimer);
                    }
                }
                else
                {
                    // Display countdown
                    SplashKit.DrawText($"This window will self destruct in {countdown}", Color.Black, "arial", 18, 50, 85);

                    // Check if 1 second has passed
                    if (SplashKit.TimerTicks(countdownTimer) > 1000)
                    {
                        countdown--;
                        SplashKit.ResetTimer(countdownTimer);

                        if (countdown <= 0)
                        {
                            SplashKit.CloseWindow(wind);
                            break;
                        }
                    }
                }

                // draw interface and refresh
                SplashKit.DrawInterface();
                SplashKit.RefreshWindow(wind);
            }

            // close all open windows
            SplashKit.CloseAllWindows();
        }
    }
}