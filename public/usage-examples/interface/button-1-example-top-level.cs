using static SplashKitSDK.SplashKit;

OpenWindow("Button Click Counter", 800, 600);

// Track click counts for each button
int redCount = 0;
int blueCount = 0;
int greenCount = 0;

while (!QuitRequested())
{
    ProcessEvents();
    ClearScreen(ColorWhite());

    // Show instructions for the user
    DrawText("Click the buttons to increment counters", ColorBlack(), 10, 10);

    // Create a panel with three buttons
    if (StartPanel("Click Counter", RectangleFrom(50, 50, 200, 200)))
    {
        // Check if each button is clicked and update counts
        if (Button("Red"))
        {
            redCount++;
        }
        if (Button("Blue"))
        {
            blueCount++;
        }
        if (Button("Green"))
        {
            greenCount++;
        }
        EndPanel("Click Counter");
    }

    // Display each button's click count on the window
    DrawText("Red clicks: " + redCount.ToString(), ColorRed(), 300, 100);
    DrawText("Blue clicks: " + blueCount.ToString(), ColorBlue(), 300, 130);
    DrawText("Green clicks: " + greenCount.ToString(), ColorGreen(), 300, 160);

    RefreshScreen(60);
}

CloseAllWindows();
