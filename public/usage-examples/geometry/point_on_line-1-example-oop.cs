using SplashKitSDK;

namespace PointOnLineExample
{
    public class Program
    {
        public static void Main()
        {
            // Variable Declarations
            Line line = SplashKit.LineFrom(100, 300, 500, 300);

            // Create window
            Window window = new Window("Select Point", 600, 600);

            while (!SplashKit.QuitRequested())
            {
                // Display line
                window.Clear(Color.White);
                window.DrawLine(Color.Black, line);
                
                // Draw text if cursor is on line
                if (SplashKit.PointOnLine(SplashKit.MousePosition(), line))
                {
                    window.DrawText("Point on line: " + SplashKit.PointToString(SplashKit.MousePosition()), Color.Black, 200, 450);
                }

                window.Refresh();
                SplashKit.ProcessEvents();
            }

            window.Close();
        }
    }
}