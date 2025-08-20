using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Colour Changing Button", 800, 600);

//Declare cursor point, rectangular button and store colour
Color buttonColor = ColorGreen();
Point2D mousePt;
Rectangle button = RectangleFrom(250, 250, 300, 100);

while (!QuitRequested())
{
    ProcessEvents();

    mousePt = MousePosition();

    //Check if the cursor is on the button
    if (PointInRectangle(mousePt, button))
    {
        //Change the colour to a random colour
        if (MouseClicked(MouseButton.LeftButton))
        {
            buttonColor = RandomColor();
        }
    }

    ClearScreen();
    DrawText("Click the button to change its Colour", ColorBlack(), 250, 200);
    DrawRectangle(ColorBlack(), button);
    FillRectangle(buttonColor, button);
    RefreshScreen();
}
CloseAllWindows();
