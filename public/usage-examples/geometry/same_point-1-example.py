from splashkit import *

def get_point(prompt):
    # Get user input
    write(prompt)
    guess_input = read_line()
    coords = split(guess_input, ',')

    # Validate input
    while (not is_double(coords[0]) or not is_double(coords[1])):
        write_line("Invalid input. Try again.")
        write(prompt)
        guess_input = read_line()
        coords = split(guess_input, ',')

    # Convert input
    guess_x = convert_to_double(coords[0])
    guess_y = convert_to_double(coords[1])
    return point_at(guess_x, guess_y)

def main():
    # Variable declarations
    target_point = point_at(50, 75)

    write_line("Guess the coordinate inside (100,100)")

    # Get point input from user
    guess_point = get_point("Enter your coordinates as x,y: ")

    while (not same_point(target_point, guess_point)):        
        # Clues
        if target_point.x > guess_point.x:
            write_line("x is too low")
        elif target_point.x < guess_point.x:
            write_line("x is too high")
        else:
            write_line("x is correct !!!")
        
        if target_point.y > guess_point.y: 
            write_line("y is too low")
        elif target_point.y < guess_point.y: 
            write_line("y is too high")
        else: 
            write_line("y is correct !!!")

        write_line("Try Again!")
        guess_point = get_point("Enter your coordinates as x,y: ")

    write_line("You Win!")

main()