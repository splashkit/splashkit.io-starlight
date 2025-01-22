using SplashKitSDK;

namespace DrawCircleOnBitmap
{
    public class Program
    {
        public static void Main()
        {
            // Create a Window and bitmap for the map
            Window window = new Window("Window", 400, 400);
            Bitmap bitmap = new Bitmap("planet", 400, 400);

            // Fill background with dark color
            bitmap.Clear(Color.Black);

            // Create color
            Color red = Color.Red;

            // Draw the main planet circle
            bitmap.FillCircle(Color.RGBAColor(180, 0, 0, 255), 200, 200, 150);
            bitmap.DrawCircle(red, 200, 200, 150);

            // Add some surface details with smaller circles
            for (int i = 0; i < 15; i++)
            {
                double x = SplashKit.Rnd(100, 300);  // Random between 100 and 300
                double y = SplashKit.Rnd(100, 300);  // Random between 100 and 300
                double size = SplashKit.Rnd(10, 30); // Random between 10 and 30
                bitmap.DrawCircle(red, x, y, size);
            }
            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                // Draw the bitmap to the window
                window.DrawBitmap(bitmap, 0, 0);
                SplashKit.RefreshScreen();
            }
            bitmap.Free();
            SplashKit.CloseAllWindows();
        }
    }
}