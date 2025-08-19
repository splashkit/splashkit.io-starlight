using SplashKitSDK;

namespace SpriteYExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("spriteY", 600, 600);

            SplashKit.LoadBitmap("player", "player-run.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));

            // Setting the x and y coordinate in reference to the window
            playerSprite.X = 300;
            playerSprite.Y = 300;

            // Retrieve the y position
            double yPosition = SplashKit.SpriteY(playerSprite);

            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawSprite(playerSprite);
            SplashKit.DrawText("Sprite Y: " + yPosition.ToString(), Color.White, 10, 10);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}