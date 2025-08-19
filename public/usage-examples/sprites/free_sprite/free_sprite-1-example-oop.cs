using SplashKitSDK;

namespace FreeSpriteExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Free Sprite Memory Resource", 600, 600);

            SplashKit.LoadBitmap("player", "player.png");
            Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));
            SplashKit.SpriteSetX(playerSprite, 300);
            SplashKit.SpriteSetY(playerSprite, 300);

            bool spriteExists = true; // Track if the sprite exists

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen(Color.Black);
                if (spriteExists)
                {
                    SplashKit.DrawSprite(playerSprite);
                    SplashKit.UpdateSprite(playerSprite);
                }
                SplashKit.RefreshScreen();

                // If UP key is typed, the sprite is removed
                if (spriteExists && SplashKit.KeyTyped(KeyCode.UpKey))
                {
                    SplashKit.FreeSprite(playerSprite);
                    spriteExists = false; // Set bool to false to stop drawing/updating
                }
            }

            // Clean up
            if (spriteExists)
            {
                SplashKit.FreeSprite(playerSprite);
            }

            SplashKit.CloseAllWindows();
        }
    }
}