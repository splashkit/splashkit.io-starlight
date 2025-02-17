using static SplashKitSDK.SplashKit;

// Create a new window with title and dimensions 
OpenWindow("Night Sky", 500, 533);

// Create and load new bitmap using the picture file and initialise new bitmap variable
SplashKitSDK.Bitmap night_sky = LoadBitmap("night_sky", "sky.jpg");

// Create black rectangles for buildings, with x and y axis and dimensions  
FillRectangleOnBitmap(night_sky, ColorBlack(), 40, 200, 100, 400); //Building 1
FillRectangleOnBitmap(night_sky, ColorBlack(), 200, 400, 100, 400); // Building 2
FillRectangleOnBitmap(night_sky, ColorBlack(), 350, 300, 100, 300); // Building 3

// For loop to create the illumimated windows on each building with different numbers depending 
// on the placement of the building
// Building 1
for (int j = 220; j < 700; j += 50)
{
    for (int i = 55; i < 135; i += 20)
        {
            FillRectangleOnBitmap(night_sky, ColorOrange(), i, j, 10, 20);
        }
}

// Building 2
for (int j = 420; j < 570; j += 50)
{
    for (int i = 215; i < 295; i += 20)
    {
        FillRectangleOnBitmap(night_sky, ColorYellow(), i, j, 10, 20);
    }
}

// Building 3
for (int j = 320; j < 700; j += 50)
{
    for (int i = 365; i < 440; i += 20)
    {
        FillRectangleOnBitmap(night_sky, ColorOrange(), i, j, 10, 20);
    }
}

// Clear screen and draw bitmap
ClearScreen();
DrawBitmap(night_sky, 0, 0);
RefreshScreen();
Delay(5000);

// Free resources and close windows 
FreeAllBitmaps();
CloseAllWindows();