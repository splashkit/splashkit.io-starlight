using static SplashKitSDK.SplashKit;

OpenWindow("Triangle Coordinates", 800, 400);

// Top middle triangle point
int x1 = 400;
int y1 = 100;

// Bottom left triangle point
int x2 = 200;
int y2 = 300;

// Bottom right triangle point
int x3 = 600;
int y3 = 300;

ClearScreen();

// Draw triangle using the points above
DrawTriangle(ColorRed(), x1, y1, x2, y2, x3, y3);

// Draw triangle information
FillCircle(ColorBlue(), x1, y1, 3);
FillCircle(ColorBlue(), x2, y2, 3);
FillCircle(ColorBlue(), x3, y3, 3);
DrawText($"(x={x1}, y={y1})", ColorBlue(), x1 - 50, y1 - 20);
DrawText($"(x={x2}, y={y2})", ColorBlue(), x2 - 120, y2);
DrawText($"(x={x3}, y={y3})", ColorBlue(), x3 + 10, y3);
RefreshScreen();
Delay(10000);

CloseAllWindows();