using SplashKitSDK;

namespace DrawLineOnBitmap
{
    public class Program
    {
        public static void Main()
        {
            // Create a Window and bitmap for the map
            Window window = new Window("Window", 400, 300);
            Bitmap bitmap = new Bitmap("map", 400, 300);

            // Fill background with white
            SplashKit.ClearBitmap(bitmap, Color.White);

            // Draw the route line and points
            SplashKit.DrawLineOnBitmap(bitmap, Color.Green,
                          100, 80,    // Starting point (x1, y1)
                          300, 220);  // End point (x2, y2)
            SplashKit.FillCircleOnBitmap(bitmap, Color.Red, 100, 80, 5);    // Start point
            SplashKit.FillCircleOnBitmap(bitmap, Color.Red, 300, 220, 5);   // End point

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                // Draw the bitmap to the current window
                window.DrawBitmap(bitmap, 0, 0);
                SplashKit.RefreshScreen();
            }
            bitmap.Free();
            window.Cl
        }
    }
}