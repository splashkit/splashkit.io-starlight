using SplashKitSDK;

class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("Move Camera Demo", 800, 600);
        
        double targetX = 0, targetY = 0;
        
        while (!SplashKit.WindowCloseRequested("Move Camera Demo"))
        {
            SplashKit.ProcessEvents();
            
            // Use arrow keys to move the camera
            if (SplashKit.KeyDown(KeyCode.RightKey))
                targetX += 5;
            if (SplashKit.KeyDown(KeyCode.LeftKey))
                targetX -= 5;
            if (SplashKit.KeyDown(KeyCode.DownKey))
                targetY += 5;
            if (SplashKit.KeyDown(KeyCode.UpKey))
                targetY -= 5;
            
            // Move camera to the new position
            SplashKit.MoveCameraTo(targetX, targetY);
            
            SplashKit.ClearScreen(Color.DarkGreen);
            
            // Draw a large world with objects
            for (int x = -500; x < 1500; x += 100)
            {
                for (int y = -500; y < 1200; y += 100)
                {
                    SplashKit.FillCircle(Color.Red, x, y, 20);
                    SplashKit.DrawText($"{x},{y}", Color.White, x - 15, y + 25);
                }
            }
            
            // Draw camera boundaries
            Point2D camPos = SplashKit.CameraPosition();
            SplashKit.DrawRectangle(Color.Yellow, camPos.X, camPos.Y, 800, 600);
            
            // Show instructions
            SplashKit.DrawText("Use arrow keys to move camera", Color.White, 10, 10);
            SplashKit.DrawText($"Camera at: ({(int)camPos.X}, {(int)camPos.Y})", 
                              Color.White, 10, 30);
            
            SplashKit.RefreshScreen(60);
        }
        
        SplashKit.CloseWindow("Move Camera Demo");
    }
}
