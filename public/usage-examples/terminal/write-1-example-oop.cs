using SplashKitSDK;

namespace LoadingBar
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Progress Bar Simulation:");
            SplashKit.Write("Loading: [");

            for (int i = 0; i <= 15; i++) // Simulate progress in 15 steps
            {
                SplashKit.Delay(150); // Pause for 150 milliseconds
                SplashKit.Write("="); // Append to the progress bar
            }

            SplashKit.WriteLine("] Complete!\n");
        }
    }
}