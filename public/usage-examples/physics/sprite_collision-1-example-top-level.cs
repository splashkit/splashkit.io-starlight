using static SplashKitSDK.SplashKit;
using SplashKitSDK;

// Open a new window
OpenWindow("Bitmap Collisions", 315, 330);

// Load the bitmaps
Bitmap skBmp = LoadBitmap("skbox", "skbox.png");
Bitmap fileBmp = LoadBitmap("file", "file_image.png");
Bitmap bugBmp = LoadBitmap("bug", "bug_image.png");

// Create sprites from the bitmaps
Sprite skSprite = CreateSprite(skBmp);
Sprite fileSprite = CreateSprite(fileBmp);
Sprite bugSprite = CreateSprite(bugBmp);

// Define sprite positions
Point2D skSpriteLoc = PointAt(50, 50);
Point2D fileSpriteLoc = PointAt(20, 20);
Point2D bugSpriteLoc = PointAt(200, 150);

// Set sprite positions
SpriteSetPosition(skSprite, skSpriteLoc);
SpriteSetPosition(fileSprite, fileSpriteLoc);
SpriteSetPosition(bugSprite, bugSpriteLoc);

// Clear the screen and draw sprites
ClearScreen(ColorWhite());
DrawSprite(skSprite);
DrawSprite(fileSprite);
DrawSprite(bugSprite);

// Check for collisions
if (SpriteCollision(skSprite, fileSprite))
    WriteLine("SplashKit got a new file!");

if (SpriteCollision(skSprite, bugSprite))
    WriteLine("SplashKit has bugs!");

// Refresh the screen and delay before closing
RefreshScreen();
Delay(4000);

CloseAllWindows();