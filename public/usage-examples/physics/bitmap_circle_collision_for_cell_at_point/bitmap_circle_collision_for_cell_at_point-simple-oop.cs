using static SplashKitSDK.SplashKit;
using SplashKitSDK;

namespace BitmapCollisionsApp
{
    public class Program
    {
        public static void Main()
        {
            OpenWindow("Bitmap Collisions", 315, 330);

            Bitmap skBmp = LoadBitmap("skbox", "skbox.png");
            Point2D bmpLoc = new Point2D() { X = 50, Y = 50 };

            Circle blackCircle = new Circle()
            {
                Center = new Point2D() { X = 20, Y = 20 },
                Radius = 20
            };

            Circle redCircle = new Circle()
            {
                Center = new Point2D() { X = 150, Y = 150 },
                Radius = 20
            };

            ClearScreen(RGBColor(67, 80, 175));
            DrawBitmap(skBmp, bmpLoc.X, bmpLoc.Y);
            DrawCircle(ColorBlack(), blackCircle);
            DrawCircle(ColorRed(), redCircle);

            if (BitmapCircleCollision(skBmp, 50, bmpLoc, blackCircle))
            {
                WriteLine("Black Circle Collision!");
            }

            if (BitmapCircleCollision(skBmp, 50, bmpLoc, redCircle))
            {
                WriteLine("Red Circle Collision!");
            }

            RefreshScreen();

            Delay(4000);

            CloseAllWindows();
        }
    }
}
