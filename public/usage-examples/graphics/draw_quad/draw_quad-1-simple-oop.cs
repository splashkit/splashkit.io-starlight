using SplashKitSDK;

namespace DrawQuadExample
{
    public class Program
    {
        public static void Main()
        {
            // Create 4 diamond shapes using quads
            Quad q1 = SplashKit.QuadFrom(400, 200, 300, 300, 300, 0, 200, 200);
            Quad q2 = SplashKit.QuadFrom(400, 210, 310, 300, 600, 300, 400, 390);
            Quad q3 = SplashKit.QuadFrom(200, 400, 300, 300, 300, 600, 400, 400);
            Quad q4 = SplashKit.QuadFrom(200, 390, 290, 300, 0, 300, 200, 210);

            SplashKit.OpenWindow("Ninja Star", 600, 600);
            SplashKit.ClearScreen(Color.White);

            // Draw the quads
            SplashKit.DrawQuad(Color.Black, q1);
            SplashKit.DrawQuad(Color.Green, q2);
            SplashKit.DrawQuad(Color.Red, q3);
            SplashKit.DrawQuad(Color.Blue, q4);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}
