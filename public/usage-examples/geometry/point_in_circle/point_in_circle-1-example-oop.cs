using SplashKitSDK;

namespace PointInCircleExample
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Point In Circle", 800, 600);
            Circle circle = SplashKit.CircleAt(400, 300, 100);
            Point2D mousePt;
            string text;
            Color circleClr;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                mousePt = SplashKit.MousePosition();

                // Update text and circle colour based on the mouse position in relation to the circle
                if (SplashKit.PointInCircle(mousePt, circle))
                {
                    circleClr = SplashKit.ColorRed();
                    text = "Point in the Circle!";
                }
                else
                {
                    circleClr = SplashKit.ColorGreen();
                    text = "Point not in the Circle!";
                }

                SplashKit.ClearScreen();
                SplashKit.DrawCircle(circleClr, circle);
                SplashKit.DrawText(text, SplashKit.ColorRed(), 100, 100);
                SplashKit.RefreshScreen();
            }
            window.Close();
        }
    }
}