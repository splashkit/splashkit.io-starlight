using SplashKitSDK;

namespace CircleXExample
{
    public class Program
    {
        public static void Main()
        {
            // Create a circle (with random x position value bewteen 200 - 600)
            Circle circle = SplashKit.CircleAt(SplashKit.Rnd(400) + 200, 300, 200);

            Window window = new Window("Circle X", 800, 600);

            // Draw the Circle and x coordinate on window
            window.Clear(Color.White);
            SplashKit.DrawCircle(Color.Red, circle);
            SplashKit.DrawText($"Circle X: {SplashKit.CircleX(circle)}", Color.Black, 100, 100);
            window.Refresh();

            SplashKit.Delay(4000);
            window.Close();
        }
    }
}