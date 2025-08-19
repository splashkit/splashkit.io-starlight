using static SplashKitSDK.SplashKit;

WriteLine("Progress Bar Simulation:");
Write("Loading: [");

for (int i = 0; i <= 15; i++) // Simulate progress in 15 steps
{
    Delay(150); // Pause for 150 milliseconds
    Write("="); // Append to the progress bar
}

WriteLine("] Complete!\n");