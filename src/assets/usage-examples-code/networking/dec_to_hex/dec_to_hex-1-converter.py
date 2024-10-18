from splashkit import *

write_line("Hello! Welcome to the decimal to hexadecimal converter.")

# Prompt the user for a decimal input
write_line("Please enter a decimal number:")

# Read the input from the user
dec_input = read_line()

# Convert the input string to an unsigned integer
dec_value = convert_to_integer(dec_input)

# Convert the decimal value to hexadecimal
hex_value = dec_to_hex(dec_value)

# Display the result in hexadecimal format
write_line(f"The decimal value in hexadecimal format is: {hex_value}")
