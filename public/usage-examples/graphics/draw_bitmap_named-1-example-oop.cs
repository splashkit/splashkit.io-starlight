using SplashKitSDK;

namespace DrawBitmapNamed
{
    public class Program
    {
        public static void Main()
        {
            // Open Window
            Window window = new Window("Basic Bitmap Drawing", 315, 330);

            // Load bitmap image
            SplashKit.LoadBitmap("skbox", "skbox.png");

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen(Color.RGBColor(67, 80, 175));
                SplashKit.DrawBitmap("skbox", 50, 50); // draw bitmap image
                SplashKit.RefreshScreen();
            }
            SplashKit.CloseAllWindows();
        }
    }
}