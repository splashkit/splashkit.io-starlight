using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window window = new Window("Circle At", 800, 600);

        Circle circle = SplashKit.CircleAt(200, 300, 100);

        window.Clear(Color.White);
        SplashKit.FillCircle(Color.Red, circle);
        window.Refresh();

        SplashKit.Delay(8000);
    }
}
