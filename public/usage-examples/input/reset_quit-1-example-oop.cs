using SplashKitSDK;

namespace ResetQuit
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Quit Confirmation", 600, 300);

            bool running = true;     // controls the main loop
            bool confirming = false; // true while the "Really quit?" prompt is showing
            int cancelled = 0;       // how many times the quit request was cancelled

            while (running)
            {
                SplashKit.ProcessEvents();

                // QuitRequested becomes true when the window's close button is clicked,
                // and stays true until the program exits or ResetQuit is called
                if (SplashKit.QuitRequested())
                    confirming = true;

                if (confirming)
                {
                    // Y confirms the quit and ends the loop
                    if (SplashKit.KeyTyped(KeyCode.YKey))
                        running = false;

                    // N cancels it - ResetQuit makes QuitRequested return false again
                    if (SplashKit.KeyTyped(KeyCode.NKey))
                    {
                        SplashKit.ResetQuit();
                        confirming = false;
                        cancelled++;
                    }
                }

                SplashKit.ClearScreen(Color.White);

                if (confirming)
                {
                    SplashKit.DrawText("Really quit?", Color.Red, "Arial", 28, 220, 90);
                    SplashKit.DrawText("[Y] Yes    [N] No", Color.Black, "Arial", 20, 215, 150);
                }
                else
                {
                    SplashKit.DrawText("Running - click the X to quit", Color.Green, "Arial", 24, 150, 90);
                    SplashKit.DrawText("Quit requests cancelled: " + cancelled, Color.Black, "Arial", 20, 175, 150);
                }

                SplashKit.DrawText("reset_quit cancels a pending quit request", Color.Gray, "Arial", 16, 145, 230);

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseAllWindows();
        }
    }
}
