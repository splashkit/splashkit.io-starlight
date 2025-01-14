using SplashKitSDK;

namespace FillCircleOnWindowExample
{
    public class Program
    {
        public static void Main()
        {
            // Open a new window and initialize to a window variable
            Window window = SplashKit.OpenWindow("Traffic Lights", 800, 600);

            window.Clear(Color.White);

            // Use function to place 3 circles in destination window as traffic lights
            window.FillCircle(Color.Red, 400, 100, 50);
            window.FillCircle(Color.Yellow, 400, 250, 50);
            window.FillCircle(Color.Green, 400, 400, 50);

            window.Refresh();
            SplashKit.Delay(5000);

            // Close loaded window
            window.Close();

        }
    }
}