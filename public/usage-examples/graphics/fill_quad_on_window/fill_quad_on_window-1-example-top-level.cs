using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create diamond shaped quads
Quad q1 = QuadFrom(400, 200, 300, 300, 300, 0, 200, 200);
Quad q2 = QuadFrom(400, 210, 310, 300, 600, 300, 400, 390);
Quad q3 = QuadFrom(200, 400, 300, 300, 300, 600, 400, 400);
Quad q4 = QuadFrom(200, 390, 290, 300, 0, 300, 200, 210);

// Create two Windows
Window window1 = OpenWindow("Filled Diamond On Window 1", 600, 600);
Window window2 = OpenWindow("Filled Diamond On Window 2", 600, 600);

// Move windows to see both side by side
MoveWindowTo(window1, 0, 0);
MoveWindowTo(window2, WindowWidth(window1), 0);

ClearScreen(ColorWhite());

// Draw the first and second quad on first window
FillQuadOnWindow(window1, ColorBlack(), q1);
FillQuadOnWindow(window1, ColorGreen(), q2);

// Draw the third and fourth quad on second window
FillQuadOnWindow(window2, ColorRed(),  q3);
FillQuadOnWindow(window2, ColorBlue(), q4);

RefreshScreen();
Delay(5000);
CloseAllWindows();
