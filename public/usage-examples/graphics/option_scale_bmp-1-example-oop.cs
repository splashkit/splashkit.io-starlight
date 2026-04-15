using SplashKitSDK;

namespace OptionScaleBmpExample
{
    public class Program
    {
        public static void Main()
        {
            // Declare constants and variables
            const int FPS = 60; // Set frame rate to 60 frames per second
            double time = 0;
            double scaleFactor = 1;

            // Create a 600 x 600 bitmap with a white "ring" on black background
            Bitmap bmp = SplashKit.CreateBitmap("ring", 600, 600);
            bmp.Clear(Color.Black);
            bmp.FillCircle(Color.White, 300, 300, 300);
            bmp.FillCircle(Color.Black, 300, 300, 200);

            SplashKit.OpenWindow("Mesmerising Bitmap Scaling", 800, 600);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Increment the time and calculate the scale factor
                time += 1.0 / FPS;
                scaleFactor = time * time;

                // Reset time if the bitmap is over 2.5 times its initial size
                if (scaleFactor > 2.5)
                {
                    time = 0;
                }

                // Create the draw options that will scale the bitmap
                DrawingOptions opts = SplashKit.OptionScaleBmp(scaleFactor, scaleFactor);

                // Draw the scaled bitmap onto the window and refresh
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(bmp, 100, 0, opts);
                SplashKit.RefreshScreen(FPS);
            }

            // Clean up
            SplashKit.CloseAllWindows();
        }
    }
}