using SplashKitSDK;

namespace GUIHelloWorld
{
    public class Program
    {
        public static void Main()
        {
            // Download resources
            SplashKit.DownloadSoundEffect("Hello World", "https://programmers.guide/resources/code-examples/part-0/hello-world-snippet-saddle-club.ogg", 443);
            SplashKit.DownloadFont("main", "https://programmers.guide/resources/code-examples/part-0/Roboto-Italic.ttf", 443);
            SplashKit.DownloadBitmap("Earth", "https://programmers.guide/resources/code-examples/part-0/earth.png", 443);
            SplashKit.DownloadBitmap("SmallEarth", "https://programmers.guide/resources/code-examples/part-0/earth-small.png", 443);
            SplashKit.DownloadBitmap("SplashKitBox", "https://programmers.guide/resources/code-examples/part-0/skbox.png", 443);

            SplashKit.OpenWindow("Hello World: Using Resources with SplashKit", 800, 600);
            SplashKit.PlaySoundEffect("Hello World");

            SplashKit.ClearScreen(Color.White);
            SplashKit.DrawText("Anyone remember the \"Hello World\" Saddle Club song?", Color.Black, "main", 30, 40, 200);
            SplashKit.RefreshScreen();
            SplashKit.Delay(2500);

            SplashKit.ClearScreen(Color.White);

            // H
            SplashKit.DrawBitmap("SmallEarth", 20, 100);
            SplashKit.DrawBitmap("SmallEarth", 20, 130);
            SplashKit.DrawBitmap("SmallEarth", 20, 160);
            SplashKit.DrawBitmap("SmallEarth", 20, 190);
            SplashKit.DrawBitmap("SmallEarth", 20, 220);
            SplashKit.DrawBitmap("SmallEarth", 52, 160);
            SplashKit.DrawBitmap("SmallEarth", 84, 100);
            SplashKit.DrawBitmap("SmallEarth", 84, 130);
            SplashKit.DrawBitmap("SmallEarth", 84, 160);
            SplashKit.DrawBitmap("SmallEarth", 84, 190);
            SplashKit.DrawBitmap("SmallEarth", 84, 220);
            SplashKit.RefreshScreen();
            SplashKit.Delay(200);

            // E
            SplashKit.DrawBitmap("SmallEarth", 148, 100);
            SplashKit.DrawBitmap("SmallEarth", 148, 130);
            SplashKit.DrawBitmap("SmallEarth", 148, 160);
            SplashKit.DrawBitmap("SmallEarth", 148, 190);
            SplashKit.DrawBitmap("SmallEarth", 148, 220);
            SplashKit.DrawBitmap("SmallEarth", 180, 100);
            SplashKit.DrawBitmap("SmallEarth", 212, 100);
            SplashKit.DrawBitmap("SmallEarth", 180, 160);
            SplashKit.DrawBitmap("SmallEarth", 180, 220);
            SplashKit.DrawBitmap("SmallEarth", 212, 220);
            SplashKit.RefreshScreen();
            SplashKit.Delay(200);

            // L
            SplashKit.DrawBitmap("SmallEarth", 276, 100);
            SplashKit.DrawBitmap("SmallEarth", 276, 130);
            SplashKit.DrawBitmap("SmallEarth", 276, 160);
            SplashKit.DrawBitmap("SmallEarth", 276, 190);
            SplashKit.DrawBitmap("SmallEarth", 276, 220);
            SplashKit.DrawBitmap("SmallEarth", 308, 220);
            SplashKit.DrawBitmap("SmallEarth", 340, 220);
            SplashKit.RefreshScreen();
            SplashKit.Delay(200);

            // L
            SplashKit.DrawBitmap("SmallEarth", 404, 100);
            SplashKit.DrawBitmap("SmallEarth", 404, 130);
            SplashKit.DrawBitmap("SmallEarth", 404, 160);
            SplashKit.DrawBitmap("SmallEarth", 404, 190);
            SplashKit.DrawBitmap("SmallEarth", 404, 220);
            SplashKit.DrawBitmap("SmallEarth", 436, 220);
            SplashKit.DrawBitmap("SmallEarth", 468, 220);
            SplashKit.RefreshScreen();
            SplashKit.Delay(200);

            // O
            SplashKit.DrawBitmap("SmallEarth", 530, 160);
            SplashKit.DrawBitmap("SmallEarth", 622, 160);
            SplashKit.DrawBitmap("SmallEarth", 540, 128);
            SplashKit.DrawBitmap("SmallEarth", 560, 100);
            SplashKit.DrawBitmap("SmallEarth", 592, 100);
            SplashKit.DrawBitmap("SmallEarth", 612, 128);
            SplashKit.DrawBitmap("SmallEarth", 540, 192);
            SplashKit.DrawBitmap("SmallEarth", 560, 220);
            SplashKit.DrawBitmap("SmallEarth", 592, 220);
            SplashKit.DrawBitmap("SmallEarth", 612, 192);
            SplashKit.RefreshScreen();
            SplashKit.Delay(500);

            // World
            SplashKit.DrawBitmap("Earth", 100, 350);
            SplashKit.RefreshScreen();
            SplashKit.Delay(2000);

            // SplashKit ("Me")
            SplashKit.DrawBitmap("SplashKitBox", 450, 300);
            SplashKit.DrawText("SplashKit!", Color.Black, "main", 50, 450, 530);
            SplashKit.RefreshScreen();
            SplashKit.Delay(2000);

            SplashKit.CloseAllWindows();
        }
    }
}