from splashkit import *

write_line("Starting tick capture...")

# Get the ticks before delay
ticks_before = current_ticks()
write_line(f"Ticks before any delay: {ticks_before}")

# Delay for 1 second (1000 milliseconds) and capture ticks
delay(1000)
ticks_after_1s = current_ticks()
write_line(f"Ticks after 1 second: {ticks_after_1s}")

# Delay for 2 more seconds (2000 milliseconds) and capture ticks
delay(2000)
ticks_after_2s = current_ticks()
write_line(f"Ticks after 2 more seconds (3 seconds total): {ticks_after_2s}")

# Delay for 4 more seconds (4000 milliseconds) and capture ticks
delay(4000)
ticks_after_4s = current_ticks()
write_line(f"Ticks after 4 more seconds (7 seconds total): {ticks_after_4s}")

# Show the difference in ticks at each capture point
diff_1s = ticks_after_1s - ticks_before
diff_2s = ticks_after_2s - ticks_after_1s
diff_4s = ticks_after_4s - ticks_after_2s

write_line(f"Ticks passed in the first second: {diff_1s}")
write_line(f"Ticks passed in the next 2 seconds: {diff_2s}")
write_line(f"Ticks passed in the final 4 seconds: {diff_4s}")
