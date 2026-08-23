using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Get Font Style", 800, 600);

int style_number = -1;
Font font = FontNamed("Century.ttf");

while (!QuitRequested())
{
    ProcessEvents();

    if (style_number < 3)
    {
        style_number += 1;
    }
    else
    {
        style_number = 0;
    }

    if (style_number == 0)
    {
        SetFontStyle(font, FontStyle.NormalFont);
    }
    else if (style_number == 1)
    {
        SetFontStyle(font, FontStyle.BoldFont);
    }
    else if (style_number == 2)
    {
        SetFontStyle(font, FontStyle.ItalicFont);
    }
    else if (style_number == 3)
    {
        SetFontStyle(font, FontStyle.UnderlineFont);
    }

    SplashKit.ClearScreen(ColorWhite());
    // Function is used here ↓
    DrawText("The assigned font style is currently set to " + GetFontStyle(font), ColorBlack(), 40, 60);
    DrawText("The quick brown fox jumps over the lazy dog", ColorBlack(), font, 30, 40, 110);
    RefreshScreen();

    Delay(2000);
}
CloseAllWindows();