using SplashKitSDK;
using static SplashKitSDK.SplashKit; 

OpenWindow("create_sprite", 600, 600);

// Load the bitmap for creating a sprite
Bitmap player = LoadBitmap("player_bitmap", "player.png");

// Create the player sprite
Sprite playerSprite = CreateSprite(player);

SpriteSetX(playerSprite, 300);
SpriteSetY(playerSprite, 300);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(5000);

CloseAllWindows();