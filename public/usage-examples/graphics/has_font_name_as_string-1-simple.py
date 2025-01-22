from splashkit import *
 
# Load a font
load_font("my_font", "arial.ttf")

# Display the text to show the result
if has_font_name_as_string("my_font"):
    write_line("Font found!")
else:
    write_line("Font not found!")