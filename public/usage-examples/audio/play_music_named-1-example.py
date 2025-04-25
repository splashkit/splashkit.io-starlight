from splashkit import *

# Check if audio is ready to use
if not audio_ready():
    open_audio()

# Load music file
load_music("adventure", "time_for_adventure.mp3")

# Start music playback
play_music_named("adventure")

# Hold program for 10 seconds
delay(10000)

# Free resources
free_all_music()