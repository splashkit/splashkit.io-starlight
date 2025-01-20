#include "splashkit.h"

int main()
{
    // Get sentence input from the user
    write_line("Enter a sentence:");
    string sentence = read_line();

    // Get the word to search for
    write_line("Enter the word to search for:");
    string word = read_line();

    // Find index of the word in the sentence
    int index = index_of(sentence, word);

    // Display results based on whether the word was found or not
    if (index != -1)
    {
        write_line("The word '" + word + "' starts at index: " + std::to_string(index));
    }
    else
    {
        write_line("The word '" + word + "' was not found in the sentence.");
    }

    return 0;
}