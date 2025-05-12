using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("sprite_set_x", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));

// Setting the x coordinate in reference to the window
SpriteSetX(playerSprite, 300);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(5000);

CloseAllWindows();