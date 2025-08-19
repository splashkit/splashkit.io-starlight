using static SplashKit.SplashKit;

OpenWindow("Animation Demo", 800, 600);

// Load animation script
LoadAnimationScript("player", "player.txt");

// Create animation
Animation playerAnim = CreateAnimation("player", "WalkFront");

// Main game loop
while (!QuitRequested())
{
    ProcessEvents();
    ClearScreen(Color.White);
    
    // Update and draw animation
    UpdateAnimation(playerAnim);
    DrawAnimation(playerAnim, 400, 300);
    
    RefreshScreen(60);
}

CloseAllWindows();
