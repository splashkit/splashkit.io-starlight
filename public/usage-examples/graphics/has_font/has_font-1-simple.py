from splashkit import *

# Check if program has font
write("Font available before loading: ")
if (has_font(font_named("MyFont"))):
    write_line("True")
else:
    write_line("False")

# Load font
my_font = load_font("MyFont", "arial.ttf")

# Check if program has font again
write("Font available after loading: ")
if (has_font(my_font)):
    write_line("True")
else:
    write_line("False")
