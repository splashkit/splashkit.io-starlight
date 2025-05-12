from splashkit import *

# Write a string to the console with a delay between each word
def write_with_delay(text, delay_time):
    words = text.split(' ')
    for word in words:
        write(word + " ")
        delay(delay_time)
    write("")  # Output the last word if there’s no trailing space

write_with_delay("Hello there stranger!\n", 200)
delay(600)

write_with_delay("Oh, Hi! I didn't see you there.\n", 200)
delay(800)

write_with_delay("Wait, did you just whisper that?", 200)
delay(800)

write_with_delay("Come on, let's try that again...\n", 200)
delay(1100)

write_with_delay("HELLO THERE!\n", 200)
delay(600)

write_with_delay("Okay, okay... I felt that!", 200)
delay(900)

write_with_delay("But can you go even LOUDER?\n", 200)
delay(1100)

write_with_delay("HELLOOOOOOO!\n", 200)
delay(1500)

write_with_delay("Wow! That was intense. Let's cool down a bit...", 200)
delay(2100)

write_with_delay("Why are we even shouting?\n", 200)
delay(1100)

write_with_delay("Oh well, it's been fun.", 200)
delay(800)

write_with_delay("Catch you later!", 200)
write_line()