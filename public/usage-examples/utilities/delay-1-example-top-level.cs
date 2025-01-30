using static SplashKitSDK.SplashKit;

// Write a string to the console with a delay between each word
static void WriteWithDelay(string text, int delayTime)
{
    string[] words = text.Split(' ');
    foreach (string word in words)
    {
        Write(word + " ");
        Delay(delayTime);
    }
    Write("");  // Output the last word if there’s no trailing space
}

WriteWithDelay("Hello there stranger!\n", 200);
Delay(600);

WriteWithDelay("Oh, Hi! I didn't see you there.\n", 200);
Delay(800);

WriteWithDelay("Wait, did you just whisper that? ", 200);
Delay(800);

WriteWithDelay("Come on, let's try that again...\n", 200);
Delay(1100);

WriteWithDelay("HELLO THERE!\n", 200);
Delay(600);

WriteWithDelay("Okay, okay... I felt that!", 200);
Delay(900);

WriteWithDelay("But can you go even LOUDER?\n", 200);
Delay(1100);

WriteWithDelay("HELLOOOOOOO!\n", 200);
Delay(1500);

WriteWithDelay("Wow! That was intense. Let's cool down a bit...", 200);
Delay(2100);

WriteWithDelay("Why are we even shouting?\n", 200);
Delay(1100);

WriteWithDelay("Oh well, it's been fun.", 200);
Delay(800);

WriteWithDelay("Catch you later!", 200);
WriteLine();