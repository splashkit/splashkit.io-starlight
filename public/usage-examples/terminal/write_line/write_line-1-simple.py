from splashkit import *

# Example 1: Print explicit string
write_line("Hello World")

# Example 2: Print value of string variable
message = "Hello World from 'message' variable"
write_line(message)

# Example 3: Print combination of explicit string and value of string variable
hello = "Hello"
write_line(hello + " World!\nDon't forget spaces between words when printing to the terminal!")
write_line("Otherwise you get this: " + hello + "World!")
