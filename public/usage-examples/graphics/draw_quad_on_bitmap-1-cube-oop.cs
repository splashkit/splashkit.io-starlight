using SplashKitSDK;

namespace DrawQuadOnBitmapExample
{
    public class Program
    {
        public static void Main()
        {
            // Create a window and bitmap to draw on
            Window window = new Window("Cube", 800, 600);
            Bitmap bitmap = new Bitmap("cube", 800, 600);

            // Fill background with light color
            bitmap.Clear(Color.White);

            // Define the color for the cube
            Color cubeColor = Color.Blue;

            // Define the coordinates of the front and back faces of the cube
            Quad frontFace = SplashKit.QuadFrom(
                300, 200,    // Top-left
                500, 200,    // Top-right
                300, 400,    // Bottom-left
                500, 400     // Bottom-right
            );

            Quad backFace = SplashKit.QuadFrom(
                350, 150,    // Top-left
                550, 150,    // Top-right
                350, 350,    // Bottom-left
                550, 350     // Bottom-right
            );

            // Draw the faces of the cube
            bitmap.DrawQuad(cubeColor, frontFace);
            bitmap.DrawQuad(cubeColor, backFace);

            // Connect the front and back faces for the 3D effect
            bitmap.DrawLine(cubeColor, 300, 200, 350, 150);
            bitmap.DrawLine(cubeColor, 500, 200, 550, 150);
            bitmap.DrawLine(cubeColor, 300, 400, 350, 350);
            bitmap.DrawLine(cubeColor, 500, 400, 550, 350);

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                // Draw the bitmap to the window
                window.DrawBitmap(bitmap, 0, 0);
                // Refresh the window
                SplashKit.RefreshScreen();
            }
            
            bitmap.Free();
            window.Close();
        }
    }
}