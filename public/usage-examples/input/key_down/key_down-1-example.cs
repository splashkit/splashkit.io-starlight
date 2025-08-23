using SplashKitSDK;

class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("Key Down Demo", 800, 600);
        
        double x = 400, y = 300;
        double speed = 5.0;
        
        while (!SplashKit.WindowCloseRequested("Key Down Demo"))
        {
            SplashKit.ProcessEvents();
            
            // Move the circle based on arrow keys being held down
            if (SplashKit.KeyDown(KeyCode.UpKey))
                y -= speed;
            if (SplashKit.KeyDown(KeyCode.DownKey))
                y += speed;
            if (SplashKit.KeyDown(KeyCode.LeftKey))
                x -= speed;
            if (SplashKit.KeyDown(KeyCode.RightKey))
                x += speed;
            
            // Keep the circle within window bounds
            if (x < 25) x = 25;
            if (x > 775) x = 775;
            if (y < 25) y = 25;
            if (y > 575) y = 575;
            
            SplashKit.ClearScreen(Color.Black);
            
            // Draw the controllable circle
            SplashKit.FillCircle(Color.Blue, x, y, 25);
            
            // Show instructions and key states
            SplashKit.DrawText("Use arrow keys to move the circle", Color.White, 10, 10);
            SplashKit.DrawText("Hold keys for continuous movement", Color.White, 10, 30);
            
            // Show which keys are currently pressed
            string status = "Keys pressed: ";
            if (SplashKit.KeyDown(KeyCode.UpKey)) status += "UP ";
            if (SplashKit.KeyDown(KeyCode.DownKey)) status += "DOWN ";
            if (SplashKit.KeyDown(KeyCode.LeftKey)) status += "LEFT ";
            if (SplashKit.KeyDown(KeyCode.RightKey)) status += "RIGHT ";
            if (!SplashKit.KeyDown(KeyCode.UpKey) && !SplashKit.KeyDown(KeyCode.DownKey) && 
                !SplashKit.KeyDown(KeyCode.LeftKey) && !SplashKit.KeyDown(KeyCode.RightKey))
                status += "None";
                
            SplashKit.DrawText(status, Color.Yellow, 10, 50);
            
            // Show position
            SplashKit.DrawText($"Position: ({(int)x}, {(int)y})", Color.Green, 10, 70);
            
            SplashKit.RefreshScreen(60);
        }
        
        SplashKit.CloseWindow("Key Down Demo");
    }
}
