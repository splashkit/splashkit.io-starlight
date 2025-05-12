from splashkit import *

# Write a terminal welcome message and instructions
write_line("Welcome to the Magic 8-Ball!")
write_line("Ask a question, and let the universe decide your fate...")
write_line("Choose a question by typing the number:")
write_line("1. Will I have a good week?")
write_line("2. Is it my lucky day?")
write_line("3. Should I take that risk?")
write_line("4. Will I find what I'm looking for?")

write_line("Your choice (1-4): ")
choice = int(read_line())

write_line("\nShaking the Magic 8-Ball...")
delay(2000)  # Add suspense

# Generate a random float and determine the response
random_value = rnd()
write_line("The universe whispers...")

if random_value < 0.5:
    # Less than 0.5 responses
    if choice == 1:
        write_line("\"Not likely, but keep your head up.\"")
    elif choice == 2:
        write_line("\"The odds aren't in your favor, but miracles happen.\"")
    elif choice == 3:
        write_line("\"It's better to wait and see.\"")
    elif choice == 4:
        write_line("\"Keep searching. It's not your time yet.\"")
    else:
        write_line("\"Hmm... the universe is confused by your question.\"")
else:
    # Greater than or equal to 0.5 responses
    if choice == 1:
        write_line("\"Yes! This week is yours to conquer.\"")
    elif choice == 2:
        write_line("\"Absolutely, luck is on your side!\"")
    elif choice == 3:
        write_line("\"Go for it! Fortune favors the bold.\"")
    elif choice == 4:
        write_line("\"Yes, you'll find it sooner than you think.\"")
    else:
        write_line("\"Hmm... the universe is confused by your question.\"")

write_line("\nThe Magic 8-Ball has spoken. Have a great day!")