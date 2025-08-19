using static SplashKitSDK.SplashKit;

WriteLine("Countdown:");
for (int i = 10; i >= 0; i--)  // Countdown from 10 to 0
{
    Write("T-minus ");
    Write(i);  // Writing an integer
    WriteLine(" seconds...");
}
WriteLine("Lift off!");