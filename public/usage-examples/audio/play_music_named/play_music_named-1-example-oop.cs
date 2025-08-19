using SplashKitSDK;

namespace PlayMusicExample
{
    public class Program
    {
        public static void Main()
        {
            // Check if audio is ready to use
            if (!SplashKit.AudioReady())
            {
                SplashKit.OpenAudio();
            }

            // Load music file
            SplashKit.LoadMusic("adventure", "time_for_adventure.mp3");

            // Start music playback
            SplashKit.PlayMusic("adventure");

            // Hold program for 10 seconds
            SplashKit.Delay(10000);

            // Free resources
            SplashKit.FreeAllMusic();
        }
    }
}