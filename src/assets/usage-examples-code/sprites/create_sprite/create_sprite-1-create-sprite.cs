using SplashKitSDK;
using static SplashKitSDK.SplashKit; 

Window start = OpenWindow("create_sprite", 600, 600);

// Load the bitmap for creating a sprite
Bitmap player = LoadBitmap("player_bitmap", "player.png");

// Create the player sprite
Sprite playerSprite = CreateSprite(player);

playerSprite.X = 300;
playerSprite.Y = 300;

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
RefreshScreen();
Delay(5000);
CloseAllWindows();