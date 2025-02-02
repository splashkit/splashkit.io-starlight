using SplashKitSDK;

namespace SpriteBitmapCollisionExample
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

            // Create a sprite using the bitmap
            Sprite skSprite = SplashKit.CreateSprite(skBmp);

            // Define positions
            Point2D skSpriteLoc = new Point2D() { X = 50, Y = 50 };
            Point2D fileBmpLoc = new Point2D() { X = 20, Y = 20 };
            Point2D bugBmpLoc = new Point2D() { X = 200, Y = 150 };

            // Set sprite position
            SplashKit.SpriteSetPosition(skSprite, skSpriteLoc);

            // Clear the screen and draw all elements
            SplashKit.ClearScreen(Color.White);
            SplashKit.DrawSprite(skSprite);
            SplashKit.DrawBitmap(fileBmp, fileBmpLoc.X, fileBmpLoc.Y);
            SplashKit.DrawBitmap(bugBmp, bugBmpLoc.X, bugBmpLoc.Y);

            // Check for collisions
            if (SplashKit.SpriteBitmapCollision(skSprite, fileBmp, fileBmpLoc.X, fileBmpLoc.Y))
                SplashKit.WriteLine("SplashKit got a new file!");

            if (SplashKit.SpriteBitmapCollision(skSprite, bugBmp, bugBmpLoc.X, bugBmpLoc.Y))
                SplashKit.WriteLine("SplashKit has bugs!");

            // Refresh the screen and delay before closing
            SplashKit.RefreshScreen();
            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}