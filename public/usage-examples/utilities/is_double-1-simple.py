from splashkit import *

values = ["123", "45.67", "-50", "abc", "789", "0"]

for value in values:
    # Print the value along with the result using "true" or "false"
    write(f"{value} - ")

    # Check if string is a valid double
    if (is_double(value)):
        write_line("true")
    else:
        write_line("false")