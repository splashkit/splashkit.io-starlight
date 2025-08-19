using SplashKitSDK;

namespace PointAtExample
{
    public class Program
    {
        // Draw a flower at specific point
        public static void DrawFlower(Color petal_color, Point2D location)
        {
            SplashKit.FillCircle(petal_color, location.X, location.Y - 30, 20);
            SplashKit.FillCircle(petal_color, location.X + 28, location.Y - 10, 20);
            SplashKit.FillCircle(petal_color, location.X - 28, location.Y - 10, 20);
            SplashKit.FillCircle(petal_color, location.X + 18, location.Y + 25, 20);
            SplashKit.FillCircle(petal_color, location.X - 18, location.Y + 25, 20);
            SplashKit.FillCircle(Color.Gold, location.X, location.Y, 20);
        }
        
        public static void Main()
        {
            SplashKit.OpenWindow("Grid of Flowers", 600, 600);

            // Declare constants and variables
            const int GRID_SIZE = 5;
            int temp_x = 0;
            int temp_y = 0;
            Point2D[,] points = new Point2D[GRID_SIZE, GRID_SIZE];
            Color[,] flower_colors = new Color[GRID_SIZE,GRID_SIZE];

            // Generate flower points in 5x5 grid pattern
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    // Create a point using temp_x and temp_y
                    temp_x = 100 + (x * 100);
                    temp_y = 100 + (y * 100);
                    Point2D temp_point = SplashKit.PointAt(temp_x, temp_y);

                    // Assign data to 2D arrays
                    points[x,y] = temp_point;
                    flower_colors[x,y] = Color.RGBColor(x * 50, 100, y * 50);
                }
            }

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                // Draw grid of flowers with random colors
                SplashKit.ClearScreen();
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    for (int y = 0; y < GRID_SIZE; y++)
                    {
                        DrawFlower(flower_colors[x,y], points[x,y]);
                    }
                }
                SplashKit.RefreshScreen();
            }
            
            SplashKit.CloseAllWindows();
        }
    }
}