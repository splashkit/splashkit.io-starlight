using SplashKitSDK;

namespace WriteCharArt
{
    public class Program
    {
        public static void Main()
        {
            char symbol = '*';

            SplashKit.Write("   _______________                        |");
            SplashKit.Write(symbol);
            SplashKit.Write("\\_/");
            SplashKit.Write(symbol);
            SplashKit.Write("|________\n");

            SplashKit.Write("  |  ___________  |     .-.     .-.      ||_/");
            SplashKit.Write(symbol);
            SplashKit.Write("-");
            SplashKit.Write(symbol);
            SplashKit.Write("|______  |\n");

            SplashKit.Write("  | |           | |    .");
            for (int i = 0; i < 4; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(". .");
            for (int i = 0; i < 4; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".     | |           | |\n");

            SplashKit.Write("  | |   ");
            SplashKit.Write(symbol);
            SplashKit.Write("   ");
            SplashKit.Write(symbol);
            SplashKit.Write("   | |    .");
            for (int i = 0; i < 5; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".");
            for (int i = 0; i < 5; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".     | |   ");
            SplashKit.Write(symbol);
            SplashKit.Write("   ");
            SplashKit.Write(symbol);
            SplashKit.Write("   | |\n");

            SplashKit.Write("  | |     -     | |     .");
            for (int i = 0; i < 9; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".      | |     -     | |\n");

            SplashKit.Write("  | |   \\___/   | |      .");
            for (int i = 0; i < 7; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".       | |   \\___/   | |\n");

            SplashKit.Write("  | |___     ___| |       .");
            for (int i = 0; i < 5; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".        | |___________| |\n");

            SplashKit.Write("  |_____|\\_/|_____|        .");
            for (int i = 0; i < 3; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(".         |_______________|\n");

            SplashKit.Write("    _|__|/ \\|_|_.............");
            SplashKit.Write(symbol);
            SplashKit.Write(".............._|________|_\n");

            SplashKit.Write("   / ");
            for (int i = 0; i < 10; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(" \\                          / ");
            for (int i = 0; i < 10; i++)
                SplashKit.Write(symbol);
            SplashKit.Write(" \\\n");

            SplashKit.Write(" /  ");
            for (int i = 0; i < 12; i++)
                SplashKit.Write(symbol);
            SplashKit.Write("  \\                      /  ");
            for (int i = 0; i < 12; i++)
                SplashKit.Write(symbol);
            SplashKit.Write("  \\\n");

            SplashKit.WriteLine("--------------------                    --------------------\n");
        }
    }
}