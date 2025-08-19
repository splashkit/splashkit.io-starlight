using SplashKitSDK;

namespace SamePointExample
{
    public class Program
    {
        public static Point2D GetPoint(string prompt)
        {
            // Get user input
            SplashKit.Write(prompt);
            string guessInput = SplashKit.ReadLine();
            List<string> coords = SplashKit.Split(guessInput, ',');

            // Validate input
            while (!SplashKit.IsDouble(coords[0]) || !SplashKit.IsDouble(coords[1]))
            {
                SplashKit.WriteLine("Invalid input. Try again.");
                SplashKit.Write(prompt);
                guessInput = SplashKit.ReadLine();
                coords = SplashKit.Split(guessInput, ',');
            }

            // Convert input
            double guessX = SplashKit.ConvertToDouble(coords[0]);
            double guessY = SplashKit.ConvertToDouble(coords[1]);
            return SplashKit.PointAt(guessX, guessY);
        }

        public static void Main()
        {
            // Variable Declarations
            Point2D targetPoint = SplashKit.PointAt(50, 75);
            Point2D guessPoint;

            SplashKit.WriteLine("Guess the coordinate inside (100,100) ");

            // Get user input
            guessPoint = GetPoint("Enter your coordinates as x,y: ");

            while (!SplashKit.SamePoint(targetPoint, guessPoint))
            {
                // Clues
                if (targetPoint.X > guessPoint.X)
                    SplashKit.WriteLine("x is too low");
                else if (targetPoint.X < guessPoint.X)
                    SplashKit.WriteLine("x is too high");
                else
                    SplashKit.WriteLine("x is correct !!!");

                if (targetPoint.Y > guessPoint.Y)
                    SplashKit.WriteLine("y is too low");
                else if (targetPoint.Y < guessPoint.Y)
                    SplashKit.WriteLine("y is too high");
                else
                    SplashKit.WriteLine("y is correct !!!");

                SplashKit.WriteLine("Try Again!");
                guessPoint = GetPoint("Enter your coordinates as x,y: ");
            }
            SplashKit.WriteLine("You Win!");
        }
    }
}