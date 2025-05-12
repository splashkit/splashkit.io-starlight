from splashkit import *

write_line("Type a phrase in ALL CAPS (SHOUT IT!):")
input_text = read_line()

# Convert input to lowercase
quieted = to_lowercase(input_text)

write_line(f"Calm down... here it is in lowercase: {quieted}")
