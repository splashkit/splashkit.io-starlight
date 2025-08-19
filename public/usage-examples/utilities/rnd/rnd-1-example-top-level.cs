using static SplashKitSDK.SplashKit;

WriteLine("");
WriteLine("Let's simulate a Coin Flip!");
WriteLine("");
WriteLine("Flipping coin ...");
Delay(1500);
WriteLine("");

float random = 0.5F;

// Add extra "randomness"
for (int i = 0; i < 100; i++)
{
    random = Rnd();
}

// 50% chance of heads or tails
if (random < 0.5)
{
    WriteLine("Heads!");
}
else
{
    WriteLine("Tails!");
}
WriteLine("");