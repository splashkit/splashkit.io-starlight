using static SplashKitSDK.SplashKit;

string userInput;
double principal, rate, time, interest;

WriteLine("Welcome to the Simple Interest Calculator!");

// Get principal amount from the user (without input validation for simplicity)
Write("Please enter the principal amount (in dollars): ");
userInput = ReadLine();
principal = ToDouble(userInput);

// Get the interest rate from the user
Write("Please enter the interest rate (as a percentage, e.g., 5 for 5%): ");
userInput = ReadLine();
rate = ToDouble(userInput);

// Get the time period from the user
Write("Please enter the time period (in years): ");
userInput = ReadLine();
time = ToDouble(userInput);

// Calculate simple interest: Interest = Principal * Rate * Time / 100
interest = (principal * rate * time) / 100;

// Output the result
WriteLine("Calculating interest...");
Delay(1000);

WriteLine("For a principal of $" + ToString(principal, 2) + " at an interest rate of " + ToString(rate, 2) + "% over " + ToString(time, 2) + " years:");
WriteLine("\tThe simple interest is: $" + ToString(interest, 2));