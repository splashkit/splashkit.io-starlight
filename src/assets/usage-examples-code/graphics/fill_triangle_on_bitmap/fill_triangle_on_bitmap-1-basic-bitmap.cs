using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Underwater Adventure", 1000, 500);
ClearScreen();
Bitmap underwaterScene = new Bitmap("underwater_scene", "underwater_scene.png");
DrawBitmap(underwaterScene, 0, 0);
DrawText("Colourful Fish", Color.Red, "arial", 123, 240, 200);
DrawLine(Color.Red, 280, 220, 305, 255);
FillTriangle(Color.Red, 285, 250, 310, 240, 310, 260);
RefreshScreen();
Delay(5000);

CloseAllWindows();