using SplashKitSDK;

namespace StopMusicExample
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

            // Load music file
            Music music = SplashKit.LoadMusic("adventure", "time_for_adventure.mp3");
            music.Play();

            Window window = SplashKit.OpenWindow("Stop/Start", 300, 200);


            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Check for stop/play request
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (SplashKit.MusicPlaying())
                    {
                        // Stop if playing
                        SplashKit.StopMusic();
                    }
                    else
                    {
                        // Play if stopped
                        music.Play();
                    }
                }

                // Display text showing if music is playing or not
                window.Clear(Color.White);
                if (SplashKit.MusicPlaying())
                {
                    window.DrawText("Music Playing", Color.Black, 100, 100);
                }
                else
                {
                    window.DrawText("Music Stopped", Color.Black, 100, 100);
                }
                window.Refresh();
            }

            // Cleanup
            SplashKit.FreeAllMusic();
        }
    }
}