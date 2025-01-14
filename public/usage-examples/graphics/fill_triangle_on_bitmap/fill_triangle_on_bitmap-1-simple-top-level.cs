using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Open a window
OpenWindow("Happy Hat", 618, 618);

// Load the bitmaps for sad and smiling emojis (https://openmoji.org/library/#group=smileys-emotion)
Bitmap sadEmoji = LoadBitmap("sad_emoji", "sad_emoji.png");
Bitmap smilingEmoji = LoadBitmap("smiling_emoji", "smiling_emoji.png");

// Draw the sad emoji and add a hat
ClearScreen(ColorBlack());
DrawBitmap(sadEmoji, 0, 0);
RefreshScreen();
Delay(1000);

// Draw a triangle hat on the smiling emoji
FillTriangleOnBitmap(smilingEmoji, ColorRed(), 100, 200, 309, 20, 520, 200);

// Clear screen and switch to the smiling emoji
ClearScreen(ColorBlack());
DrawBitmap(smilingEmoji, 0, 0);
RefreshScreen();
Delay(1000);

// Spin the smiling emoji with the hat
for (int i = 0; i < 360; i++)
{
    ClearScreen(ColorBlack());
    DrawBitmap(smilingEmoji, 0, 0, OptionRotateBmp(i));
    RefreshScreen();
    Delay(10);
}

// Free the bitmap resource
FreeAllBitmaps();
// Close all windows
CloseAllWindows();
 