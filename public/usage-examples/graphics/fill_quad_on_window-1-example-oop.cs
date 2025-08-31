using SplashKitSDK;

namespace FillQuadOnWindowExample
{
    public class Program
    {
        public static void Main()
        {
            // Create diamond shaped quads
            Quad q1 = SplashKit.QuadFrom(400, 200, 300, 300, 300, 0, 200, 200);
            Quad q2 = SplashKit.QuadFrom(400, 210, 310, 300, 600, 300, 400, 390);
            Quad q3 = SplashKit.QuadFrom(200, 400, 300, 300, 300, 600, 400, 400);
            Quad q4 = SplashKit.QuadFrom(200, 390, 290, 300, 0, 300, 200, 210);

            // Create two Windows
            Window window1 = new Window("Filled Diamond On Window 1", 600, 600);
            Window window2 = new Window("Filled Diamond On Window 2", 600, 600);

            // Move windows to see both side by side
            window1.MoveTo(0, 0);
            window2.MoveTo(window1.Width, 0);

            SplashKit.ClearScreen(Color.White);

            // Draw the first and second quad on first window
            window1.FillQuad(Color.Black, q1);
            window1.FillQuad(Color.Green, q2);

            // Draw the third and fourth quad on second window
            window2.FillQuad(Color.Red, q3);
            window2.FillQuad(Color.Blue, q4);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}