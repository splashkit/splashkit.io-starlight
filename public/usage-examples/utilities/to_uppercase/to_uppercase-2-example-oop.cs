using SplashKitSDK;

namespace ConvertToAlternateCase
{
    public class Program
    {
        public static void Main()
        {
            string text = "Monkeys love bananas, but penguins prefer ice cream sundaes.";
            string word = "";
            string result = "";
            bool toUpper = true;

            // Loop through each character in the string
            for (int i = 0; i <= SplashKit.LengthOf(text); i++)
            {
                if (i == SplashKit.LengthOf(text) || text[i] == ' ')
                {
                    // Process the word (alternate between uppercase and lowercase)
                    if (toUpper)
                    {
                        result += SplashKit.ToUppercase(word);
                    }
                    else
                    {
                        result += SplashKit.ToLowercase(word);
                    }

                    if (i != SplashKit.LengthOf(text))
                    {
                        result += " "; // Add space after word if not at end of string
                    }

                    word = ""; // Reset word
                    toUpper = !toUpper; // Alternate case for next word
                }
                else
                {
                    word += text[i]; // Add character to current word
                }
            }

            SplashKit.WriteLine("Original text: " + text);
            SplashKit.WriteLine("Modified text: " + result);
        }
    }
}
