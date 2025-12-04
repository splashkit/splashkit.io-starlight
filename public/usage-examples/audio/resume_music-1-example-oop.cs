using SplashKitSDK;

namespace ResumeMusicExample
{
    public static class Program
    {
        public static void Main()
        {
            // Check if audio is ready to use
            if (!SplashKit.AudioReady())
            {
                SplashKit.OpenAudio();
            }

            // Load music file and start playing
            Music music = SplashKit.LoadMusic("Adventure", "time_for_adventure.mp3");
            music.Play();

            Window window = SplashKit.OpenWindow("Pause/Resume", 300, 200);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Check for pause/play request
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // Check if music is paused or not
                    if (SplashKit.MusicPlaying())
                    {
                        // Pause if playing
                        SplashKit.PauseMusic();
                    }
                    else
                    {
                        // Play if paused
                        SplashKit.ResumeMusic();
                    }
                }

                // Display text showing if music is playing or not
                window.Clear(Color.White);
                if (SplashKit.MusicPaused())
                {
                    window.DrawText("Paused...", Color.Black, 100, 100);
                }
                else
                {
                    window.DrawText("Playing", Color.Black, 100, 100);
                }
                window.Refresh();
            }

            // Cleanup
            SplashKit.FreeAllMusic();
            SplashKit.CloseAllWindows();
        }
    }
}