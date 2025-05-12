using SplashKitSDK;

namespace SpritePointCollisionExample
{
    public class Program
    {
        public static void Main()
        {
            // Open a new window
            SplashKit.OpenWindow("Bitmap Collisions", 315, 330);

            // Load the bitmap
            Bitmap skBmp = SplashKit.LoadBitmap("skbox", "skbox.png");

            // Create a sprite using the bitmap
            Sprite skSprite = SplashKit.CreateSprite(skBmp);

            // Define sprite and collision point positions
            Point2D skSpriteLoc = new Point2D() { X = 50, Y = 50 };
            Point2D collisionLoc1 = new Point2D() { X = 20, Y = 20 };
            Point2D collisionLoc2 = new Point2D() { X = 200, Y = 150 };

            // Set sprite position
            SplashKit.SpriteSetPosition(skSprite, skSpriteLoc);

            // Clear the screen and draw elements
            SplashKit.ClearScreen(Color.White);
            skSprite.Draw();
            SplashKit.FillCircle(Color.Black, SplashKit.CircleAt(collisionLoc1, 2));
            SplashKit.FillCircle(Color.Red, SplashKit.CircleAt(collisionLoc2, 2));

            // Check for collisions
            if (SplashKit.SpritePointCollision(skSprite, collisionLoc1))
                SplashKit.WriteLine("Black Dot Collision");
            if (SplashKit.SpritePointCollision(skSprite, collisionLoc2))
                SplashKit.WriteLine("Red Dot Collision");

            // Refresh the screen and delay before closing
            SplashKit.RefreshScreen();
            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}