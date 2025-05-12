using static SplashKitSDK.SplashKit;

WriteLine("Get ready to generate a random number up to 1000...");
WriteLine("Drum roll please...");
Delay(2000); // Delay for 2 seconds

// Generate a random number up to the ubound
int randomNumber = Rnd(1000);

WriteLine($"Your lucky number is: {randomNumber}!!");
WriteLine("Feeling lucky? Maybe it's time to play the lottery!");