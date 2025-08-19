using static SplashKit.SplashKit;

OpenWindow("Sprite Width Example", 800, 600);

// Load bitmap and create sprite
Bitmap playerBitmap = LoadBitmap("player", "player.png");
Sprite playerSprite = CreateSprite(playerBitmap);

// Get sprite width
int width = SpriteWidth(playerSprite);

// Main game loop
while (!QuitRequested())
{
    ProcessEvents();
    ClearScreen(Color.White);
    
    // Draw sprite and display width
    DrawSprite(playerSprite, 100, 100);
    DrawText($"Sprite Width: {width}", Color.Black, 50, 50);
    
    RefreshScreen(60);
}

CloseAllWindows();
