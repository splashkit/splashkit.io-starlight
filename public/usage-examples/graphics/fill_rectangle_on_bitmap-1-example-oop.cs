using SplashKitSDK;

namespace FillRectangleOnBitmapExample
{
    public class Program
    {
        public static void Main()
        {
            // Create a new window with title and dimensions 
            SplashKit.OpenWindow("Night Sky", 500, 533);
            // Create and load new bitmap using the picture file and initialise new bitmap variable
            Bitmap night_sky = SplashKit.LoadBitmap("night_sky", "sky.jpg"); 

            // Create black rectangles for buildings, with x and y axis and dimensions  
            SplashKit.FillRectangleOnBitmap(night_sky, Color.Black, 40, 200, 100, 400); // Building 1
            SplashKit.FillRectangleOnBitmap(night_sky, Color.Black, 200, 400, 100, 400); // Building 2
            SplashKit.FillRectangleOnBitmap(night_sky, Color.Black, 350, 300, 100, 300); // Building 3

            // For loop to create the illumimated windows on each building with different numbers depending 
            // on the placement of the building
            // Building 1
            for (int j = 220; j < 700; j += 50)
            {
                for (int i = 55; i < 135; i += 20)
                {
                    SplashKit.FillRectangleOnBitmap(night_sky, Color.Orange, i, j, 10, 20);
                }
            }

            // Building 2
            for (int j = 420; j < 570; j += 50)
            {
                for (int i = 215; i < 295; i += 20)
                {
                    SplashKit.FillRectangleOnBitmap(night_sky, Color.Yellow, i, j, 10, 20);
                }
            }

            // Building 3
            for (int j = 320; j < 700; j += 50)
            {
                for (int i = 365; i < 440; i += 20)
                {
                    SplashKit.FillRectangleOnBitmap(night_sky, Color.Orange, i, j, 10, 20);
                }
            }

            // Clear screen and draw bitmap
            SplashKit.ClearScreen();
            SplashKit.DrawBitmap(night_sky, 0, 0);
            SplashKit.RefreshScreen();
            SplashKit.Delay(5000);

            // Free resources and close window/s 
            SplashKit.FreeAllBitmaps();
            SplashKit.CloseAllWindows();
        }
    }
}