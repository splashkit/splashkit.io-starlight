using SplashKitSDK;

namespace FillTriangleOnBitmapExample
{
    public class Program
    {
        public static void Main()
        {
            //Open a Window
            SplashKit.OpenWindow("Happy Hat", 618, 618);

            //Load the bitmaps for sad and smiling emojis (https://openmoji.org/library/#group=smileys-emotion)
            Bitmap sadEmoji = SplashKit.LoadBitmap("sad_emoji", "sad_emoji.png");
            Bitmap smilingEmoji = SplashKit.LoadBitmap("smiling_emoji", "smiling_emoji.png");

            // Draw the sad emoji and add a hat
            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawBitmap(sadEmoji, 0, 0);
            SplashKit.RefreshScreen();
            SplashKit.Delay(1000);

            // Draw a triangle hat on the smiling emoji
            // SplashKit.FillTriangleOnBitmap(smilingEmoji, Color.Red, 100, 200, 309, 20, 520, 200);
            smilingEmoji.FillTriangle(Color.Red, 100, 200, 309, 20, 520, 200);
            
            // Clear Screen and switch to smiling emoji
            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawBitmap(smilingEmoji, 0, 0);
            SplashKit.RefreshScreen();
            SplashKit.Delay(1000);

            // Spin the smiling emoji with the hat
            for (int i = 0; i < 360; i++)
            {
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(smilingEmoji, 0, 0, SplashKit.OptionRotateBmp(i));
                SplashKit.RefreshScreen();
                SplashKit.Delay(10);
            }

            // Free the bitmap resource
            SplashKit.FreeAllBitmaps();
            // CLose all windows
            SplashKit.CloseAllWindows();

        }
    }
}