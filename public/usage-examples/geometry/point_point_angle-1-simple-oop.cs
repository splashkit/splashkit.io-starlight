using SplashKitSDK;

namespace PointPointAngleExample
{
    public class Program
    {
        public static void Main()
        {
            // Define the variables
            Window window = SplashKit.OpenWindow("How Does \"Point Point Angle\" Work?", 400, 400);
            Font arial = SplashKit.LoadFont("arial", "arial.ttf");
            Line horizontalL = SplashKit.LineFrom(0, SplashKit.ScreenHeight() / 2, SplashKit.ScreenWidth(), SplashKit.ScreenHeight() / 2);
            Line verticalL = SplashKit.LineFrom(SplashKit.ScreenWidth() / 2, 0, SplashKit.ScreenWidth() / 2, SplashKit.ScreenHeight());
            Line zeroL = SplashKit.LineFrom(SplashKit.ScreenWidth() / 2, SplashKit.ScreenHeight() / 2, SplashKit.ScreenWidth(), SplashKit.ScreenHeight() / 2);
            Circle quadrantsC = SplashKit.CircleAt(SplashKit.ScreenCenter(), 100);
            Circle centerC = SplashKit.CircleAt(SplashKit.ScreenCenter(), 4);
            Point2D centerPt = SplashKit.ScreenCenter();
            Point2D mousePt;
            double angle;

            float ptPtAngle; // Store the "Point Point Angle"

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Get "current" Mouse Position
                mousePt = SplashKit.MousePosition();

                // Calculate the angle between the center point and the current mouse position
                ptPtAngle = SplashKit.PointPointAngle(centerPt, mousePt);

                // Round to 2 decimal places for nicer output
                angle = Math.Round(ptPtAngle, 2);

                // Draw background annotation
                SplashKit.ClearScreen(Color.White);
                SplashKit.DrawLine(Color.Black, horizontalL);
                SplashKit.DrawLine(Color.Black, verticalL);
                SplashKit.DrawCircle(Color.Black, quadrantsC);
                SplashKit.DrawLine(Color.Red, zeroL);
                SplashKit.FillCircle(Color.Red, centerC);
                SplashKit.DrawText("0", Color.Blue, arial, 16, 350, SplashKit.ScreenHeight() / 2 - 20);
                SplashKit.DrawText("o", Color.Blue, arial, 10, 360, SplashKit.ScreenHeight() / 2 - 23);
                SplashKit.DrawText("90", Color.Blue, arial, 16, SplashKit.ScreenWidth() / 2 + 5, 350);
                SplashKit.DrawText("o", Color.Blue, arial, 10, SplashKit.ScreenWidth() / 2 + 24, 347);
                SplashKit.DrawText("-90", Color.Blue, arial, 16, SplashKit.ScreenWidth() / 2 + 5, 35);
                SplashKit.DrawText("o", Color.Blue, arial, 10, SplashKit.ScreenWidth() / 2 + 29, 32);
                SplashKit.DrawText("180", Color.Blue, arial, 16, 30, SplashKit.ScreenHeight() / 2 - 20);
                SplashKit.DrawText("o", Color.Blue, arial, 10, 58, SplashKit.ScreenHeight() / 2 - 23);
                SplashKit.DrawLine(Color.Red, centerPt, SplashKit.MousePosition());
                SplashKit.FillRectangle(Color.Green, SplashKit.MouseX() + 10, SplashKit.MouseY() - 10, 80, 30);
                SplashKit.DrawText($"{angle}", Color.White, arial, 16, SplashKit.MouseX() + 20, SplashKit.MouseY() - 5);
                SplashKit.DrawText("o", Color.White, arial, 10, SplashKit.MouseX() + 20 + SplashKit.TextWidth($"{angle}", arial, 16), SplashKit.MouseY() - 8);
                SplashKit.RefreshScreen();
            }

            window.Close();
            arial.Free();
        }
    }
}