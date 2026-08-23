using SplashKitSDK;

namespace BitmapCenterExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Bitmap Center", 800, 600);

            Bitmap imageBitmap = SplashKit.LoadBitmap("image_bitmap", "image1.jpg");
            Point2D centerPoint = SplashKit.BitmapCenter(imageBitmap);

            SplashKit.ClearScreen(Color.White);
            SplashKit.DrawBitmap(imageBitmap, 0, 0);
            SplashKit.FillCircle(Color.Red, SplashKit.CircleAt(centerPoint, 5));
            SplashKit.RefreshScreen();

            SplashKit.Delay(5000);

            SplashKit.CloseAllWindows();
        }
    }
}