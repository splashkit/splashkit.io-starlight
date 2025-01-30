using SplashKitSDK;

namespace DelayExample
{
    public class Program
    {
        // Write a string to the console with a delay between each word
        public static void WriteWithDelay(string text, int delayTime)
        {
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                SplashKit.Write(word + " ");
                SplashKit.Delay(delayTime);
            }
            SplashKit.Write("");  // Output the last word if there’s no trailing space
        }

        public static void Main()
        {
            WriteWithDelay("Hello there stranger!\n", 200);
            SplashKit.Delay(600);

            WriteWithDelay("Oh, Hi! I didn't see you there.\n", 200);
            SplashKit.Delay(800);

            WriteWithDelay("Wait, did you just whisper that? ", 200);
            SplashKit.Delay(800);

            WriteWithDelay("Come on, let's try that again...\n", 200);
            SplashKit.Delay(1100);

            WriteWithDelay("HELLO THERE!\n", 200);
            SplashKit.Delay(600);

            WriteWithDelay("Okay, okay... I felt that!", 200);
            SplashKit.Delay(900);

            WriteWithDelay("But can you go even LOUDER?\n", 200);
            SplashKit.Delay(1100);

            WriteWithDelay("HELLOOOOOOO!\n", 200);
            SplashKit.Delay(1500);

            WriteWithDelay("Wow! That was intense. Let's cool down a bit...", 200);
            SplashKit.Delay(2100);

            WriteWithDelay("Why are we even shouting?\n", 200);
            SplashKit.Delay(1100);

            WriteWithDelay("Oh well, it's been fun.", 200);
            SplashKit.Delay(800);

            WriteWithDelay("Catch you later!", 200);
            SplashKit.WriteLine();
        }
    }
}