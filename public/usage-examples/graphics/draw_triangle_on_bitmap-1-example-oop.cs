using SplashKitSDK;

namespace DrawTriangleOnBitmap
{
    public class Program
    {
        public static void Main()
        {
            // Create a window and bitmap for the mountain scene
            Window window = new Window("Window", 400, 300);
            Bitmap bitmap = new Bitmap("mountain", 400, 300);
            
            // Fill background with light blue color
            bitmap.Clear(Color.LightBlue);
            
            // Draw right peak (smallest)
            bitmap.DrawTriangle(Color.Gray, 
                              175, 250,   // Left base
                              275, 175,   // Peak
                              375, 250);  // Right base
            
            // Draw left peak (medium)
            bitmap.DrawTriangle(Color.Gray,
                              25, 250,    // Left base
                              125, 125,   // Peak
                              225, 250);  // Right base
            
            // Draw center peak (tallest)
            bitmap.DrawTriangle(Color.Gray,
                              100, 250,   // Left base
                              200, 100,   // Peak
                              300, 250);  // Right base

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