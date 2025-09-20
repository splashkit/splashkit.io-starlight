using SplashKitSDK;

class Program
{
    static void Main(string[] args)
    {
        // Open a window
        SplashKit.OpenWindow("Button Clicked Example", 800, 600);
        
        // Create buttons
        Button redButton = SplashKit.Button("Red Button");
        Button blueButton = SplashKit.Button("Blue Button");
        Button greenButton = SplashKit.Button("Green Button");
        
        // Position buttons
        SplashKit.ButtonSetPosition(redButton, 100, 200);
        SplashKit.ButtonSetPosition(blueButton, 300, 200);
        SplashKit.ButtonSetPosition(greenButton, 500, 200);
        
        // Variables to track button states
        int redClicks = 0;
        int blueClicks = 0;
        int greenClicks = 0;
        
        SplashKit.WriteLine("Button Clicked Example");
        SplashKit.WriteLine("Click buttons to see click counts");
        SplashKit.WriteLine("Press ESC to exit");
        
        while (!SplashKit.WindowCloseRequested("Button Clicked Example"))
        {
            // Clear the screen
            SplashKit.ClearScreen(Color.White);
            
            // Check if buttons were clicked
            if (SplashKit.ButtonClicked(redButton))
            {
                redClicks++;
                SplashKit.WriteLine("Red button clicked! Total: " + redClicks);
            }
            
            if (SplashKit.ButtonClicked(blueButton))
            {
                blueClicks++;
                SplashKit.WriteLine("Blue button clicked! Total: " + blueClicks);
            }
            
            if (SplashKit.ButtonClicked(greenButton))
            {
                greenClicks++;
                SplashKit.WriteLine("Green button clicked! Total: " + greenClicks);
            }
            
            // Draw buttons
            SplashKit.DrawButton(redButton);
            SplashKit.DrawButton(blueButton);
            SplashKit.DrawButton(greenButton);
            
            // Display click counts
            SplashKit.DrawText("Red Button Clicks: " + redClicks, Color.Red, 100, 300);
            SplashKit.DrawText("Blue Button Clicks: " + blueClicks, Color.Blue, 300, 300);
            SplashKit.DrawText("Green Button Clicks: " + greenClicks, Color.Green, 500, 300);
            
            // Instructions
            SplashKit.DrawText("Click the buttons above to see the click counts increase", Color.Black, 100, 400);
            
            // Refresh the screen
            SplashKit.RefreshScreen();
            
            // Process events
            SplashKit.ProcessEvents();
            
            // Small delay
            SplashKit.Delay(16);
        }
        
        // Clean up
        SplashKit.FreeButton(redButton);
        SplashKit.FreeButton(blueButton);
        SplashKit.FreeButton(greenButton);
    }
} 