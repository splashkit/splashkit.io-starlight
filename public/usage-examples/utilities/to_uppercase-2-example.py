from splashkit import *

text = "Monkeys love bananas, but penguins prefer ice cream sundaes."
word = ""
result = ""
to_upper = True

# Loop through each character in the string
for i in range(len(text) + 1):
    if i == len(text) or text[i] == ' ':
        # Process the word (alternate between uppercase and lowercase)
        if to_upper:
            result += to_uppercase(word)
        else:
            result += to_lowercase(word)
        
        if i != len(text):
            result += " "  # Add space after word if not at end of string

        word = ""  # Reset word
        to_upper = not to_upper  # Alternate case for next word
    else:
        word += text[i]  # Add character to current word

write_line("Original text: " + text)
write_line("Modified text: " + result)