using SplashKitSDK;

namespace WriteLine
{
    public class Program
    {
        public static void Main()
        {
            // Example 1: Print explicit string
            SplashKit.WriteLine("Hello World");

            // Example 2: Print value of string variable
            string message = "Hello World from 'message' variable";
            SplashKit.WriteLine(message);

            // Example 3: Print combination of explicit string and value of string variable
            string hello = "Hello";
            SplashKit.WriteLine(hello + " World!\nDon't forget spaces between words when printing to the terminal!");
            SplashKit.WriteLine("Otherwise you get this: " + hello + "World!");
        }
    }
}