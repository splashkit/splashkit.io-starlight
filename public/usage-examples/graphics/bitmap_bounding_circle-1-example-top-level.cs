using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Bitmap Bounding Circle", 800, 600);

Bitmap vertical_bitmap = LoadBitmap("vertical_bitmap", "image1.jpeg");
Bitmap horizontal_bitmap = LoadBitmap("horizontal_bitmap", "image2.png");

Circle vert_bitmap_circle = BitmapBoundingCircle(vertical_bitmap, PointAt(210, 210));
Circle hori_bitmap_circle = BitmapBoundingCircle(horizontal_bitmap, PointAt(580, 400));

while (!QuitRequested())
{
    ProcessEvents();
    ClearScreen(ColorWhite());

    DrawBitmap(vertical_bitmap, 141, 60);
    DrawBitmap(horizontal_bitmap, 480, 344);

    DrawCircle(ColorBlack(), vert_bitmap_circle);
    DrawCircle(ColorBlack(), hori_bitmap_circle);

    RefreshScreen();
}
CloseAllWindows();