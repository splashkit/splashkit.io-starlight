using SplashKitSDK;

namespace CircleYExample
{
    public class Program
    {
        public static void Main()
        {
            // Create a circle (with random y position value between 200 - 400)
            Circle circle = SplashKit.CircleAt(400, SplashKit.Rnd(200) + 200, 200);

            Window window = new Window("Circle Y", 800, 600);

            // Draw the Circle and y coordinate on window
            window.Clear(Color.White);
            SplashKit.DrawCircle(Color.Red, circle);
            SplashKit.DrawText("Circle Y: " + SplashKit.CircleY(circle), Color.Black, 100, 100);

            // Draw a line to show the circle Y coordinate
            SplashKit.DrawLine(Color.Black, 0, SplashKit.CircleY(circle), SplashKit.ScreenWidth(), SplashKit.CircleY(circle));

            // Draw 10 circles with radius of 50 and the same circle y coordinate
            for (int i = 0; i < 10; i++)
            {
                SplashKit.DrawCircle(Color.Blue, i * 60 + 100, SplashKit.CircleY(circle), 50);
            }
            window.Refresh();

            SplashKit.Delay(4000);
            window.Close();
        }
    }
}