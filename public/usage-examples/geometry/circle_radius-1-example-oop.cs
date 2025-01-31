using SplashKitSDK;

namespace CircleRadiusExample
{
    public class Program
    {
        public static void Main()
        {
            // Declare constants and variables
            const int MAX_RADIUS = 250;
            Window window = new Window("Circle Radius", 600, 700);
            Font arial = new Font("arial", "arial.ttf");

            Circle circle = SplashKit.CircleAt(SplashKit.ScreenCenter(), 100);
            Rectangle quadrant1 = SplashKit.RectangleFrom(circle.Center.X, circle.Center.Y - circle.Radius, circle.Radius + 1, circle.Radius + 1);
            Rectangle quadrant2 = SplashKit.RectangleFrom(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, circle.Radius + 1, circle.Radius + 1);
            Rectangle quadrant3 = SplashKit.RectangleFrom(circle.Center.X - circle.Radius, circle.Center.Y, circle.Radius + 1, circle.Radius + 1);
            Rectangle quadrant4 = SplashKit.RectangleFrom(circle.Center.X, circle.Center.Y, circle.Radius + 1, circle.Radius + 1);

            int quadrantClicked = 0;
            float ptPtAngle = 0;

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                // User input to change radius size
                if (SplashKit.KeyDown(KeyCode.UpKey) && SplashKit.CircleRadius(circle) < MAX_RADIUS)
                    circle.Radius += 1;
                if (SplashKit.KeyDown(KeyCode.DownKey) && SplashKit.CircleRadius(circle) > 10)
                    circle.Radius -= 1;


                // Click left mouse button to remove quadrant of circle in mouse location
                ptPtAngle = SplashKit.PointPointAngle(SplashKit.ScreenCenter(), SplashKit.MousePosition());
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
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
                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                {
                    quadrantClicked = 0;
                }

                // Show/hide segment cut-out
                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    SplashKit.ClearScreen(Color.LightGray);
                else
                    SplashKit.ClearScreen(Color.White);

                // Draw the Circle and segment cut-out if clicked
                SplashKit.FillCircle(Color.Orange, circle);
                switch (quadrantClicked)
                {
                    case 1:
                        quadrant1 = SplashKit.RectangleFrom(circle.Center.X, circle.Center.Y - circle.Radius, circle.Radius + 1, circle.Radius + 1);
                        SplashKit.FillRectangle(Color.White, quadrant1);
                        break;
                    case 2:
                        quadrant2 = SplashKit.RectangleFrom(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, circle.Radius + 1, circle.Radius + 1);
                        SplashKit.FillRectangle(Color.White, quadrant2);
                        break;
                    case 3:
                        quadrant3 = SplashKit.RectangleFrom(circle.Center.X - circle.Radius, circle.Center.Y, circle.Radius + 1, circle.Radius + 1);
                        SplashKit.FillRectangle(Color.White, quadrant3);
                        break;
                    case 4:
                        quadrant4 = SplashKit.RectangleFrom(circle.Center.X, circle.Center.Y, circle.Radius + 1, circle.Radius + 1);
                        SplashKit.FillRectangle(Color.White, quadrant4);
                        break;
                }

                // Draw other shapes and instructions
                SplashKit.DrawRectangle(Color.Gray, 50, 100, 500, 500);
                SplashKit.DrawLine(Color.Gray, SplashKit.ScreenWidth() / 2, 100, SplashKit.ScreenWidth() / 2, 600);
                SplashKit.DrawLine(Color.Gray, 50, SplashKit.ScreenHeight() / 2, 550, SplashKit.ScreenHeight() / 2);
                SplashKit.DrawText("Instructions", Color.Red, arial, 16, 50, 10);
                SplashKit.DrawText("1. Use the up/down arrow keys to change the radius of the circle.", Color.Blue, arial, 14, 50, 40);
                SplashKit.DrawText("2. Click in a quadrant to remove the segment of the circle. Escape key to reset.", Color.Blue, arial, 14, 50, 65);
                SplashKit.DrawText("Psst! Hold Space bar to see how it works!", Color.Blue, arial, 12, 50, 630);
                SplashKit.DrawText($"Circle Radius: {circle.Radius}", Color.Green, arial, 24, 320, 620);
                SplashKit.RefreshScreen(60);
            }

            window.Close();
            arial.Free();
        }
    }
}