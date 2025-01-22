using static SplashKitSDK.SplashKit;

WriteLine("Hello! Welcome to the hexadecimal to decimal converter.");

// Prompt the user for a hexadecimal input
WriteLine("Please enter a hexadecimal number:");

// Read the input as a string
string hex_input = ReadLine();

// Convert the hexadecimal string to decimal
string dec_value = HexToDecString(hex_input);

// Display the result
WriteLine("The hexadecimal value in decimal format is: " + dec_value);