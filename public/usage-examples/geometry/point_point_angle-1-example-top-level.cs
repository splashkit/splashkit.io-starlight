using SplashKitSDK;
using static SplashKitSDK.SplashKit;
using static System.Math;

// Define the variables
Window window = OpenWindow("How Does \"Point Point Angle\" Work?", 400, 400);
Font arial = LoadFont("arial", "arial.ttf");
Line horizontalL = LineFrom(0, ScreenHeight() / 2, ScreenWidth(), ScreenHeight() / 2);
Line verticalL = LineFrom(ScreenWidth() / 2, 0, ScreenWidth() / 2, ScreenHeight());
Line zeroL = LineFrom(ScreenWidth() / 2, ScreenHeight() / 2, ScreenWidth(), ScreenHeight() / 2);
Circle quadrantsC = CircleAt(ScreenCenter(), 100);
Circle centerC = CircleAt(ScreenCenter(), 4);
Point2D centerPt = ScreenCenter();
Point2D mousePt;
double angle;

float ptPtAngle; // Store the "Point Point Angle"

while (!QuitRequested())
{
    ProcessEvents();

    // Get "current" Mouse Position
    mousePt = MousePosition();

    // Calculate the angle between the center point and the current mouse position
    ptPtAngle = PointPointAngle(centerPt, mousePt);

    // Round to 2 decimal places for nicer output
    angle = Round(ptPtAngle, 2);

    // Draw background annotation
    ClearScreen(ColorWhite());
    DrawLine(ColorBlack(), horizontalL);
    DrawLine(ColorBlack(), verticalL);
    DrawCircle(ColorBlack(), quadrantsC);
    DrawLine(ColorRed(), zeroL);
    FillCircle(ColorRed(), centerC);
    DrawText("0", ColorBlue(), arial, 16, 350, ScreenHeight() / 2 - 20);
    DrawText("o", ColorBlue(), arial, 10, 360, ScreenHeight() / 2 - 23);
    DrawText("90", ColorBlue(), arial, 16, ScreenWidth() / 2 + 5, 350);
    DrawText("o", ColorBlue(), arial, 10, ScreenWidth() / 2 + 24, 347);
    DrawText("-90", ColorBlue(), arial, 16, ScreenWidth() / 2 + 5, 35);
    DrawText("o", ColorBlue(), arial, 10, ScreenWidth() / 2 + 29, 32);
    DrawText("180", ColorBlue(), arial, 16, 30, ScreenHeight() / 2 - 20);
    DrawText("o", ColorBlue(), arial, 10, 58, ScreenHeight() / 2 - 23);
    DrawLine(ColorRed(), centerPt, MousePosition());
    FillRectangle(ColorGreen(), MouseX() + 10, MouseY() - 10, 80, 30);
    DrawText($"{angle}", ColorWhite(), arial, 16, MouseX() + 20, MouseY() - 5);
    DrawText("o", ColorWhite(), arial, 10, MouseX() + 20 + TextWidth($"{angle}", arial, 16), MouseY() - 8);
    RefreshScreen();
}

CloseAllWindows();
FreeAllFonts();