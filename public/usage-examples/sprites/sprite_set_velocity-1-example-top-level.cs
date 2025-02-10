using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("sprite-set-velocity", 600, 600);

LoadBitmap("player", "player-run.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));
SpriteSetX(playerSprite, 300);
SpriteSetY(playerSprite, 300);

// Create vector for sprite's velocity
Vector2D vel = VectorTo(0.01,0);

while (!QuitRequested())
{
    ProcessEvents();

    // Set sprite velocity and update sprite
    SpriteSetVelocity(playerSprite, vel);
    UpdateSprite(playerSprite);

    ClearScreen(ColorBlack());
    DrawSprite(playerSprite);
    RefreshScreen();
}

CloseAllWindows();