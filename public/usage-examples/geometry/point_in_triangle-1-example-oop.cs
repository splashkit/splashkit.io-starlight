using SplashKitSDK;

namespace PointInTriangleExample
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Point In Triangle", 800, 600);
            Triangle triangle = SplashKit.TriangleFrom(700, 200, 500, 1, 200, 500);
            Point2D mousePt;
            string text;
            Color triangleClr;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                mousePt = SplashKit.MousePosition();

                // Update text and triangle colour based on the mouse position in relation to the triangle
                if (SplashKit.PointInTriangle(mousePt, triangle))
                {
                    triangleClr = SplashKit.ColorRed();
                    text = "Point in the triangle!";
                }
                else
                {
                    triangleClr = SplashKit.ColorGreen();
                    text = "Point not in the triangle!";
                }

                SplashKit.ClearScreen();
                SplashKit.DrawTriangle(triangleClr, triangle);
                SplashKit.DrawText(text, SplashKit.ColorRed(), 100, 100);
                SplashKit.RefreshScreen();
            }
            window.Close();
        }
    }
}