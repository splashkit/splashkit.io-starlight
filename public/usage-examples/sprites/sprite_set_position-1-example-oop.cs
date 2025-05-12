using SplashKitSDK;

namespace SpriteSetPosition
{
  public class Program
  {
    public static void Main()
    {
      SplashKit.OpenWindow("sprite_set_position", 600, 600);

      SplashKit.LoadBitmap("player", "player-run.png");
      Sprite playerSprite = SplashKit.CreateSprite(SplashKit.BitmapNamed("player"));
      SplashKit.SpriteSetX(playerSprite, 200);
      SplashKit.SpriteSetY(playerSprite, 300);

      SplashKit.ClearScreen(SplashKit.ColorBlack());
      SplashKit.DrawSprite(playerSprite);
      SplashKit.RefreshScreen();
      SplashKit.Delay(2000);

      // Create Point2D object which stores the new coordinates
      Point2D pos = SplashKit.PointAt(450, 300);

      // Set the new sprite position
      SplashKit.SpriteSetPosition(playerSprite, pos);

      SplashKit.ClearScreen(SplashKit.ColorBlack());
      SplashKit.DrawSprite(playerSprite);
      SplashKit.RefreshScreen();
      SplashKit.Delay(5000);

      SplashKit.CloseAllWindows();
    }
  }
}