using SplashKitSDK;

namespace WriteLineIntExample
{
    public class Program
    {
        public static void Main()
        {
            // Example 1: Print single integer
            SplashKit.WriteLine(1);
            SplashKit.WriteLine(2);
            SplashKit.WriteLine(3);
            SplashKit.WriteLine(-1);
            SplashKit.WriteLine(-2);
            SplashKit.WriteLine(-3);

            // Example 2: Print multi-digit integer
            SplashKit.WriteLine(12345);
            SplashKit.WriteLine(953221311);
            SplashKit.WriteLine(-165746);

            // Example 3: Print integer after calculation
            int a = 222 - 111;
            int b = 10 * 12;
            int c = 100 / 5;

            SplashKit.WriteLine(a - b);
            SplashKit.WriteLine(b);
            SplashKit.WriteLine(c);
        }
    }
}
