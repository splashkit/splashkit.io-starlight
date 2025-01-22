using SplashKitSDK;
using static SplashKitSDK.SplashKit;


// Create Window
Window window = OpenWindow("Colourful Starburst", 600, 600);

ClearScreen(ColorBlack());

// Draws starburst pattern with changing colours to specific window
DrawLineOnWindow(window, ColorYellow(), 0, 0, 600, 600);
DrawLineOnWindow(window, ColorGreen(), 0, 150, 600, 450);
DrawLineOnWindow(window, ColorTeal(), 0, 300, 600, 300);
DrawLineOnWindow(window, ColorBlue(), 0, 450, 600, 150);
DrawLineOnWindow(window, ColorViolet(), 0, 600, 600, 0);
DrawLineOnWindow(window, ColorPurple(), 150, 0, 450, 600);
DrawLineOnWindow(window, ColorPink(), 300, 0, 300, 600);
DrawLineOnWindow(window, ColorRed(), 450, 0, 150, 600);      
DrawLineOnWindow(window, ColorOrange(), 600, 0, 0, 600);

RefreshScreen();

Delay(5000);
CloseAllWindows();
