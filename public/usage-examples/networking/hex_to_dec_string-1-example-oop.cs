using SplashKitSDK;

namespace HexToDecStringExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Hello! Welcome to the hexadecimal to decimal converter.");

            // Prompt the user for a hexadecimal input
            SplashKit.WriteLine("Please enter a hexadecimal number:");

            // Read the input as a string
            string hex_input = SplashKit.ReadLine();

            // Convert the hexadecimal string to decimal
            string dec_value = SplashKit.HexToDecString(hex_input);

            // Display the result
            SplashKit.WriteLine("The hexadecimal value in decimal format is: " + dec_value);
        }
    }
}