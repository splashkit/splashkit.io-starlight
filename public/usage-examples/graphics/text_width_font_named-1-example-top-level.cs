using static SplashKitSDK.SplashKit;

OpenWindow("Text Width", 680, 200);
ClearScreen(ColorWhite());

LoadFont("LOTR", "lotr.ttf");
SetFontStyle("LOTR", SplashKitSDK.FontStyle.BoldFont);
DrawText("Ringbearer", ColorBlack(), "LOTR", 100, 30, 20);

//Getting the width of the text to fill a rectange of that width
int width = TextWidth("Ringbearer", "LOTR", 100);
FillRectangle(ColorBlack(), 30, 130, width, 10);
RefreshScreen();

Delay(5000);
CloseAllWindows();