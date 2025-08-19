using static SplashKitSDK.SplashKit;

// Example 1: Print explicit string
WriteLine("Hello World");

// Example 2: Print value of string variable
string message = "Hello World from 'message' variable";
WriteLine(message);

// Example 3: Print combination of explicit string and value of string variable
string hello = "Hello";
WriteLine(hello + " World!\nDon't forget spaces between words when printing to the terminal!");
WriteLine("Otherwise you get this: " + hello + "World!");