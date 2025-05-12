using SplashKitSDK;

namespace SpriteSetVelocityExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("sprite-set-velocity", 600, 600);

            SplashKit.LoadBitmap("player", "player-run.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));
            SplashKit.SpriteSetX(playerSprite, 300);
            SplashKit.SpriteSetY(playerSprite, 300);

            // Create vector for sprite's velocity
            Vector2D vel = SplashKit.VectorTo(0.01, 0);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Set sprite velocity and update sprite
                SplashKit.SpriteSetVelocity(playerSprite, vel);
                SplashKit.UpdateSprite(playerSprite);

                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawSprite(playerSprite);
                SplashKit.RefreshScreen();
            }

            SplashKit.CloseAllWindows();
        }
    }
}