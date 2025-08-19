from splashkit import *

pi = 3.14159265358979323846
write_line("Circle Area Calculator:")

radius = 1.0
while radius <= 10.0:
    write("Radius: ")
    write_double(radius)  # Writing a double
    write(", Area: ")
    write_double(pi * radius * radius)  # Writing the calculated area as a double
    write_line("")
    radius += 1.0