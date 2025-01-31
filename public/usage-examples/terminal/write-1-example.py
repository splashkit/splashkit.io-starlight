from splashkit import *

write_line("Progress Bar Simulation:")
write("Loading: [")

for i in range(16):  # Simulate progress in 15 steps
    delay(150)  # Pause for 150 milliseconds
    write("=")  # Append to the progress bar

write_line("] Complete!\n")