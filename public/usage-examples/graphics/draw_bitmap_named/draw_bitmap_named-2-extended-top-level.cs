using static SplashKitSDK.SplashKit;

// Download resources
DownloadSoundEffect("Hello World", "https://programmers.guide/resources/code-examples/part-0/hello-world-snippet-saddle-club.ogg", 443);
DownloadFont("main", "https://programmers.guide/resources/code-examples/part-0/Roboto-Italic.ttf", 443);
DownloadBitmap("Earth", "https://programmers.guide/resources/code-examples/part-0/earth.png", 443);
DownloadBitmap("SmallEarth", "https://programmers.guide/resources/code-examples/part-0/earth-small.png", 443);
DownloadBitmap("SplashKitBox", "https://programmers.guide/resources/code-examples/part-0/skbox.png", 443);

OpenWindow("Hello World: Using Resources with SplashKit", 800, 600);
PlaySoundEffect("Hello World");

ClearScreen(ColorWhite());
DrawText("Anyone remember the \"Hello World\" Saddle Club song?", ColorBlack(), "main", 30, 40, 200);
RefreshScreen();
Delay(2500);

ClearScreen(ColorWhite());

// H
DrawBitmap("SmallEarth", 20, 100);
DrawBitmap("SmallEarth", 20, 130);
DrawBitmap("SmallEarth", 20, 160);
DrawBitmap("SmallEarth", 20, 190);
DrawBitmap("SmallEarth", 20, 220);
DrawBitmap("SmallEarth", 52, 160);
DrawBitmap("SmallEarth", 84, 100);
DrawBitmap("SmallEarth", 84, 130);
DrawBitmap("SmallEarth", 84, 160);
DrawBitmap("SmallEarth", 84, 190);
DrawBitmap("SmallEarth", 84, 220);
RefreshScreen();
Delay(200);

// E
DrawBitmap("SmallEarth", 148, 100);
DrawBitmap("SmallEarth", 148, 130);
DrawBitmap("SmallEarth", 148, 160);
DrawBitmap("SmallEarth", 148, 190);
DrawBitmap("SmallEarth", 148, 220);
DrawBitmap("SmallEarth", 180, 100);
DrawBitmap("SmallEarth", 212, 100);
DrawBitmap("SmallEarth", 180, 160);
DrawBitmap("SmallEarth", 180, 220);
DrawBitmap("SmallEarth", 212, 220);
RefreshScreen();
Delay(200);

// L
DrawBitmap("SmallEarth", 276, 100);
DrawBitmap("SmallEarth", 276, 130);
DrawBitmap("SmallEarth", 276, 160);
DrawBitmap("SmallEarth", 276, 190);
DrawBitmap("SmallEarth", 276, 220);
DrawBitmap("SmallEarth", 308, 220);
DrawBitmap("SmallEarth", 340, 220);
RefreshScreen();
Delay(200);

// L
DrawBitmap("SmallEarth", 404, 100);
DrawBitmap("SmallEarth", 404, 130);
DrawBitmap("SmallEarth", 404, 160);
DrawBitmap("SmallEarth", 404, 190);
DrawBitmap("SmallEarth", 404, 220);
DrawBitmap("SmallEarth", 436, 220);
DrawBitmap("SmallEarth", 468, 220);
RefreshScreen();
Delay(200);

// O
DrawBitmap("SmallEarth", 530, 160);
DrawBitmap("SmallEarth", 622, 160);
DrawBitmap("SmallEarth", 540, 128);
DrawBitmap("SmallEarth", 560, 100);
DrawBitmap("SmallEarth", 592, 100);
DrawBitmap("SmallEarth", 612, 128);
DrawBitmap("SmallEarth", 540, 192);
DrawBitmap("SmallEarth", 560, 220);
DrawBitmap("SmallEarth", 592, 220);
DrawBitmap("SmallEarth", 612, 192);
RefreshScreen();
Delay(500);

// World
DrawBitmap("Earth", 100, 350);
RefreshScreen();
Delay(2000);

// SplashKit ("Me")
DrawBitmap("SplashKitBox", 450, 300);
DrawText("SplashKit!", ColorBlack(), "main", 50, 450, 530);
RefreshScreen();
Delay(2000);