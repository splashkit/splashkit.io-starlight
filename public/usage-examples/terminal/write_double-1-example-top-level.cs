using static SplashKitSDK.SplashKit;

double pi = 3.14159265358979323846;
WriteLine("Circle Area Calculator:");

for (double radius = 1.0; radius <= 10.0; radius += 1.0)
{
    Write("Radius: ");
    Write(radius); // Writing a double
    Write(", Area: ");
    Write(pi * radius * radius); // Writing the calculated area as a double
    WriteLine("");
}