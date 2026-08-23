using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Bitmap Center", 800, 600);

Bitmap imageBitmap = LoadBitmap("image_bitmap", "image1.jpg");
Point2D centerPoint = BitmapCenter(imageBitmap);

ClearScreen(ColorWhite());
DrawBitmap(imageBitmap, 0, 0);
FillCircle(ColorRed(), CircleAt(centerPoint, 5));
RefreshScreen();

Delay(5000);

CloseAllWindows();