using SplashKitSDK;

namespace BitmapBoundingCircleExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Bitmap Bounding Circle", 800, 600);

            Bitmap vertical_bitmap = SplashKit.LoadBitmap("vertical_bitmap", "image1.png");
            Bitmap horizontal_bitmap = SplashKit.LoadBitmap("horizontal_bitmap", "image2.png");

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