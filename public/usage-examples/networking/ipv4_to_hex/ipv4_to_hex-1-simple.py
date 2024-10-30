from splashkit import *

write_line("Hello! Welcome to the IP to hexadecimal converter.")

# Prompt the user for an IP input in dotted decimal format (e.g., 127.0.0.1)
write_line("Please enter an IPv4 address in dotted decimal format (e.g., 127.0.0.1):")

# Read the input from the user
ip_input = read_line()

# Convert the IPv4 string to hexadecimal
ip_as_hex = ipv4_to_hex(ip_input)

# Display the result in hexadecimal format
write_line(f"The IP address in hexadecimal format is: {ip_as_hex}")
