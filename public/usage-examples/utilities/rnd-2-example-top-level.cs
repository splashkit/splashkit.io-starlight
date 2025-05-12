using static SplashKitSDK.SplashKit;

// Write a terminal welcome message and instructions
WriteLine("Welcome to the Magic 8-Ball!");
WriteLine("Ask a question, and let the universe decide your fate...");
WriteLine("Choose a question by typing the number:");
WriteLine("1. Will I have a good week?");
WriteLine("2. Is it my lucky day?");
WriteLine("3. Should I take that risk?");
WriteLine("4. Will I find what I'm looking for?");

WriteLine("Your choice (1-4): ");
int choice = ConvertToInteger(ReadLine());

WriteLine("\nShaking the Magic 8-Ball...");
Delay(2000); // Add suspense

// Generate a random float and determine the response
float randomValue = Rnd();
WriteLine("The universe whispers...");

if (randomValue < 0.5)
{
    // Less than 0.5 responses
    switch (choice)
    {
    case 1:
        WriteLine("\"Not likely, but keep your head up.\"");
        break;
    case 2:
        WriteLine("\"The odds aren't in your favor, but miracles happen.\"");
        break;
    case 3:
        WriteLine("\"It's better to wait and see.\"");
        break;
    case 4:
        WriteLine("\"Keep searching. It's not your time yet.\"");
        break;
    default:
        WriteLine("\"Hmm... the universe is confused by your question.\"");
        break;
    }
}
else
{
    // Greater than or equal to 0.5 responses
    switch (choice)
    {
    case 1:
        WriteLine("\"Yes! This week is yours to conquer.\"");
        break;
    case 2:
        WriteLine("\"Absolutely, luck is on your side!\"");
        break;
    case 3:
        WriteLine("\"Go for it! Fortune favors the bold.\"");
        break;
    case 4:
        WriteLine("\"Yes, you'll find it sooner than you think.\"");
        break;
    default:
        WriteLine("\"Hmm... the universe is confused by your question.\"");
        break;
    }
}

WriteLine("\nThe Magic 8-Ball has spoken. Have a great day!");