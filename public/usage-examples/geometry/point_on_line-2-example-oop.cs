using SplashKitSDK;

namespace PointOnLineExample
{
    public class Program
    {
        public static void Main()
        {
            // Variable Declarations
            double barX = 100;
            Line slider = SplashKit.LineFrom(100, 300, 500, 300);
            Line bar = SplashKit.LineFrom(barX, 310, barX, 290);
            int percent = 0;
            bool barSelected = false;

            Window window = new Window("Volume Slider", 600, 600);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Check if user has clicked on the bar Line
                if (SplashKit.MouseDown(MouseButton.LeftButton) && SplashKit.PointOnLine(SplashKit.MousePosition(), bar))
                {
                    barSelected = true;
                }

                // Check if user has released mouse button
                if (SplashKit.MouseUp(MouseButton.LeftButton))
                {
                    barSelected = false;
                }

                // Update bar location
                if (barSelected && SplashKit.MouseX() >= 100 && SplashKit.MouseX() <= 500)
                {
                    barX = SplashKit.MouseX(); // sets barX value to mouse X value
                    percent = (int)((barX - 100) / (500 - 100) * 100); // convert barX position to percent value
                    bar = SplashKit.LineFrom(barX, 310, barX, 290);
                }

                // Draw Lines and volume text
                window.Clear(Color.White);
                window.DrawLine(Color.Black, bar);
                window.DrawLine(Color.Black, slider);
                window.DrawText($"Volume: {percent} %", Color.Black, 200, 450);
                window.Refresh();
            }
            window.Close();
        }
    }
}