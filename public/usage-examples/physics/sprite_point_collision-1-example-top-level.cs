using static SplashKitSDK.SplashKit;
using SplashKitSDK;

// Open a new window
OpenWindow("Bitmap Collisions", 315, 330);

// Load the bitmap
Bitmap skBmp = LoadBitmap("skbox", "skbox.png");

// Create a sprite using the bitmap
Sprite skSprite = CreateSprite(skBmp);

// Define sprite and collision point positions
Point2D skSpriteLoc = PointAt(50, 50);
Point2D collisionLoc1 = PointAt(20, 20);
Point2D collisionLoc2 = PointAt(200, 150);

// Set sprite position
SpriteSetPosition(skSprite, skSpriteLoc);

// Clear the screen and draw elements
ClearScreen(ColorWhite());
DrawSprite(skSprite);
FillCircle(ColorBlack(), CircleAt(collisionLoc1, 2));
FillCircle(ColorRed(), CircleAt(collisionLoc2, 2));

// Check for collisions
if (SpritePointCollision(skSprite, collisionLoc1))
    WriteLine("Black Dot Collision");
if (SpritePointCollision(skSprite, collisionLoc2))
    WriteLine("Red Dot Collision");

// Refresh the screen and delay before closing
RefreshScreen();
Delay(4000);

CloseAllWindows();