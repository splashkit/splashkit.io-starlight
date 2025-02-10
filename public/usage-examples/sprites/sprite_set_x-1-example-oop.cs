using SplashKitSDK;

namespace SpriteSetXExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("sprite_set_x", 600, 600);

            SplashKit.LoadBitmap("player", "player-run.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));

            // Setting the x coordinate in reference to the window
            SplashKit.SpriteSetX(playerSprite, 300);

            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawSprite(playerSprite);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}