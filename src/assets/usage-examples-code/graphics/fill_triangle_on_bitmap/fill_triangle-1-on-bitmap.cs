using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Underwater Adventure", 1000, 800);
ClearScreen();
Bitmap underwaterScene = new Bitmap("underwater_scene", "underwater_scene.png");
DrawBitmap(underwaterScene, 0, 0);
DrawText("Colourful Fish", Color.Red, "arial", 23, 140, 100);
DrawLine(Color.Red, 180, 120, 205, 155);
FillTriangle(Color.Red, 185, 150, 210, 140, 210, 160);
RefreshScreen();
Delay(5000);

CloseAllWindows();

