using SplashKitSDK;

namespace Ipv4ToDecExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.WriteLine("Hello! Welcome to the IP to decimal converter.");

            // Prompt the user for an IP input in dotted decimal format (e.g., 127.0.0.1)
            SplashKit.WriteLine("Please enter an IPv4 address in dotted decimal format (e.g., 127.0.0.1):");
            
            // Read the input as a string
            string ip_input = SplashKit.ReadLine();

            // Convert the IPv4 string to a decimal
            uint ip_as_dec = SplashKit.Ipv4ToDec(ip_input);

            // Display the result
            SplashKit.WriteLine("The IP address in decimal format is: " + ip_as_dec);
        }
    }
}