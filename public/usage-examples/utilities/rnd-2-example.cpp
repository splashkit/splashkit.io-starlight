#include "splashkit.h"

int main()
{
    // Write a terminal welcome message and instructions
    write_line("Welcome to the Magic 8-Ball!");
    write_line("Ask a question, and let the universe decide your fate...");
    write_line("Choose a question by typing the number:");
    write_line("1. Will I have a good week?");
    write_line("2. Is it my lucky day?");
    write_line("3. Should I take that risk?");
    write_line("4. Will I find what I'm looking for?");
    
    write_line("Your choice (1-4): ");
    int choice = convert_to_integer(read_line());
    
    write_line("\nShaking the Magic 8-Ball...");
    delay(2000); // Add suspense

    // Generate a random float and determine the response
    float random_value = rnd();
    write_line("The universe whispers...");

    if (random_value < 0.5)
    {
        // Less than 0.5 responses
        switch (choice)
        {
        case 1:
            write_line("\"Not likely, but keep your head up.\"");
            break;
        case 2:
            write_line("\"The odds aren't in your favor, but miracles happen.\"");
            break;
        case 3:
            write_line("\"It's better to wait and see.\"");
            break;
        case 4:
            write_line("\"Keep searching. It's not your time yet.\"");
            break;
        default:
            write_line("\"Hmm... the universe is confused by your question.\"");
            break;
        }
    }
    else
    {
        // Greater than or equal to 0.5 responses
        switch (choice)
        {
        case 1:
            write_line("\"Yes! This week is yours to conquer.\"");
            break;
        case 2:
            write_line("\"Absolutely, luck is on your side!\"");
            break;
        case 3:
            write_line("\"Go for it! Fortune favors the bold.\"");
            break;
        case 4:
            write_line("\"Yes, you'll find it sooner than you think.\"");
            break;
        default:
            write_line("\"Hmm... the universe is confused by your question.\"");
            break;
        }
    }

    write_line("\nThe Magic 8-Ball has spoken. Have a great day!");
}