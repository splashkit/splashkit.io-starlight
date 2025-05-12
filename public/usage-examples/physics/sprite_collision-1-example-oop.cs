using SplashKitSDK;

namespace SpriteCollisionExample
{
    public class Program
    {
        public static void Main()
        {
            // Open a new window
            SplashKit.OpenWindow("Bitmap Collisions", 315, 330);

            // Load the bitmaps
            Bitmap skBmp = SplashKit.LoadBitmap("skbox", "skbox.png");
            Bitmap fileBmp = SplashKit.LoadBitmap("file", "file_image.png");
            Bitmap bugBmp = SplashKit.LoadBitmap("bug", "bug_image.png");

            // Create sprites from the bitmaps
            Sprite skSprite = SplashKit.CreateSprite(skBmp);
            Sprite fileSprite = SplashKit.CreateSprite(fileBmp);
            Sprite bugSprite = SplashKit.CreateSprite(bugBmp);

            // Define sprite positions
            Point2D skSpriteLoc = new Point2D() { X = 50, Y = 50 };
            Point2D fileSpriteLoc = new Point2D() { X = 20, Y = 20 };
            Point2D bugSpriteLoc = new Point2D() { X = 200, Y = 150 };

            // Set sprite positions
            SplashKit.SpriteSetPosition(skSprite, skSpriteLoc);
            SplashKit.SpriteSetPosition(fileSprite, fileSpriteLoc);
            SplashKit.SpriteSetPosition(bugSprite, bugSpriteLoc);

            // Clear the screen and draw sprites
            SplashKit.ClearScreen(Color.White);
            SplashKit.DrawSprite(skSprite);
            SplashKit.DrawSprite(fileSprite);
            SplashKit.DrawSprite(bugSprite);

            // Check for collisions
            if (SplashKit.SpriteCollision(skSprite, fileSprite))
                SplashKit.WriteLine("SplashKit got a new file!");

            if (SplashKit.SpriteCollision(skSprite, bugSprite))
                SplashKit.WriteLine("SplashKit has bugs!");

            // Refresh the screen and delay before closing
            SplashKit.RefreshScreen();
            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}