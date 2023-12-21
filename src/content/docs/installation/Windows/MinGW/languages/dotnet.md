---
title: Installing the .NET Core SDK on Windows
sidebar:
  hidden: true
  attrs:
    class: windows

---
Installing .NET on Windows is necessary because it provides the runtime environment and libraries required to run applications developed using the .NET framework. 
To get programming with C#, you can install the Dotnet Core tools.

## Steps
1. Open an MSYS2 terminal
1. Run the following command:

    ```bash
    pacman -S mingw-w64-{x86_64,i686}-gcc mingw-w64-{i686,x86_64}-gdb
    ```

    ![](/gifs/windows/install-gpp-msys.gif)

1. Go to the [dotnet core](https://www.microsoft.com/net/core) page.

    Select `windows`, `command line/other` then download the `.net core sdk`.

    ![](/gifs/windows/8.gif)

1. Run the installer and continue through the install wizard with default values.

    ![](/gifs/windows/9.gif)

1. Install the C# extension in Visual Studio Code.

    The C# extension will give you a great code formatter, Intellisense and OmniSharp. Open the extensions panel in the left of Visual Studio Code, and search for the extension `C#`, install the one by Microsoft.

