using SplashKitSDK;

namespace ButtonExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Button Click Counter", 800, 600);

            // Track click counts for each button
            int redCount = 0;
            int blueCount = 0;
            int greenCount = 0;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                // Show instructions for the user
                SplashKit.DrawText("Click the buttons to increment counters", Color.Black, 10, 10);

                // Create a panel with three buttons
                if (SplashKit.StartPanel("Click Counter", SplashKit.RectangleFrom(50, 50, 200, 200)))
                {
                    // Check if each button is clicked and update counts
                    if (SplashKit.Button("Red"))
                    {
                        redCount++;
                    }
                    if (SplashKit.Button("Blue"))
                    {
                        blueCount++;
                    }
                    if (SplashKit.Button("Green"))
                    {
                        greenCount++;
                    }
                    SplashKit.EndPanel("Click Counter");
                }

                // Display each button's click count on the window
                SplashKit.DrawText("Red clicks: " + redCount.ToString(), Color.Red, 300, 100);
                SplashKit.DrawText("Blue clicks: " + blueCount.ToString(), Color.Blue, 300, 130);
                SplashKit.DrawText("Green clicks: " + greenCount.ToString(), Color.Green, 300, 160);

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseAllWindows();
        }
    }
}
