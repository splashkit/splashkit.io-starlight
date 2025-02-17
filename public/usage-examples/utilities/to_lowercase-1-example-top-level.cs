using static SplashKitSDK.SplashKit;

WriteLine("Type a phrase in ALL CAPS (SHOUT IT!):");
string input = ReadLine();

// Convert input to lowercase
string quieted = ToLowercase(input);

WriteLine("Calm down... here it is in lowercase: " + quieted);