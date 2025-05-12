from splashkit import *

write_line("Countdown:")
for i in range(10, -1, -1):  # Countdown from 10 to 0
    write("T-minus ")
    write_int(i)  # Writing an integer
    write_line(" seconds...")

write_line("Lift off!")