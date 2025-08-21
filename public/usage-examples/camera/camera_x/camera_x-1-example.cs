using SplashKitSDK;

class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("Camera X/Y Demo", 800, 600);
        
        // Move camera to test position
        SplashKit.MoveCameraTo(150, 75);
        
        while (!SplashKit.WindowCloseRequested("Camera X/Y Demo"))
        {
            SplashKit.ProcessEvents();
            
            // Get individual camera coordinates
            double camX = SplashKit.CameraX();
            double camY = SplashKit.CameraY();
            
            SplashKit.ClearScreen(Color.Navy);
            
            // Show the individual coordinates
            SplashKit.DrawText($"Camera X: {(int)camX}", Color.White, 10, 10);
            SplashKit.DrawText($"Camera Y: {(int)camY}", Color.White, 10, 35);
            
            // Compare with camera_position()
            Point2D fullPos = SplashKit.CameraPosition();
            SplashKit.DrawText($"Full position X: {(int)fullPos.X}", Color.Yellow, 10, 70);
            SplashKit.DrawText($"Full position Y: {(int)fullPos.Y}", Color.Yellow, 10, 95);
            
            // Show that they are the same
            if (camX == fullPos.X && camY == fullPos.Y)
            {
                SplashKit.DrawText("✓ Individual coordinates match full position", Color.Green, 10, 130);
            }
            
            // Draw grid lines at camera boundaries
            SplashKit.DrawLine(Color.Red, camX, 0, camX, 600);  // Left edge
            SplashKit.DrawLine(Color.Red, camX + 800, 0, camX + 800, 600);  // Right edge
            SplashKit.DrawLine(Color.Red, 0, camY, 800, camY);  // Top edge
            SplashKit.DrawLine(Color.Red, 0, camY + 600, 800, camY + 600);  // Bottom edge
            
            // Interactive: click to move camera
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D click = SplashKit.MousePosition();
                SplashKit.MoveCameraTo(click.X + camX - 400, click.Y + camY - 300);
            }
            
            SplashKit.DrawText("Click to move camera", Color.White, 10, 550);
            
            SplashKit.RefreshScreen(60);
        }
        
        SplashKit.CloseWindow("Camera X/Y Demo");
    }
}
