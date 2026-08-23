# Simple Terminal AI Conversation - Python Example

from splashkit import *

def main():
    """Main function to run the AI conversation"""
    
    # Display welcome message
    clear_screen()
    print("=== Terminal AI Conversation ===")
    print("Type your message and press Enter to chat with AI")
    print("Type 'quit' to exit")
    print("")
    
    # Simple conversation loop
    while True:
        # Get user input
        user_message = input("You: ")
        
        # Check if user wants to quit
        if user_message.lower() == "quit":
            print("Goodbye!")
            break
        
        # Skip empty messages
        if not user_message.strip():
            continue
        
        # Generate AI response using generate_text()
        ai_response = generate_text(user_message)
        
        # Display AI response
        print(f"AI: {ai_response}")
        print("")

# Run the program
if __name__ == "__main__":
    main()
