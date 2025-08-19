using static SplashKitSDK.SplashKit;

char symbol = '*';

Write("   _______________                        |");
Write(symbol);
Write("\\_/");
Write(symbol);
Write("|________\n");

Write("  |  ___________  |     .-.     .-.      ||_/");
Write(symbol);
Write("-");
Write(symbol);
Write("|______  |\n");

Write("  | |           | |    .");
for (int i = 0; i < 4; i++)
    Write(symbol);
Write(". .");
for (int i = 0; i < 4; i++)
    Write(symbol);
Write(".     | |           | |\n");

Write("  | |   ");
Write(symbol);
Write("   ");
Write(symbol);
Write("   | |    .");
for (int i = 0; i < 5; i++)
    Write(symbol);
Write(".");
for (int i = 0; i < 5; i++)
    Write(symbol);
Write(".     | |   ");
Write(symbol);
Write("   ");
Write(symbol);
Write("   | |\n");

Write("  | |     -     | |     .");
for (int i = 0; i < 9; i++)
    Write(symbol);
Write(".      | |     -     | |\n");

Write("  | |   \\___/   | |      .");
for (int i = 0; i < 7; i++)
    Write(symbol);
Write(".       | |   \\___/   | |\n");

Write("  | |___     ___| |       .");
for (int i = 0; i < 5; i++)
    Write(symbol);
Write(".        | |___________| |\n");

Write("  |_____|\\_/|_____|        .");
for (int i = 0; i < 3; i++)
    Write(symbol);
Write(".         |_______________|\n");

Write("    _|__|/ \\|_|_.............");
Write(symbol);
Write(".............._|________|_\n");

Write("   / ");
for (int i = 0; i < 10; i++)
    Write(symbol);
Write(" \\                          / ");
for (int i = 0; i < 10; i++)
    Write(symbol);
Write(" \\\n");

Write(" /  ");
for (int i = 0; i < 12; i++)
    Write(symbol);
Write("  \\                      /  ");
for (int i = 0; i < 12; i++)
    Write(symbol);
Write("  \\\n");

WriteLine("--------------------                    --------------------\n");