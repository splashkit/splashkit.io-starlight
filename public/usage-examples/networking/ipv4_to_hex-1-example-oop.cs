using SplashKitSDK;

namespace Ipv4ToHexExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Hello! Welcome to the IP to hexadecimal converter.");

            // Prompt the user for an IP input in dotted decimal format (e.g., 127.0.0.1)
            SplashKit.WriteLine("Please enter an IPv4 address in dotted decimal format (e.g., 127.0.0.1):");

            // Read the input as a string
            string ip_input = SplashKit.ReadLine();

            // Convert the IPv4 string to hexadecimal
            string ip_as_hex = SplashKit.Ipv4ToHex(ip_input);

            // Display the result
            SplashKit.WriteLine("The IP address in hexadecimal format is: " + ip_as_hex);
        }
    }
}
