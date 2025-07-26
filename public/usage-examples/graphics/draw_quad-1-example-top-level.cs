using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create 4 diamond shapes using quads
Quad q1 = QuadFrom(400, 200, 300, 300, 300, 0, 200, 200);   
Quad q2 = QuadFrom(400, 210, 310, 300, 600, 300, 400, 390);
Quad q3 = QuadFrom(200, 400, 300, 300, 300, 600, 400, 400);
Quad q4 = QuadFrom(200, 390, 290, 300, 0, 300, 200, 210);   

OpenWindow("Ninja Star", 600, 600);
ClearScreen(ColorWhite());

// Draw the quads
DrawQuad(ColorBlack(), q1);
DrawQuad(ColorGreen(), q2);
DrawQuad(ColorRed(),   q3);
DrawQuad(ColorBlue(),  q4);

RefreshScreen();
Delay(5000);
CloseAllWindows();
