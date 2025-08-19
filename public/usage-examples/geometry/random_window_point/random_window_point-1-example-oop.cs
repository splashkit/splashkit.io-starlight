using SplashKitSDK;

namespace RandomWindowPointExample
{
    public class Program
    {
        public static void Main()
        {   
            // Create Window
            Window Window = SplashKit.OpenWindow("Portal", 600, 600);

            // Load portal sprites
            Bitmap BluePortal = new Bitmap("BluePortal", "bluePortal.png");
            Bitmap OrangePortal = new Bitmap("OrangePortal", "orangePortal.png");
            Sprite BluePortalSprite = SplashKit.CreateSprite(BluePortal);
            Sprite OrangePortalSprite = SplashKit.CreateSprite(OrangePortal);

            // Set random portal location
            BluePortalSprite.Position = SplashKit.RandomWindowPoint(Window);
            OrangePortalSprite.Position = SplashKit.RandomWindowPoint(Window);
            
            Window.Clear(Color.Black);

            // Draw the sprite
            SplashKit.DrawSprite(BluePortalSprite);
            SplashKit.DrawSprite(OrangePortalSprite);

            Window.Refresh();
            SplashKit.Delay(5000);
            Window.Close();
        }
    }
}