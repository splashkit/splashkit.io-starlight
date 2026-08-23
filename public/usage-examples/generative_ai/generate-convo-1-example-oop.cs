// Simple Terminal AI Conversation - OOP C# Example
// This example uses a class structure

using SplashKitSDK;

class AIConversation
{
    // Main entry point
    static void Main()
    {
        // Create an instance of the conversation class
        AIConversation conversation = new AIConversation();
        
        // Run the conversation
        conversation.Start();
    }
    
    // Method to start the conversation loop
    public void Start()
    {
        // Display welcome message
        SplashKit.ClearScreen();
        SplashKit.WriteLine("=== Terminal AI Conversation ===");
        SplashKit.WriteLine("Type your message and press Enter to chat with AI");
        SplashKit.WriteLine("Type 'quit' to exit");
        SplashKit.WriteLine("");
        
        // Continue conversation until user quits
        while (true)
        {
            string userMessage = GetUserInput();
            
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
            
            // Get and display AI response
            DisplayAIResponse(userMessage);
        }
    }
    
    // Method to get user input
    private string GetUserInput()
    {
        SplashKit.Write("You: ");
        return SplashKit.ReadLine();
    }
    
    // Method to generate and display AI response
    private void DisplayAIResponse(string userMessage)
    {
        // Generate AI response using generate_text()
        string aiResponse = SplashKit.GenerateText(userMessage);
        
        // Display the response
        SplashKit.WriteLine("AI: " + aiResponse);
        SplashKit.WriteLine("");
    }
}
