using SplashKitSDK;

namespace RandomColorExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("Colour Changing Button", 800, 600);

            //Declare cursor point, rectangular button and store colour
            Color buttonColor = Color.Green;
            Point2D mousePt;
            Rectangle button = SplashKit.RectangleFrom(250, 250, 300, 100);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                mousePt = SplashKit.MousePosition();

                //Check if the cursor is on the button
                if (SplashKit.PointInRectangle(mousePt, button))
                {
                    //Change the colour to a random colour
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        buttonColor = SplashKit.RandomColor();
                    }
                }

                SplashKit.ClearScreen();
                SplashKit.DrawText("Click the button to change its Colour", Color.Black, 250, 200);
                SplashKit.DrawRectangle(Color.Black, button);
                SplashKit.FillRectangle(buttonColor, button);
                SplashKit.RefreshScreen();
            }
            SplashKit.CloseAllWindows();
        }
    }
}
