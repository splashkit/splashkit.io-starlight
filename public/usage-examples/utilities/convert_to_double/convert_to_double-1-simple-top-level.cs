using static SplashKitSDK.SplashKit;

WriteLine("Welcome to the Simple Interest Calculator!");

// Get principal amount from the user
WriteLine("Please enter the principal amount (in dollars):");
string principalInput = ReadLine();

// Get the interest rate from the user
WriteLine("Please enter the interest rate (as a percentage, e.g., 5 for 5%):");
string rateInput = ReadLine();

// Get the time period from the user
WriteLine("Please enter the time period (in years):");
string timeInput = ReadLine();

// Convert inputs to double
double principal = ConvertToDouble(principalInput);
double rate = ConvertToDouble(rateInput);
double time = ConvertToDouble(timeInput);

// Calculate simple interest: Interest = Principal * Rate * Time / 100
double interest = (principal * rate * time) / 100;

// Output the result
WriteLine("Calculating interest...");
Delay(1000);

WriteLine($"For a principal of ${principal} at an interest rate of {rate}% over {time} years:");
WriteLine($"The simple interest is: ${interest}");