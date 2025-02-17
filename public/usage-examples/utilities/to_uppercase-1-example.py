from splashkit import *

write("What is your favourite colour: ")
input = read_line()

# Convert input to uppercase for comparison
if (to_uppercase(input) == "PURPLE"):
    write_line("WOO HOO Purple club!")
else:
    write_line("Great colour!")
write_line("---")