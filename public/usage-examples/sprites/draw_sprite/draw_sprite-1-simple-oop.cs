using SplashKitSDK;

namespace DrawSpriteExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("draw_sprite", 600, 600);

            SplashKit.LoadBitmap("player", "player.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));
            SplashKit.SpriteSetX(playerSprite, 300);
            SplashKit.SpriteSetY(playerSprite, 300);
            SplashKit.ClearScreen(SplashKit.ColorBlack());

            // Draw the sprite
            SplashKit.DrawSprite(playerSprite);

            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);
            SplashKit.CloseAllWindows();
        }
    }
}
