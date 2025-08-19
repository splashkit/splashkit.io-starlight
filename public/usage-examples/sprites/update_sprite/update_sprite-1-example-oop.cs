using System;
using static SplashKit.SplashKit;

public class Program
{
    public static void Main()
    {
        OpenWindow("Update Sprite Example", 800, 600);
        
        // Load bitmap and animation script
        Bitmap playerBitmap = LoadBitmap("player", "player.png");
        LoadAnimationScript("player_anim", "player.txt");
        
        // Create sprite with animation
        Sprite playerSprite = CreateSprite(playerBitmap);
        SpriteStartAnimation(playerSprite, "WalkRight");
        SpriteSetVelocity(playerSprite, VectorTo(2, 0));
        
        // Main game loop
        while (!QuitRequested())
        {
            ProcessEvents();
            ClearScreen(Color.White);
            
            // Update sprite (animation and position)
            UpdateSprite(playerSprite);
            
            // Wrap sprite around screen
            if (SpriteX(playerSprite) > ScreenWidth())
                SpriteSetX(playerSprite, 0 - SpriteWidth(playerSprite));
            
            DrawSprite(playerSprite, SpriteX(playerSprite), SpriteY(playerSprite));
            
            RefreshScreen(60);
        }
        
        CloseAllWindows();
    }
}
