from splashkit import *

text = "   Whitespace is sneaky!   "

write_line(f"Original string with sneaky spaces: '{text}'")
write_line("Let's get rid of those pesky spaces...")

# Trim spaces from the start and end
trimmed = trim(text)

write_line(f"Trimmed string: '{trimmed}'")
write_line("Aha! Much better without those sneaky spaces!")
