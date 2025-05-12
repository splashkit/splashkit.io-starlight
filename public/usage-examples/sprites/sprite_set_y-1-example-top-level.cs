using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("sprite_set_y", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));

// Setting the y coordinate in reference to the window
SpriteSetY(playerSprite, 300);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(5000);

CloseAllWindows();