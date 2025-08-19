using SplashKitSDK;

namespace BitmapBoundingCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Bitmap Bounding Circle", 800, 600);

            Bitmap vertical_bitmap = SplashKit.LoadBitmap("vertical_bitmap", "image1.jpeg");
            Bitmap horizontal_bitmap = SplashKit.LoadBitmap("horizontal_bitmap", "image2.png");

            // The 'bitmap_bounding_circle' function creates a circle with a circumference that encompasses the four vertices of it's associated bitmap
            // A Point2D is also given to determine the circle's position
            Circle vert_bitmap_circle = SplashKit.BitmapBoundingCircle(vertical_bitmap, SplashKit.PointAt(210, 210));
            Circle hori_bitmap_circle = SplashKit.BitmapBoundingCircle(horizontal_bitmap, SplashKit.PointAt(580, 400));

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                SplashKit.DrawBitmap(vertical_bitmap, 141, 60);
                SplashKit.DrawBitmap(horizontal_bitmap, 480, 344);

                SplashKit.DrawCircle(Color.Black, vert_bitmap_circle);
                SplashKit.DrawCircle(Color.Black, hori_bitmap_circle);

                SplashKit.RefreshScreen();
            }
            SplashKit.CloseAllWindows();
        }
    }
}