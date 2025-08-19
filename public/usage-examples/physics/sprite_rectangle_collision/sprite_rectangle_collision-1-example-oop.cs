using SplashKitSDK;

namespace SpriteRectangleCollisionExample
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

            // Define sprite and rectangle positions
            Point2D skSpriteLoc = new Point2D() { X = 50, Y = 50 };
            SplashKit.SpriteSetPosition(skSprite, skSpriteLoc);

            // Define the rectangles
            Rectangle testRectangle1 = new Rectangle() { X = 20, Y = 20, Width = 20, Height = 20 };
            Rectangle testRectangle2 = new Rectangle() { X = 150, Y = 200, Width = 20, Height = 20 };

            // Clear the screen and draw elements
            SplashKit.ClearScreen(SplashKit.ColorWhite());
            SplashKit.DrawSprite(skSprite);
            SplashKit.FillRectangle(SplashKit.ColorBlack(), testRectangle1);
            SplashKit.FillRectangle(SplashKit.ColorRed(), testRectangle2);

            // Check for collisions
            if (SplashKit.SpriteRectangleCollision(skSprite, testRectangle1))
                SplashKit.WriteLine("Black Rectangle Collision");
            if (SplashKit.SpriteRectangleCollision(skSprite, testRectangle2))
                SplashKit.WriteLine("Red Rectangle Collision");

            // Refresh the screen and delay before closing
            SplashKit.RefreshScreen();
            SplashKit.Delay(4000);

            SplashKit.CloseAllWindows();
        }
    }
}