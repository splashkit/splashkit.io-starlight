#include "splashkit.h"

int main()
{
    // Array of strings to analyse
    string texts[7] = {"SplashKit", "Hello", "12345", "A quick brown fox leaps high", "3.141592653589793", "hi", ""};

    // Loop through each string and print its length
    for (int i = 0; i < 7; i++)
    {
        string text = texts[i];
        int length = length_of(text);  // Get the length of the string
        write_line("The length of '" + text + "' is:" + std::to_string(length) + " characters.");
    }

    return 0;
}