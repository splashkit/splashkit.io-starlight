using static SplashKitSDK.SplashKit;

string[] values = { "123", "45.67", "-50", "abc", "789", "0" };

foreach (string value in values)
{
    // Print the value along with the result using "true" or "false"
    Write(value + " - ");

    // Check if string is a valid double
    if (IsDouble(value))
        WriteLine("true");
    else
        WriteLine("false");
}