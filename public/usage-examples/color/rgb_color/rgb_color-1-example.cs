using SplashKitSDK;

class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("RGB Color Demo", 800, 600);
        
        while (!SplashKit.WindowCloseRequested("RGB Color Demo"))
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.Black);
            
            // Create custom colors using RGB values
            Color purple = SplashKit.RgbColor(128, 0, 128);
            Color orange = SplashKit.RgbColor(255, 165, 0);
            Color teal = SplashKit.RgbColor(0, 128, 128);
            Color pink = SplashKit.RgbColor(255, 192, 203);
            
            // Draw colored rectangles
            SplashKit.FillRectangle(purple, 50, 50, 150, 100);
            SplashKit.FillRectangle(orange, 220, 50, 150, 100);
            SplashKit.FillRectangle(teal, 50, 200, 150, 100);
            SplashKit.FillRectangle(pink, 220, 200, 150, 100);
            
            // Label each color
            SplashKit.DrawText("Purple (128,0,128)", Color.White, 50, 160);
            SplashKit.DrawText("Orange (255,165,0)", Color.White, 220, 160);
            SplashKit.DrawText("Teal (0,128,128)", Color.White, 50, 310);
            SplashKit.DrawText("Pink (255,192,203)", Color.White, 220, 310);
            
            // Show RGB color creation in action
            SplashKit.DrawText("Creating colors with RgbColor(r, g, b)", Color.White, 50, 20);
            
            // Dynamic color example - change over time
            uint timeValue = SplashKit.CurrentTicks() / 10;
            Color dynamic = SplashKit.RgbColor((int)(timeValue % 256), (int)((timeValue * 2) % 256), (int)((timeValue * 3) % 256));
            SplashKit.FillCircle(dynamic, 600, 300, 80);
            SplashKit.DrawText("Dynamic Color", Color.White, 550, 400);
            
            SplashKit.RefreshScreen(60);
        }
        
        SplashKit.CloseWindow("RGB Color Demo");
    }
}
