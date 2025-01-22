from splashkit import *

# Array of strings to analyse
texts = ["SplashKit", "Hello", "12345", "A quick brown fox leaps high", "3.141592653589793", "hi", ""]

# Loop through each string and print its length
for text in texts:
    length = length_of(text)  # Get the length of the string
    write_line(f"The length of '{text}' is: {length} characters.")