using SplashKitSDK;

namespace FillTriangleOnWindowExample
{
    public class Program
    {
        public static void Main()
        {

            Window blueWindow = SplashKit.OpenWindow("Blue Triangle", 200, 200);
            Window redWindow = SplashKit.OpenWindow("Red Triangle", 200, 200);
            redWindow.MoveTo(blueWindow.X + blueWindow.Width, blueWindow.Y);

            // Define the triangles to draw
            Triangle blueTriangle = SplashKit.TriangleFrom(SplashKit.PointAt(50, 100), SplashKit.PointAt(100, 50), SplashKit.PointAt(150, 100));
            Triangle redTriangle = SplashKit.TriangleFrom(SplashKit.PointAt(50, 50), SplashKit.PointAt(100, 100), SplashKit.PointAt(150, 50));

            // Fill a blue triangle on the first window
            blueWindow.Clear(Color.White);
            SplashKit.FillTriangleOnWindow(blueWindow, Color.Blue, blueTriangle);
            blueWindow.Refresh();

            // Fill a red triangle on the second window
            redWindow.Clear(Color.White);
            SplashKit.FillTriangleOnWindow(redWindow, Color.Red, redTriangle);
            redWindow.Refresh();

            SplashKit.Delay(10000);

            SplashKit.CloseWindow(blueWindow);
            SplashKit.CloseWindow(redWindow);
        }
    }
}