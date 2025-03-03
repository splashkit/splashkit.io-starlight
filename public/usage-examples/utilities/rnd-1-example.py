from splashkit import *

write_line("")
write_line("Let's simulate a Coin Flip!")
write_line("")
write_line("Flipping coin ...")
delay(1500)
write_line("")

random = 0.5

# Add extra "randomness"
for _ in range(100):
    random = rnd()

# 50% chance of heads or tails
if (random < 0.5):
    write_line("Heads!")
else:
    write_line("Tails!")
write_line("")