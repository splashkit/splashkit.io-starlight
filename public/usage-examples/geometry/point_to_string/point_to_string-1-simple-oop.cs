using SplashKitSDK;

namespace PointToStringExample
{
    public class Program
    {
        public static void Main()
        {
            string mousePositionText = "Click to see coordinates...";

            Window window = new Window("Mouse Clicked Location", 600, 600);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Check for mouse click
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    mousePositionText = "Mouse clicked at " + SplashKit.PointToString(SplashKit.MousePosition());
                }

                // Print mouse position to screen
                window.Clear(Color.GhostWhite);
                window.DrawText(mousePositionText, Color.Black, 100, 300);
                window.Refresh();
            }

            window.Close();
        }
    }
}