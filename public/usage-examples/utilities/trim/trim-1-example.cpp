#include "splashkit.h"

int main()
{
    string text = "   Whitespace is sneaky!   ";

    write_line("Original string with sneaky spaces: '" + text + "'");
    write_line("Let's get rid of those pesky spaces...");

    // Trim spaces from the start and end
    string trimmed = trim(text);

    write_line("Trimmed string: '" + trimmed + "'");
    write_line("Aha! Much better without those sneaky spaces!");

    return 0;
}
