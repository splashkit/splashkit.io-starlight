using static SplashKitSDK.SplashKit;

WriteLine("Hello! Welcome to the decimal to hexadecimal converter.");

// Prompt the user for a decimal input
WriteLine("Please enter a decimal number:");

// Read the input as a string
string dec_input = ReadLine();

// Convert the input string to an unsigned integer
uint dec_value = Convert.ToUInt32(dec_input);

// Convert the decimal value to hexadecimal
string hex_value = DecToHex(dec_value);

// Display the result
WriteLine("The decimal value in hexadecimal format is: " + hex_value);
