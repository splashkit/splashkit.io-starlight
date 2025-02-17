#include "splashkit.h"

int main()
{
    string text = "Monkeys love bananas, but penguins prefer ice cream sundaes.";
    string word = "";
    string result = "";
    bool to_upper = true;

    // Loop through each character in the string
    for (int i = 0; i <= length_of(text); i++)
    {
        if (i == length_of(text) || text[i] == ' ')
        {
            // Process the word (alternate between uppercase and lowercase)
            if (to_upper)
            {
                result += to_uppercase(word);
            }
            else
            {
                result += to_lowercase(word);
            }
            
            if (i != length_of(text))
            {
                result += " "; // Add space after word if not at end of string
            }

            word = ""; // Reset word
            to_upper = !to_upper; // Alternate case for next word
        }
        else
        {
            word += text[i]; // Add character to current word
        }
    }
    
    write_line("Original text: " + text);
    write_line("Modified text: " + result);

    return 0;
}
