using SplashKitSDK;

namespace DrawCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Draw Circles", 800, 600);

            // Create circles with different radii
            Circle circle1 = new Circle { Center = SplashKit.ScreenCenter(), Radius = 50 };
            Circle circle2 = new Circle { Center = SplashKit.ScreenCenter(), Radius = 100 };

            SplashKit.ClearScreen();

            // Draw the circles with different colors
            circle1.Draw(Color.Red);
            circle2.Draw(Color.Blue);
            SplashKit.DrawCircle(Color.Orange, SplashKit.CircleAt(SplashKit.ScreenCenter(), 150));
            SplashKit.DrawCircle(Color.Green, SplashKit.CircleAt(SplashKit.ScreenCenter(), 200 ));

            SplashKit.RefreshScreen();

            SplashKit.Delay(4000);
            SplashKit.CloseAllWindows();
        }
    }
}