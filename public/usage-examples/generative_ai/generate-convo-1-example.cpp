#include "splashkit.h"
#include <string>
#include <iostream>

int main()
{
    // Initialize SplashKit
    open_window("AI Conversation Example", 800, 600);
    
    // Display welcome message
    write_line("=== Terminal AI Conversation ===");
    write_line("Type your message and press Enter to chat with AI");
    write_line("Type 'quit' to exit");
    write_line("");
    
    std::string user_message;
    
    // Simple conversation loop
    while (true)
    {
        // Get user input
        write("You: ");
        user_message = read_line();
        
        // Check if user wants to quit
        if (user_message == "quit")
        {
            write_line("Goodbye!");
            break;
        }
        
        // Skip empty messages
        if (user_message.empty())
        {
            continue;
        }
        
        // Generate AI response using generate_text()
        std::string ai_response = generate_text(user_message);
        
        // Display AI response
        write_line("AI: " + ai_response);
        write_line("");
    }
    
    close_window("AI Conversation Example");
    return 0;
}
