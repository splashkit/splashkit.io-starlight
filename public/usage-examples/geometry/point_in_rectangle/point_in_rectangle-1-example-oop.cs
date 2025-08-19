using SplashKitSDK;

namespace PointInRectangleExample
{
    public class Program
    {
        public static void Main()
        {
            // Variable Declarations
            Point2D mousePt;
            Rectangle boundary = SplashKit.RectangleFrom(150, 150, 300, 100);
            string text;
            Color color1;
            Color color2;
            SplashKitSDK.Timer flashingTimer = SplashKit.CreateTimer("flash time");

            SplashKit.OpenWindow("Cursor Jail", 600, 600);
            flashingTimer.Start();

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Get mouse position
                mousePt = SplashKit.MousePosition();

                // Check if mouse is in the boundary
                if (SplashKit.PointInRectangle(mousePt, boundary))
                {
                    text = "";
                    color1 = Color.Green;
                    color2 = Color.Green;
                    flashingTimer.Reset();
                }
                else
                {
                    // Flash screen red and blue if mouse has escaped boundary
                    text = "JAILBREAK";
                    color1 = Color.RoyalBlue;
                    color2 = Color.DarkRed;
                }

                // Draw UI using timer ticks
                if (flashingTimer.Ticks < 500)
                {
                    SplashKit.ClearScreen(color1);
                    SplashKit.FillRectangle(Color.White, boundary);
                    SplashKit.RefreshScreen();
                }
                if (flashingTimer.Ticks >= 500 && flashingTimer.Ticks < 1000)
                {
                    SplashKit.ClearScreen(color2);
                    SplashKit.FillRectangle(Color.White, boundary);
                    SplashKit.DrawText(text, Color.Black, 250, 400);
                    SplashKit.RefreshScreen();
                }
                if (flashingTimer.Ticks >= 1000)
                {
                    flashingTimer.Reset();
                }
            }
            SplashKit.CloseAllWindows();
        }
    }
}