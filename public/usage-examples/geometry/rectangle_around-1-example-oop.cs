using SplashKitSDK;

namespace RectangleAroundExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Boring Screensaver", 800, 600);

            Circle circle;
            int circleSize = 30;
            float rotationDegrees = 0;
            Point2D circleCoordinates;
            bool growing = true;
            SplashKitSDK.Timer mainTimer = SplashKit.CreateTimer("mainTimer");
            SplashKit.StartTimer(mainTimer);
            SplashKitSDK.Timer reverseTimer = SplashKit.CreateTimer("reverseTimer");
            SplashKit.StartTimer(reverseTimer);

            while (!SplashKit.QuitRequested())
            {
                rotationDegrees += 0.005f;
                circleCoordinates = SplashKit.PointAt(300 + 150 * SplashKit.Cosine(rotationDegrees), 300 + 150 * SplashKit.Sine(rotationDegrees));
                circle = SplashKit.CircleAt(circleCoordinates, circleSize);

                if (SplashKit.TimerTicks(mainTimer) >= 40 && growing == true)
                {
                    circleSize += 1;
                    SplashKit.ResetTimer(mainTimer);
                }
                else if (SplashKit.TimerTicks(reverseTimer) >= 3000)
                {
                    growing = false;
                }

                if (SplashKit.TimerTicks(mainTimer) >= 40 && growing == false)
                {
                    circleSize -= 1;
                    SplashKit.ResetTimer(mainTimer);
                }
                else if (SplashKit.TimerTicks(reverseTimer) >= 6000)
                {
                    growing = true;
                    SplashKit.ResetTimer(reverseTimer);
                }

                SplashKit.ProcessEvents();

                SplashKit.ClearScreen(Color.White);
                // A rectangle is drawn which encompasses the circle. It shares the same height, width and position
                SplashKit.DrawRectangle(Color.Black, SplashKit.RectangleAround(circle));
                SplashKit.FillCircle(Color.Red, circle);
                SplashKit.RefreshScreen();
            }
            SplashKit.CloseAllWindows();
        }
    }
}