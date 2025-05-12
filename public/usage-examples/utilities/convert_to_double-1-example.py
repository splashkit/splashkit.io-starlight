from splashkit import *

write_line("Welcome to the Simple Interest Calculator!")

# Get principal amount from the user
write_line("Please enter the principal amount (in dollars):")
principal_input = read_line()

# Get the interest rate from the user
write_line("Please enter the interest rate (as a percentage, e.g., 5 for 5%):")
rate_input = read_line()

# Get the time period from the user
write_line("Please enter the time period (in years):")
time_input = read_line()

# Convert inputs to double
principal = convert_to_double(principal_input)
rate = convert_to_double(rate_input)
time = convert_to_double(time_input)

# Calculate simple interest: Interest = Principal * Rate * Time / 100
interest = (principal * rate * time) / 100

# Output the result
write_line("Calculating interest...")
delay(1000)

write_line(f"For a principal of ${principal} at an interest rate of {rate}% over {time} years:")
write_line(f"The simple interest is: ${interest}")
