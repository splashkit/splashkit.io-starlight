using SplashKitSDK;

namespace WritePiRadius
{
    public class Program
    {
        public static void Main()
        {
            double pi = 3.14159265358979323846;
            SplashKit.WriteLine("Circle Area Calculator:");

            for (double radius = 1.0; radius <= 10.0; radius += 1.0)
            {
                SplashKit.Write("Radius: ");
                SplashKit.Write(radius); // Writing a double
                SplashKit.Write(", Area: ");
                SplashKit.Write(pi * radius * radius); // Writing the calculated area as a double
                SplashKit.WriteLine("");
            }
        }
    }
}