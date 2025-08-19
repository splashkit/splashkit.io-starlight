using static SplashKitSDK.SplashKit;
using SplashKitSDK;

OpenWindow("Free Sprite Memory Resource", 600, 600);

LoadBitmap("player", "player.png");
Sprite playerSprite = CreateSprite(BitmapNamed("player"));
SpriteSetX(playerSprite, 300);
SpriteSetY(playerSprite, 300);

bool spriteExists = true; // Track if the sprite exists

while (!QuitRequested())
{
    ProcessEvents();

    ClearScreen(ColorBlack());
    if (spriteExists)
    {
        DrawSprite(playerSprite);
        UpdateSprite(playerSprite);
    }
    RefreshScreen();

    // If UP key is typed, the sprite is removed
    if (spriteExists && KeyTyped(KeyCode.UpKey))
    {
        FreeSprite(playerSprite);
        spriteExists = false; // Set bool to false to stop drawing/updating
    }
}

// Clean up
if (spriteExists)
{
    FreeSprite(playerSprite);
}

CloseAllWindows();