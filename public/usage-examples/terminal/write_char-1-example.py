from splashkit import *

symbol = '*'

write("   _______________                        |")
write_char(symbol)
write("\\_/")
write_char(symbol)
write("|________\n")

write("  |  ___________  |     .-.     .-.      ||_/")
write_char(symbol)
write("-")
write_char(symbol)
write("|______  |\n")

write("  | |           | |    .")
for _ in range(4): 
    write_char(symbol)
write(". .")
for _ in range(4): 
    write_char(symbol)
write(".     | |           | |\n")

write("  | |   ")
write_char(symbol)
write("   ")
write_char(symbol)
write("   | |    .")
for _ in range(5): 
    write_char(symbol)
write(".")
for _ in range(5): 
    write_char(symbol)
write(".     | |   ")
write_char(symbol)
write("   ")
write_char(symbol)
write("   | |\n")

write("  | |     -     | |     .")
for _ in range(9): 
    write_char(symbol)
write(".      | |     -     | |\n")

write("  | |   \\___/   | |      .")
for _ in range(7): 
    write_char(symbol)
write(".       | |   \\___/   | |\n")

write("  | |___     ___| |       .")
for _ in range(5): 
    write_char(symbol)
write(".        | |___________| |\n")

write("  |_____|\\_/|_____|        .")
for _ in range(3): 
    write_char(symbol)
write(".         |_______________|\n")

write("    _|__|/ \\|_|_.............")
write_char(symbol)
write(".............._|________|_\n")

write("   / ")
for _ in range(10): 
    write_char(symbol)
write(" \\                          / ")
for _ in range(10): 
    write_char(symbol)
write(" \\\n")

write(" /  ")
for _ in range(12): 
    write_char(symbol)
write("  \\                      /  ")
for _ in range(12): 
    write_char(symbol)
write("  \\\n")

write_line("--------------------                    --------------------\n")