using SplashKitSDK;
using static SplashKitSDK.SplashKit;

// Create Window
Window Window = OpenWindow("Portal", 600, 600);

// Load portal sprites
LoadBitmap("BluePortal", "bluePortal.png");
LoadBitmap("OrangePortal", "orangePortal.png");
Sprite BluePortal = CreateSprite(BitmapNamed("BluePortal"));
Sprite OrangePortal = CreateSprite(BitmapNamed("OrangePortal"));

// Set random portal location
SpriteSetPosition(BluePortal, RandomWindowPoint(Window));
SpriteSetPosition(OrangePortal, RandomWindowPoint(Window));

ClearWindow(Window, ColorBlack());

// Draw the sprite
DrawSprite(BluePortal);
DrawSprite(OrangePortal);

RefreshScreen();
Delay(5000);
CloseWindow(Window);