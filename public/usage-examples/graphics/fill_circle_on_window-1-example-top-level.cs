using static SplashKitSDK.SplashKit;

// Open a new window and initialize to a window variable
SplashKitSDK.Window window = OpenWindow("Traffic Lights", 800, 600);

ClearScreen(ColorWhite());

// Use function to place 3 circles in destination window as traffic lights
FillCircleOnWindow(window, ColorRed(), 400, 100, 50);
FillCircleOnWindow(window, ColorYellow(), 400, 250, 50);
FillCircleOnWindow(window, ColorGreen(), 400, 400, 50);

RefreshScreen();
Delay(5000);

// Close all windows
CloseAllWindows();