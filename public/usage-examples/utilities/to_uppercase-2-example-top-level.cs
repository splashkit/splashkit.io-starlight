using static SplashKitSDK.SplashKit;

string text = "Monkeys love bananas, but penguins prefer ice cream sundaes.";
string word = "";
string result = "";
bool toUpper = true;

// Loop through each character in the string
for (int i = 0; i <= LengthOf(text); i++)
{
    if (i == LengthOf(text) || text[i] == ' ')
    {
        // Process the word (alternate between uppercase and lowercase)
        if (toUpper)
        {
            result += ToUppercase(word);
        }
        else
        {
            result += ToLowercase(word);
        }

        if (i != LengthOf(text))
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

WriteLine("Original text: " + text);
WriteLine("Modified text: " + result);
