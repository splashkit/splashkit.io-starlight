using SplashKitSDK;

namespace IndexOfExample
{
    public class Program
    {
        public static void Main()
        {
            // Get sentence input from the user
            SplashKit.WriteLine("Enter a sentence:");
            string sentence = SplashKit.ReadLine();

            // Get the word to search for
            SplashKit.WriteLine("Enter the word to search for:");
            string word = SplashKit.ReadLine();

            // Find index of the word in the sentence
            int index = SplashKit.IndexOf(sentence, word);

            // Display results based on whether the word was found or not
            if (index != -1)
            {
                SplashKit.WriteLine($"The word '{word}' starts at index: {index}");
            }
            else
            {
                SplashKit.WriteLine($"The word '{word}' was not found in the sentence.");
            }
        }
    }
}
