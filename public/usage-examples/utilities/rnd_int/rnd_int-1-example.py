from splashkit import *

write_line("Get ready to generate a random number up to 1000...")
write_line("Drum roll please...")
delay(2000) # Delay for 2 seconds

# Generate a random number up to the ubound
random_number = rnd_int(1000)

write_line(f"Your lucky number is: {random_number}")
write_line("Feeling lucky? Maybe it's time to play the lottery!")