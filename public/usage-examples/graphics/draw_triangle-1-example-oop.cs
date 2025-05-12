using SplashKitSDK;

namespace DrawTriangleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Triangle Coordinates", 800, 400);

            // Top middle triangle point
            int x1 = 400;
            int y1 = 100;

            // Bottom left triangle point
            int x2 = 200;
            int y2 = 300;

            // Bottom right triangle point
            int x3 = 600;
            int y3 = 300;

            SplashKit.ClearScreen();

            // Draw triangle using the points above
            SplashKit.DrawTriangle(Color.Red, x1, y1, x2, y2, x3, y3);

            // Draw triangle information
            SplashKit.FillCircle(Color.Blue, x1, y1, 3);
            SplashKit.FillCircle(Color.Blue, x2, y2, 3);
            SplashKit.FillCircle(Color.Blue, x3, y3, 3);
            SplashKit.DrawText($"(x={x1}, y={y1})", Color.Blue, x1 - 50, y1 - 20);
            SplashKit.DrawText($"(x={x2}, y={y2})", Color.Blue, x2 - 120, y2);
            SplashKit.DrawText($"(x={x3}, y={y3})", Color.Blue, x3 + 10, y3);
            SplashKit.RefreshScreen();
            SplashKit.Delay(10000);

            SplashKit.CloseAllWindows();
        }
    }
}