#include "splashkit.h"

int main()
{
    char symbol = '*';

    write("   _______________                        |");
    write(symbol);
    write("\\_/");
    write(symbol);
    write("|________\n");

    write("  |  ___________  |     .-.     .-.      ||_/");
    write(symbol);
    write("-");
    write(symbol);
    write("|______  |\n");

    write("  | |           | |    .");
    for (int i = 0; i < 4; i++)
        write(symbol);
    write(". .");
    for (int i = 0; i < 4; i++)
        write(symbol);
    write(".     | |           | |\n");

    write("  | |   ");
    write(symbol);
    write("   ");
    write(symbol);
    write("   | |    .");
    for (int i = 0; i < 5; i++)
        write(symbol);
    write(".");
    for (int i = 0; i < 5; i++)
        write(symbol);
    write(".     | |   ");
    write(symbol);
    write("   ");
    write(symbol);
    write("   | |\n");

    write("  | |     -     | |     .");
    for (int i = 0; i < 9; i++)
        write(symbol);
    write(".      | |     -     | |\n");

    write("  | |   \\___/   | |      .");
    for (int i = 0; i < 7; i++)
        write(symbol);
    write(".       | |   \\___/   | |\n");

    write("  | |___     ___| |       .");
    for (int i = 0; i < 5; i++)
        write(symbol);
    write(".        | |___________| |\n");

    write("  |_____|\\_/|_____|        .");
    for (int i = 0; i < 3; i++)
        write(symbol);
    write(".         |_______________|\n");

    write("    _|__|/ \\|_|_.............");
    write(symbol);
    write(".............._|________|_\n");

    write("   / ");
    for (int i = 0; i < 10; i++)
        write(symbol);
    write(" \\                          / ");
    for (int i = 0; i < 10; i++)
        write(symbol);
    write(" \\\n");

    write(" /  ");
    for (int i = 0; i < 12; i++)
        write(symbol);
    write("  \\                      /  ");
    for (int i = 0; i < 12; i++)
        write(symbol);
    write("  \\\n");

    write_line("--------------------                    --------------------\n");

    return 0;
}