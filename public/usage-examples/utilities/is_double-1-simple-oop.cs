using SplashKitSDK;

namespace IsDoubleExample
{
    public class Program
    {
        public static void Main()
        {
            string[] values = { "123", "45.67", "-50", "abc", "789", "0" };

            foreach (string value in values)
            {
                // Print the value along with the result using "true" or "false"
                SplashKit.Write(value + " - ");

                // Check if string is a valid double
                if (SplashKit.IsDouble(value))
                    SplashKit.WriteLine("true");
                else
                    SplashKit.WriteLine("false");
            }
        }
    }
}
