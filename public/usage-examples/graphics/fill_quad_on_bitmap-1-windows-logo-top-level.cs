using static SplashKitSDK.SplashKit;
using SplashKitSDK;

// Create a window and bitmap for the window
Window window = OpenWindow("Windows Logo", 400, 300);
Bitmap bitmap = CreateBitmap("Windows Logo Bitmap", 400, 300);

// Fill background with windows blue
ClearBitmap(bitmap, RGBAColor(51, 118, 212, 255));

// Draw the four Window panels
Quad[] panels = {
    QuadFrom(
        85, 50, 
        180, 41,  
        85, 130,    
        180, 130  
    ),
    QuadFrom(
        193, 40,  
        323, 26,  
        193, 130,   
        323, 130 
    ),
    QuadFrom(
        85, 143, 
        180, 143,  
        85, 222,   
        180, 233  
    ),
    QuadFrom(
        193, 143, 
        323, 143, 
        193, 235,  
        323, 250 
    )
};

// Draw each panel
for (int i = 0; i < panels.Length; i++)
{
    FillQuadOnBitmap(bitmap, ColorWhite(), panels[i]);
}

while (!window.CloseRequested)
{
    ProcessEvents();
    // Draw the bitmap to the window
    DrawBitmap(bitmap, 0, 0);
    // Refresh the window
    RefreshScreen();
}

FreeBitmap(bitmap);