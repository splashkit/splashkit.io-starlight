using SplashKitSDK;

class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("Camera Position Demo", 800, 600);
        
        // Get the initial camera position
        Point2D currentPos = SplashKit.CameraPosition();
        SplashKit.WriteLine($"Initial camera position: ({currentPos.X}, {currentPos.Y})");
        
        // Move camera to a new position
        SplashKit.MoveCameraTo(100, 50);
        
        // Check the new position
        currentPos = SplashKit.CameraPosition();
        SplashKit.WriteLine($"New camera position: ({currentPos.X}, {currentPos.Y})");
        
        // Draw something to visualize the camera position
        while (!SplashKit.WindowCloseRequested("Camera Position Demo"))
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.Black);
            
            // Draw a reference grid to show camera movement
            for (int x = 0; x < 1000; x += 100)
            {
                SplashKit.DrawLine(Color.Gray, x, 0, x, 800);
            }
            for (int y = 0; y < 800; y += 100)
            {
                SplashKit.DrawLine(Color.Gray, 0, y, 1000, y);
            }
            
            // Show current camera position on screen
            currentPos = SplashKit.CameraPosition();
            SplashKit.DrawText($"Camera: ({(int)currentPos.X}, {(int)currentPos.Y})", 
                              Color.White, 10, 10);
            
            SplashKit.RefreshScreen(60);
        }
        
        SplashKit.CloseWindow("Camera Position Demo");
    }
}
