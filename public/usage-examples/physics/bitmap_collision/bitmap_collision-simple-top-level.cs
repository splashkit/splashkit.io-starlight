using SplashKitSDK;

// Open the window
SplashKit.OpenWindow("Bitmap Collisions", 315, 330);

// Load the bitmaps
Bitmap skBmp = SplashKit.LoadBitmap("skbox", "skbox.png");
Bitmap fileBmp = SplashKit.LoadBitmap("file", "file_image.png");
Bitmap bugBmp = SplashKit.LoadBitmap("bug", "bug_image.png");

// Set the bitmap locations
Point2D skBmpLoc = new Point2D() { X = 50, Y = 50 };
Point2D fileBmpLoc = new Point2D() { X = 20, Y = 20 };
Point2D bugBmpLoc = new Point2D() { X = 200, Y = 150 };

// Clear the screen and draw the bitmaps
SplashKit.ClearScreen(Color.White);
SplashKit.DrawBitmap(skBmp, skBmpLoc.X, skBmpLoc.Y);
SplashKit.DrawBitmap(fileBmp, fileBmpLoc.X, fileBmpLoc.Y);
SplashKit.DrawBitmap(bugBmp, bugBmpLoc.X, bugBmpLoc.Y);

// Check for collisions
if (SplashKit.BitmapCollision(skBmp, skBmpLoc.X, skBmpLoc.Y, fileBmp, fileBmpLoc.X, fileBmpLoc.Y))
{
    SplashKit.WriteLine("SplashKit got a new file!");
}

if (SplashKit.BitmapCollision(skBmp, skBmpLoc.X, skBmpLoc.Y, bugBmp, bugBmpLoc.X, bugBmpLoc.Y))
{
    SplashKit.WriteLine("SplashKit has bugs!");
}

// Refresh the screen and wait
SplashKit.RefreshScreen();
SplashKit.Delay(4000);

// Close all windows
SplashKit.CloseAllWindows();
