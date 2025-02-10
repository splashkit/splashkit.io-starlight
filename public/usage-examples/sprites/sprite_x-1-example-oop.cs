using SplashKitSDK;

namespace SpriteXExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("sprite_x", 600, 600);

            SplashKit.LoadBitmap("player", "player-run.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));

            // Setting the x coordinate in reference to the window
            playerSprite.X = 300;

            // Retrieve the x position
            double xPosition = SplashKit.SpriteX(playerSprite);

            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawSprite(playerSprite);
            SplashKit.DrawText("Sprite X: " + xPosition.ToString(), Color.White, 10, 10);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}