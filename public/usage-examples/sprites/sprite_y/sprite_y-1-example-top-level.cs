using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("spriteY", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));

// Setting the x and y coordinate in reference to the window
SpriteSetX(playerSprite, 300);
SpriteSetY(playerSprite, 300);

// Retrieve the y position
double yPosition = SpriteY(playerSprite);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
DrawText("Sprite Y: " + yPosition.ToString(), ColorWhite(), 10, 10);
RefreshScreen();
Delay(5000);

CloseAllWindows();