from splashkit import *

# Get sentence input from the user
write_line("Enter a sentence:")
sentence = read_line()

# Get the word to search for
write_line("Enter the word to search for:")
word = read_line()

# Find index of the word in the sentence
index = index_of(sentence, word)

# Display results based on whether the word was found or not
if index != -1:
    write_line(f"The word '{word}' starts at index: {index}")
else:
    write_line(f"The word '{word}' was not found in the sentence.")
