from splashkit import *

write_line("Hello! Welcome to the hexadecimal to decimal converter.")

# Prompt the user for a hexadecimal input
write_line("Please enter a hexadecimal number:")

# Read the input from the user
hex_input = read_line()

# Convert the hexadecimal string to decimal
dec_value = hex_to_dec_string(hex_input)

# Display the result in decimal format
write_line(f"The hexadecimal value in decimal format is: {dec_value}")
