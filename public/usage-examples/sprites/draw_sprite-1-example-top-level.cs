using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Drawing a Player Sprite", 600, 600);

LoadBitmap("player", "player.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));
SpriteSetX(playerSprite, 300);
SpriteSetY(playerSprite, 300);

ClearScreen(ColorBlack());

// Draw the sprite
DrawSprite(playerSprite);

RefreshScreen();
Delay(5000);
CloseAllWindows();