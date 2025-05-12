using SplashKitSDK;

namespace RndExample
{
    public class Program
    {
        public static void Main()
        {
            // Write a terminal welcome message and instructions
            SplashKit.WriteLine("Welcome to the Magic 8-Ball!");
            SplashKit.WriteLine("Ask a question, and let the universe decide your fate...");
            SplashKit.WriteLine("Choose a question by typing the number:");
            SplashKit.WriteLine("1. Will I have a good week?");
            SplashKit.WriteLine("2. Is it my lucky day?");
            SplashKit.WriteLine("3. Should I take that risk?");
            SplashKit.WriteLine("4. Will I find what I'm looking for?");
            
            SplashKit.WriteLine("Your choice (1-4): ");
            int choice = SplashKit.ConvertToInteger(SplashKit.ReadLine());
            
            SplashKit.WriteLine("\nShaking the Magic 8-Ball...");
            SplashKit.Delay(2000); // Add suspense

            // Generate a random float and determine the response
            float randomValue = SplashKit.Rnd();
            SplashKit.WriteLine("The universe whispers...");

            if (randomValue < 0.5)
            {
                // Less than 0.5 responses
                switch (choice)
                {
                case 1:
                    SplashKit.WriteLine("\"Not likely, but keep your head up.\"");
                    break;
                case 2:
                    SplashKit.WriteLine("\"The odds aren't in your favor, but miracles happen.\"");
                    break;
                case 3:
                    SplashKit.WriteLine("\"It's better to wait and see.\"");
                    break;
                case 4:
                    SplashKit.WriteLine("\"Keep searching. It's not your time yet.\"");
                    break;
                default:
                    SplashKit.WriteLine("\"Hmm... the universe is confused by your question.\"");
                    break;
                }
            }
            else
            {
                // Greater than or equal to 0.5 responses
                switch (choice)
                {
                case 1:
                    SplashKit.WriteLine("\"Yes! This week is yours to conquer.\"");
                    break;
                case 2:
                    SplashKit.WriteLine("\"Absolutely, luck is on your side!\"");
                    break;
                case 3:
                    SplashKit.WriteLine("\"Go for it! Fortune favors the bold.\"");
                    break;
                case 4:
                    SplashKit.WriteLine("\"Yes, you'll find it sooner than you think.\"");
                    break;
                default:
                    SplashKit.WriteLine("\"Hmm... the universe is confused by your question.\"");
                    break;
                }
            }

            SplashKit.WriteLine("\nThe Magic 8-Ball has spoken. Have a great day!");
        }
    }
}