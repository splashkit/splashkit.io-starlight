using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("sprite_set_position", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));
SpriteSetX(playerSprite, 200);
SpriteSetY(playerSprite, 300);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(2000);

// Create Point2D object which stores the new coordinates
Point2D pos = PointAt(450, 300);

// Set the new sprite position
SpriteSetPosition(playerSprite, pos);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(5000);

CloseAllWindows();