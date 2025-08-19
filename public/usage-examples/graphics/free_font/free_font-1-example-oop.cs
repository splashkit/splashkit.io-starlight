using SplashKitSDK;

namespace FreeFontExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Freeing Fonts", 800, 200);
            Font bebasNeue = SplashKit.LoadFont("BebasNeue", "BebasNeue.ttf");

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen();
                if (SplashKit.HasFont(bebasNeue))
                {
                    SplashKit.DrawText("Using BebasNeue Font: Press Space bar to free font", Color.Black, bebasNeue, 30, 20, 50);
                }
                else
                {
                    SplashKit.DrawText("Using System Font: BebasNeue font has been freed", Color.Black, SplashKit.GetSystemFont(), 30, 20, 50);
                    SplashKit.DrawText("Press Space bar to load BebasNeue font again", Color.Black, SplashKit.GetSystemFont(), 30, 20, 100);
                }
                SplashKit.RefreshScreen();

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // If the font is loaded, it is freed
                    // If the font has been free, it is loaded again
                    if (SplashKit.HasFont(bebasNeue))
                    {
                        SplashKit.FreeFont(bebasNeue);
                    }
                    else
                    {
                        bebasNeue = SplashKit.LoadFont("BebasNeue", "BebasNeue.ttf");
                    }
                }
            }

            // Clean up
            if (SplashKit.HasFont(bebasNeue))
            {
                SplashKit.FreeFont(bebasNeue);
            }
            SplashKit.CloseAllWindows();
        }
    }
}