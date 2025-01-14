using SplashKitSDK;

namespace FillQuadOnBitmap
{
    public class Program
    {
        public static void Main()
        {
            // Create a window and bitmap for the window
            Window window = new Window("Windows Logo", 400, 300);
            Bitmap bitmap = new Bitmap("Windows Logo Bitmap", 400, 300);

            // Fill background with windows blue
            bitmap.Clear(Color.RGBAColor(51, 118, 212, 255));

            // Create color
            Color color = Color.White;

            // Draw the four Window panels
            Quad[] panels = {
                SplashKit.QuadFrom(
                    85, 50, 
                    180, 41,  
                    85, 130,    
                    180, 130  
                ),
                SplashKit.QuadFrom(
                    193, 40,  
                    323, 26,  
                    193, 130,   
                    323, 130 
                ),
                SplashKit.QuadFrom(
                    85, 143, 
                    180, 143,  
                    85, 222,   
                    180, 233  
                ),
                SplashKit.QuadFrom(
                    193, 143, 
                    323, 143, 
                    193, 235,  
                    323, 250 
                )
            };

            // Draw each panel
            for (int i = 0; i < panels.Length; i++)
            {
                bitmap.FillQuad(color, panels[i]);
            }

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                // Draw the bitmap to the window
                window.DrawBitmap(bitmap, 0, 0);
                // Refresh the window
                SplashKit.RefreshScreen();
            }

            bitmap.Free();
        }
    }
}