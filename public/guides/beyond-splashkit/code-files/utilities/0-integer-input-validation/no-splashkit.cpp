#include <iostream>

using namespace std;

string trim(const string &text)
{
    // Function to check trim whitespace from string
    // This is what SplashKit abstracts from the user when calling trim

    size_t first = text.find_first_not_of(' ');
    if (string::npos == first)
    {
        return text;
    }
    size_t last = text.find_last_not_of(' ');
    return text.substr(first, (last - first + 1));
}

bool is_integer(string text)
{
    // Function to check if input is a valid integer
    // This is what SplashKit abstracts from the user when calling is_integer

    string s = trim(text);
    if (s.empty() || ((!isdigit(s[0])) && (s[0] != '-') && (s[0] != '+')))
        return false;

    char *p;
    strtol(s.c_str(), &p, 10);

    return (*p == 0);
}

int read_integer(string prompt)
{
    // This function converts user input into an integer with input validation using non-SplashKit functions.

    string input_string;

    // Prompt user with message in terminal and read input from user
    cout << prompt;
    cin >> input_string;

    // Holds program in a loop if user enters a valid integer
    while (!is_integer(input_string))
    {
        cout << "Please enter a valid integer." << endl;
        cout << prompt;
        cin >> input_string;
    }

    // Convert to integer and return
    return stoi(input_string);
}

int main(int argc, char *argv[])
{
    int first_num = read_integer("Please enter first number (whole number): ");
    int second_num = read_integer("Please enter second number (whole number): ");

    cout << "The sum of the two integers is: ";
    cout << first_num + second_num << endl;

    return 0;
}
