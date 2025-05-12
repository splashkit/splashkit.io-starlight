using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("sprite_x", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));

// Setting the x coordinate in reference to the window
SpriteSetX(playerSprite, 300);

// Retrieve the x position
double xPosition = SpriteX(playerSprite);

ClearScreen(ColorBlack());
DrawSprite(playerSprite);
DrawText("Sprite X: " + xPosition.ToString(), ColorWhite(), 10, 10);
RefreshScreen();
Delay(5000);

CloseAllWindows();