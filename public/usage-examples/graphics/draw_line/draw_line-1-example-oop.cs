using SplashKitSDK;

namespace DrawLineExample
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Colourful Starburst", 600, 600);
            window.Clear(Color.Black);

            // Draws starburst pattern with changing colours to window
            window.DrawLine(Color.Yellow, 0, 0, 600, 600);
            window.DrawLine(Color.Green, 0, 150, 600, 450);
            window.DrawLine(Color.Teal, 0, 300, 600, 300);
            window.DrawLine(Color.Blue, 0, 450, 600, 150);
            window.DrawLine(Color.Violet, 0, 600, 600, 0);
            window.DrawLine(Color.Purple, 150, 0, 450, 600);
            window.DrawLine(Color.Pink, 300, 0, 300, 600);
            window.DrawLine(Color.Red, 450, 0, 150, 600);      
            window.DrawLine(Color.Orange, 600, 0, 0, 600);

            window.Refresh();
            SplashKit.Delay(5000);
            window.Close();
        }
    }
}