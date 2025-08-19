using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create Window and empty bitmap
OpenWindow("Random Bitmap Points with Triangles", 600, 600);
Bitmap bmp = CreateBitmap("Random Triangles", 600, 600);

for (int i = 0; i < 10; i++)
{
    // Create triangle using random points on bitmap
    Triangle triangle = TriangleFrom(
        RandomBitmapPoint(bmp),
        RandomBitmapPoint(bmp),
        RandomBitmapPoint(bmp));

    FillTriangleOnBitmap(bmp, RandomColor(), triangle);
}

// Draw the bitmap
ClearScreen(ColorWhiteSmoke());
DrawBitmap(bmp, 0, 0);
RefreshScreen();

Delay(5000);
CloseAllWindows();