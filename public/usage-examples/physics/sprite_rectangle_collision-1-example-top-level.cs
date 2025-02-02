using static SplashKitSDK.SplashKit;
using SplashKitSDK;

// Open a new window
OpenWindow("Bitmap Collisions", 315, 330);

// Load the bitmap
Bitmap skBmp = LoadBitmap("skbox", "skbox.png");

// Create a sprite using the bitmap
Sprite skSprite = CreateSprite(skBmp);

// Define sprite and rectangle positions
Point2D skSpriteLoc = PointAt(50, 50);
SpriteSetPosition(skSprite, skSpriteLoc);

// Define the rectangles
Rectangle testRectangle1 = RectangleFrom(20, 20, 20, 20);
Rectangle testRectangle2 = RectangleFrom(150, 200, 20, 20);

// Clear the screen and draw elements
ClearScreen(ColorWhite());
DrawSprite(skSprite);
FillRectangle(ColorBlack(), testRectangle1);
FillRectangle(ColorRed(), testRectangle2);

// Check for collisions
if (SpriteRectangleCollision(skSprite, testRectangle1))
    WriteLine("Black Rectangle Collision");
if (SpriteRectangleCollision(skSprite, testRectangle2))
    WriteLine("Red Rectangle Collision");

// Refresh the screen and delay before closing
RefreshScreen();
Delay(4000);

CloseAllWindows();