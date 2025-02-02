using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Declare constants and variables
const int MAX_RADIUS = 250;
Window window = OpenWindow("Circle Radius", 600, 700);
Font arial = LoadFont("arial", "arial.ttf");

Circle circle = CircleAt(ScreenCenter(), 100);
Rectangle quadrant1 = RectangleFrom(CircleX(circle), CircleY(circle) - CircleRadius(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
Rectangle quadrant2 = RectangleFrom(CircleX(circle) - CircleRadius(circle), CircleY(circle) - CircleRadius(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
Rectangle quadrant3 = RectangleFrom(CircleX(circle) - CircleRadius(circle), CircleY(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
Rectangle quadrant4 = RectangleFrom(CircleX(circle), CircleY(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);

int quadrantClicked = 0;
float ptPtAngle = 0;

while (!WindowCloseRequested(window))
{
    ProcessEvents();

    // User input to change radius size
    if (KeyDown(KeyCode.UpKey) && CircleRadius(circle) < MAX_RADIUS)
        circle.Radius += 1;
    if (KeyDown(KeyCode.DownKey) && CircleRadius(circle) > 10)
        circle.Radius -= 1;


    // Click left mouse button to remove quadrant of circle in mouse location
    ptPtAngle = PointPointAngle(ScreenCenter(), MousePosition());
    if (MouseClicked(MouseButton.LeftButton))
    {
        if (ptPtAngle < 0 && ptPtAngle >= -90)
            quadrantClicked = 1;
        if (ptPtAngle < -90 && ptPtAngle >= -180)
            quadrantClicked = 2;
        if (ptPtAngle < 180 && ptPtAngle >= 90)
            quadrantClicked = 3;
        if (ptPtAngle < 90 && ptPtAngle >= 0)
            quadrantClicked = 4;
    }

    // Press escape key to show whole circle
    if (KeyTyped(KeyCode.EscapeKey))
    {
        quadrantClicked = 0;
    }

    // Show/hide segment cut-out
    if (KeyDown(KeyCode.SpaceKey))
        ClearScreen(ColorLightGray());
    else
        ClearScreen(ColorWhite());

    // Draw the Circle and segment cut-out if clicked
    FillCircle(ColorOrange(), circle);
    switch (quadrantClicked)
    {
        case 1:
            quadrant1 = RectangleFrom(CircleX(circle), CircleY(circle) - CircleRadius(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
            FillRectangle(ColorWhite(), quadrant1);
            break;
        case 2:
            quadrant2 = RectangleFrom(CircleX(circle) - CircleRadius(circle), CircleY(circle) - CircleRadius(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
            FillRectangle(ColorWhite(), quadrant2);
            break;
        case 3:
            quadrant3 = RectangleFrom(CircleX(circle) - CircleRadius(circle), CircleY(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
            FillRectangle(ColorWhite(), quadrant3);
            break;
        case 4:
            quadrant4 = RectangleFrom(CircleX(circle), CircleY(circle), CircleRadius(circle) + 1, CircleRadius(circle) + 1);
            FillRectangle(ColorWhite(), quadrant4);
            break;
    }

    // Draw other shapes and instructions
    DrawRectangle(ColorGray(), 50, 100, 500, 500);
    DrawLine(ColorGray(), ScreenWidth() / 2, 100, ScreenWidth() / 2, 600);
    DrawLine(ColorGray(), 50, ScreenHeight() / 2, 550, ScreenHeight() / 2);
    DrawText("Instructions", ColorRed(), arial, 16, 50, 10);
    DrawText("1. Use the up/down arrow keys to change the radius of the circle.", ColorBlue(), arial, 14, 50, 40);
    DrawText("2. Click in a quadrant to remove the segment of the circle. Escape key to reset.", ColorBlue(), arial, 14, 50, 65);
    DrawText("Psst! Hold Space bar to see how it works!", ColorBlue(), arial, 12, 50, 630);
    DrawText($"Circle Radius: {CircleRadius(circle)}", ColorGreen(), arial, 24, 320, 620);
    RefreshScreen(60);
}

CloseWindow(window);
FreeFont(arial);