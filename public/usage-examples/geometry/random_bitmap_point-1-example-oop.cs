using SplashKitSDK;

namespace RandomBitmapPointExample
{
    public class Program
    {
        public static void Main()
        {
            // Create Window and empty bitmap
            Window window = new Window("Random Bitmap Points with Triangles", 600, 600);
            Bitmap bmp = new Bitmap("Random Triangles", 600, 600);

            for (int i = 0; i < 10; i++)
            {
                // Create triangle using random points on bitmap
                Triangle triangle = SplashKit.TriangleFrom(
                    SplashKit.RandomBitmapPoint(bmp),
                    SplashKit.RandomBitmapPoint(bmp),
                    SplashKit.RandomBitmapPoint(bmp));

                bmp.FillTriangle(Color.Random(), triangle);
            }

            // Draw the bitmap
            window.Clear(Color.WhiteSmoke);
            window.DrawBitmap(bmp, 0, 0);
            window.Refresh();

            SplashKit.Delay(5000);
            window.Close();
        }
    }
}