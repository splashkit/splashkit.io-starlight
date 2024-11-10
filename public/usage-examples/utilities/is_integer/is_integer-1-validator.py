from splashkit import *

write_line("Welcome to the Integer Validation Checker!")

valid_input = False

# Loop until the user enters a valid integer
while not valid_input:
    write_line("Please enter a valid integer:")
    input_value = read_line()

    # Check if the input is a valid integer
    if is_integer(input_value):
        number = convert_to_integer(input_value)  # Convert input to integer
        write_line(f"Great! You've entered a valid integer: {number}")
        valid_input = True  # Exit loop on valid input
    else:
        write_line("Oops! That's not a valid integer. Please try again.")

write_line("Thank you for using the Integer Validation Checker!")
