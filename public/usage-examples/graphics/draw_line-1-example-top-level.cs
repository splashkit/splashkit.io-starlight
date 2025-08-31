using static SplashKitSDK.SplashKit;

OpenWindow("Colourful Starburst", 600, 600);
ClearScreen(ColorBlack());

// Draws starburst pattern with changing colours
DrawLine(ColorYellow(), 0, 0, 600, 600);
DrawLine(ColorGreen(), 0, 150, 600, 450);
DrawLine(ColorTeal(), 0, 300, 600, 300);
DrawLine(ColorBlue(), 0, 450, 600, 150);
DrawLine(ColorViolet(), 0, 600, 600, 0);
DrawLine(ColorPurple(), 150, 0, 450, 600);
DrawLine(ColorPink(), 300, 0, 300, 600);
DrawLine(ColorRed(), 450, 0, 150, 600);      
DrawLine(ColorOrange(), 600, 0, 0, 600);

RefreshScreen();
Delay(5000);
CloseAllWindows();
