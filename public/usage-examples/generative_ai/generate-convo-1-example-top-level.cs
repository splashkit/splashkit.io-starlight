// Simple Terminal AI Conversation - Top-Level C# Example
// This example uses top-level statements (C# 9+)

using SplashKitSDK;

// Display welcome message
SplashKit.ClearScreen();
SplashKit.WriteLine("=== Terminal AI Conversation ===");
SplashKit.WriteLine("Type your message and press Enter to chat with AI");
SplashKit.WriteLine("Type 'quit' to exit");
SplashKit.WriteLine("");

string userMessage;

// Simple conversation loop
while (true)
{
    // Get user input
    SplashKit.Write("You: ");
    userMessage = SplashKit.ReadLine();
    
    // Check if user wants to quit
    if (userMessage == "quit")
    {
        SplashKit.WriteLine("Goodbye!");
        break;
    }
    
    // Skip empty messages
    if (string.IsNullOrWhiteSpace(userMessage))
    {
        continue;
    }
    
    // Generate AI response using generate_text()
    string aiResponse = SplashKit.GenerateText(userMessage);
    
    // Display AI response
    SplashKit.WriteLine("AI: " + aiResponse);
    SplashKit.WriteLine("");
}
