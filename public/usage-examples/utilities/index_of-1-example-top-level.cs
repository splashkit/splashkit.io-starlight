using static SplashKitSDK.SplashKit;

// Get sentence input from the user
WriteLine("Enter a sentence:");
string sentence = ReadLine();

// Get the word to search for
WriteLine("Enter the word to search for:");
string word = ReadLine();

// Find index of the word in the sentence
int index = IndexOf(sentence, word);

// Display results based on whether the word was found or not
if (index != -1)
{
    WriteLine($"The word '{word}' starts at index: {index}");
}
else
{
    WriteLine($"The word '{word}' was not found in the sentence.");
}
