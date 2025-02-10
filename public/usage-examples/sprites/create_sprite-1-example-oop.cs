using SplashKitSDK;

namespace CreateSpriteExample
{
    public class Program
    {
        public static void Main()
        {
            Window start = SplashKit.OpenWindow("create_sprite", 600, 600);

            // Load the bitmap for creating a sprite
            Bitmap player = SplashKit.LoadBitmap("player_bitmap", "player.png");

            // Create the player sprite
            Sprite playerSprite = SplashKit.CreateSprite(player);

            playerSprite.X = 300;
            playerSprite.Y = 300;

            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawSprite(playerSprite);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}